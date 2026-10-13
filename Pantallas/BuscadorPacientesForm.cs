using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TESTSOLAPAS
{
    /// <summary>
    /// Pantalla de listado de pacientes con búsqueda en vivo.
    /// Permite ver la ficha de detalle (modal) o abrir la consulta activa.
    /// </summary>
    public partial class BuscadorPacientesForm : Form
    {
        private readonly IPacienteRepository   _pacienteRepository;
        private readonly IEvolucionRepository  _evolucionRepository;
        private readonly Action<Form>          _abrirEnPanel;

        private List<Paciente> _todosPacientes = new();

        // ── Constructor ───────────────────────────────────────────────

        public BuscadorPacientesForm(
            IPacienteRepository  pacienteRepository,
            IEvolucionRepository evolucionRepository,
            Action<Form>         abrirEnPanel)
        {
            InitializeComponent();
            _pacienteRepository  = pacienteRepository;
            _evolucionRepository = evolucionRepository;
            _abrirEnPanel        = abrirEnPanel;

            ConfigurarEventos();
        }

        // ── Configuración de eventos ──────────────────────────────────

        private void ConfigurarEventos()
        {
            this.Load += BuscadorPacientesForm_Load;

            // Búsqueda en vivo al escribir
            txtBoxcuadroBusquedaPacientes.TextChanged += (s, e) => FiltrarYMostrar();

            // Botón Limpiar
            btnBusquedaPacientes.Click += (s, e) =>
            {
                txtBoxcuadroBusquedaPacientes.Clear();
                txtBoxcuadroBusquedaPacientes.Focus();
            };

            // Botones de acción
            btnVerDetalle.Click += (s, e) => AbrirDetalle();
            btnAtender.Click    += (s, e) => AbrirConsulta();

            // Doble clic en fila → Ver Detalle
            dtvBusquedaDePacientes.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0) AbrirDetalle();
            };
        }

        // ── Carga inicial ─────────────────────────────────────────────

        private void BuscadorPacientesForm_Load(object? sender, EventArgs e)
        {
            try
            {
                _todosPacientes = _pacienteRepository.ObtenerTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar pacientes: {ex.Message}",
                    "Error de conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _todosPacientes = new List<Paciente>();
            }

            FiltrarYMostrar();
        }

        // ── Búsqueda en memoria ───────────────────────────────────────

        private void FiltrarYMostrar()
        {
            string filtro = txtBoxcuadroBusquedaPacientes.Text.Trim();

            IEnumerable<Paciente> resultado = _todosPacientes;

            if (!string.IsNullOrEmpty(filtro))
            {
                resultado = _todosPacientes.Where(p =>
                    p.NombreCompleto.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                    p.Dni.Contains(filtro, StringComparison.OrdinalIgnoreCase));
            }

            PoblarGrilla(resultado.ToList());
        }

        private void PoblarGrilla(List<Paciente> pacientes)
        {
            dtvBusquedaDePacientes.Rows.Clear();

            foreach (var p in pacientes)
            {
                string edad = p.Edad > 0 ? $"{p.Edad} años" : "—";

                dtvBusquedaDePacientes.Rows.Add(
                    p.Dni,
                    p.NombreCompleto,
                    edad,
                    string.IsNullOrEmpty(p.Cobertura) ? "Particular" : p.Cobertura,
                    string.IsNullOrEmpty(p.MotivoConsulta) ? "—" : p.MotivoConsulta
                );

                // Guardar el objeto Paciente en la fila para recuperarlo luego
                dtvBusquedaDePacientes.Rows[dtvBusquedaDePacientes.Rows.Count - 1].Tag = p;
            }

            lblTotalResultados.Text = $"{pacientes.Count} paciente(s)";
        }

        // ── Acciones ─────────────────────────────────────────────────

        /// <summary>Abre el modal de ficha de detalle del paciente seleccionado.</summary>
        private void AbrirDetalle()
        {
            var paciente = ObtenerPacienteSeleccionado();
            if (paciente == null) return;

            try
            {
                var detalle = _pacienteRepository.ObtenerDetallePorId(paciente.Id);
                if (detalle == null)
                {
                    MessageBox.Show("No se encontraron datos del paciente.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using var dialogo = new PacienteDetalleDialog(detalle);
                var resultado = dialogo.ShowDialog(this);

                // Si el usuario eligió "Ir a Consulta" desde el modal
                if (resultado == DialogResult.OK)
                    AtenderPaciente(paciente);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el detalle: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Abre la consulta activa (PacienteForm) para el paciente seleccionado.</summary>
        private void AbrirConsulta()
        {
            var paciente = ObtenerPacienteSeleccionado();
            if (paciente == null) return;
            AtenderPaciente(paciente);
        }

        private void AtenderPaciente(Paciente paciente)
        {
            // turnoId = null → evolución suelta (ya soportado por PacienteForm)
            _abrirEnPanel(new PacienteForm(
                paciente,
                _evolucionRepository,
                turnoId: null,
                onVolver: () => _abrirEnPanel(new BuscadorPacientesForm(_pacienteRepository, _evolucionRepository, _abrirEnPanel))
            ));
        }

        /// <summary>
        /// Devuelve el Paciente de la fila seleccionada, o null si no hay selección.
        /// Muestra un aviso al usuario cuando no hay fila seleccionada.
        /// </summary>
        private Paciente? ObtenerPacienteSeleccionado()
        {
            if (dtvBusquedaDePacientes.CurrentRow?.Tag is Paciente p)
                return p;

            MessageBox.Show(
                "Seleccioná un paciente de la lista primero.",
                "Sin selección",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return null;
        }
    }
}
