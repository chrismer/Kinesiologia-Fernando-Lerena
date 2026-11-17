using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TESTSOLAPAS
{
    public partial class TurnosForm : Form
    {
        private readonly ITurnoRepository _turnoRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IEvolucionRepository _evolucionRepository;
        private readonly IFranjaRepository _franjaRepository;
        private readonly Action<Form>? _abrirEnPanel;
        private readonly SesionActual? _sesion;

        private List<TurnoItem> _turnosActuales = new();
        private List<FranjaItem> _franjas = new();

        public TurnosForm(
            ITurnoRepository? turnoRepository = null,
            IPacienteRepository? pacienteRepository = null,
            IEvolucionRepository? evolucionRepository = null,
            Action<Form>? abrirEnPanel = null,
            IFranjaRepository? franjaRepository = null,
            SesionActual? sesion = null)
        {
            InitializeComponent();

            _turnoRepository     = turnoRepository     ?? new MemoryTurnoRepository();
            _pacienteRepository  = pacienteRepository  ?? new MemoryPacienteRepository(new Paciente { Id = 1, NombreCompleto = "María Gómez Blanía", Dni = "12378738" });
            _evolucionRepository = evolucionRepository ?? new MemoryEvolucionRepository();
            _franjaRepository    = franjaRepository    ?? new MemoryFranjaRepository();
            _abrirEnPanel        = abrirEnPanel;
            _sesion              = sesion;

            ConfigurarEventos();
            ConfigurarAsignacion();
        }

        private void ConfigurarEventos()
        {
            this.Load += TurnosForm_Load;

            btnFiltrar.Click += (s, e) => EjecutarBusqueda();
            btnLimpiar.Click += BtnLimpiar_Click;
            txtBuscar.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; EjecutarBusqueda(); } };

            dgvTurnos.SelectionChanged += DgvTurnos_SelectionChanged;
            dgvTurnos.CellDoubleClick += (s, e) => { if (e.RowIndex >= 0) AtenderTurnoSeleccionado(); };

            btnMarcarLlegado.Click += BtnMarcarLlegado_Click;
            btnAtender.Click += (s, e) => AtenderTurnoSeleccionado();
            btnAsignarme.Click += (_, _) => Asignarme();
            btnAsignar.Click += (_, _) => AsignarAOtro();
        }

        private void ConfigurarAsignacion()
        {
            var esKine = _sesion is { Rol: "kinesiologo", ProfesionalId: not null };
            var puedeAsignarAOtros = _sesion is null || _sesion.Rol is "admin" or "recepcion";

            btnAsignarme.Visible = esKine;
            cmbAsignarA.Visible = puedeAsignarAOtros;
            btnAsignar.Visible = puedeAsignarAOtros;

            cmbAsignarA.DisplayMember = nameof(ProfesionalItem.Nombre);
            cmbAsignarA.Items.Clear();
            if (!puedeAsignarAOtros)
                return;

            try
            {
                foreach (var prof in _turnoRepository.ObtenerProfesionales())
                    cmbAsignarA.Items.Add(prof);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los kinesiólogos.\n" + ex.Message, "Turnos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbAsignarA.Items.Count > 0)
                cmbAsignarA.SelectedIndex = 0;
        }

        private void TurnosForm_Load(object? sender, EventArgs e)
        {
            // Rango de fechas por defecto: semana actual
            dtpDesde.Value = DateTime.Today.AddDays(-7);
            dtpHasta.Value = DateTime.Today.AddDays(14);

            // Cargar combo de profesionales
            CargarComboProfesionales();

            // Cargar combo de estados
            cmbEstado.Items.Clear();
            cmbEstado.Items.AddRange(new object[] { "Todos", "Pendiente", "Presente", "Atendido", "Ausente" });
            cmbEstado.SelectedIndex = 0;

            CargarComboFranjas();
            EjecutarBusqueda();
        }

        private void CargarComboFranjas()
        {
            cmbFranja.Items.Clear();
            cmbFranja.Items.Add("Todas");
            try
            {
                _franjas = _franjaRepository.ObtenerFranjas();
                foreach (var franja in _franjas)
                    cmbFranja.Items.Add(franja.Nombre);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron leer las franjas. Si usás Neon, corré sql/007_franja.sql.\n" + ex.Message,
                    "Franjas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                _franjas = new List<FranjaItem>();
            }

            cmbFranja.SelectedIndex = 0;
        }

        private void CargarComboProfesionales()
        {
            cmbProfesional.Items.Clear();
            cmbProfesional.Items.Add("Todos los profesionales");

            var profesionales = _turnoRepository.ObtenerProfesionales();
            foreach (var prof in profesionales)
            {
                cmbProfesional.Items.Add(prof.Nombre);
            }

            cmbProfesional.SelectedIndex = 0;
        }

        private void BtnLimpiar_Click(object? sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today.AddDays(-7);
            dtpHasta.Value = DateTime.Today.AddDays(14);
            cmbProfesional.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 0;
            if (cmbFranja.Items.Count > 0)
                cmbFranja.SelectedIndex = 0;
            txtBuscar.Clear();
            EjecutarBusqueda();
        }

        private void EjecutarBusqueda()
        {
            try
            {
                int? profId = null;
                if (cmbProfesional.SelectedIndex > 0)
                {
                    var profesionales = _turnoRepository.ObtenerProfesionales();
                    var seleccionado = profesionales.FirstOrDefault(p => p.Nombre == cmbProfesional.Text);
                    if (seleccionado != null) profId = seleccionado.Id;
                }

                string? estado = cmbEstado.SelectedIndex > 0 ? cmbEstado.Text : null;
                string busqueda = txtBuscar.Text.Trim();

                _turnosActuales = _turnoRepository.ObtenerTurnosParaTomar(
                    dtpDesde.Value.Date,
                    dtpHasta.Value.Date,
                    profId,
                    busqueda,
                    estado
                );

                if (cmbFranja.SelectedIndex > 0)
                {
                    var franja = _franjas.FirstOrDefault(f => f.Nombre == cmbFranja.Text);
                    if (franja is not null)
                        _turnosActuales = _turnosActuales.Where(t => FranjaCalendario.CaeEnFranja(t.Hora, franja)).ToList();
                }

                PoblarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar turnos: {ex.Message}", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PoblarGrilla()
        {
            dgvTurnos.Rows.Clear();

            foreach (var turno in _turnosActuales)
            {
                int rowIndex = dgvTurnos.Rows.Add(
                    turno.Id,
                    turno.Fecha.ToString("dd/MM/yyyy"),
                    turno.Hora.ToString(@"hh\:mm"),
                    turno.PacienteNombre,
                    turno.PacienteDni,
                    turno.Cobertura,
                    string.IsNullOrWhiteSpace(turno.ProfesionalNombre) ? "Sin asignar" : turno.ProfesionalNombre,
                    turno.Diagnostico,
                    turno.Estado
                );

                var row = dgvTurnos.Rows[rowIndex];
                row.Tag = turno;

                // Estilos por estado
                var celdaEstado = row.Cells[8];
                switch (turno.Estado)
                {
                    case "Atendido":
                        celdaEstado.Style.BackColor = Color.FromArgb(212, 237, 218);
                        celdaEstado.Style.ForeColor = Color.FromArgb(21, 87, 36);
                        celdaEstado.Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                        break;
                    case "Presente":
                        celdaEstado.Style.BackColor = Color.FromArgb(204, 229, 255);
                        celdaEstado.Style.ForeColor = Color.FromArgb(0, 64, 133);
                        celdaEstado.Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                        break;
                    case "Ausente":
                        celdaEstado.Style.BackColor = Color.FromArgb(248, 215, 218);
                        celdaEstado.Style.ForeColor = Color.FromArgb(114, 28, 36);
                        break;
                    default: // Pendiente
                        celdaEstado.Style.BackColor = Color.FromArgb(255, 243, 205);
                        celdaEstado.Style.ForeColor = Color.FromArgb(133, 100, 4);
                        break;
                }
            }

            lblTotalResultados.Text = $"{_turnosActuales.Count} turno(s) encontrado(s)";
        }

        private void DgvTurnos_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvTurnos.CurrentRow?.Tag is TurnoItem turno)
            {
                btnMarcarLlegado.Text = turno.Presente ? "Desmarcar Llegada" : "Marcar Llegado";
                btnMarcarLlegado.BackColor = turno.Presente ? Color.FromArgb(220, 53, 69) : Color.FromArgb(40, 167, 69);
            }
        }

        private void BtnMarcarLlegado_Click(object? sender, EventArgs e)
        {
            if (dgvTurnos.CurrentRow?.Tag is not TurnoItem turno)
            {
                MessageBox.Show("Seleccione un turno de la grilla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool nuevoEstado = !turno.Presente;
                _turnoRepository.MarcarPresente(turno.Id, nuevoEstado);
                EjecutarBusqueda();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la presencia: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtenderTurnoSeleccionado()
        {
            if (dgvTurnos.CurrentRow?.Tag is not TurnoItem turno)
            {
                MessageBox.Show("Seleccione un turno para iniciar la atención.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_abrirEnPanel == null)
            {
                MessageBox.Show($"Paciente: {turno.PacienteNombre}\nHorario: {turno.Hora:hh\\:mm}\nDiagnóstico: {turno.Diagnostico}", "Turno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var paciente = _pacienteRepository.ObtenerPorId(turno.PacienteId) ?? new Paciente
            {
                Id = turno.PacienteId,
                NombreCompleto = turno.PacienteNombre,
                Dni = turno.PacienteDni,
                Cobertura = turno.Cobertura,
                MotivoConsulta = turno.Nota,
                DiagnosticoInicial = turno.Diagnostico
            };

            // Abrir PacienteForm inyectándole el turnoId
            _abrirEnPanel(new PacienteForm(
                paciente,
                _evolucionRepository,
                turno.Id,
                onVolver: () => _abrirEnPanel(new TurnosForm(
                    _turnoRepository, _pacienteRepository, _evolucionRepository, _abrirEnPanel, _franjaRepository, _sesion))
            ));
        }

        private void Asignarme()
        {
            if (_sesion?.ProfesionalId is not int profesionalId)
                return;

            Asignar(profesionalId);
        }

        private void AsignarAOtro()
        {
            if (cmbAsignarA.SelectedItem is not ProfesionalItem prof)
            {
                MessageBox.Show("Elegí un kinesiólogo.", "Asignar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Asignar(prof.Id);
        }

        private void Asignar(int profesionalId)
        {
            var turnos = dgvTurnos.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(fila => fila.Tag as TurnoItem)
                .Where(turno => turno is not null)
                .Cast<TurnoItem>()
                .ToList();

            if (turnos.Count == 0)
            {
                MessageBox.Show("Seleccioná uno o varios turnos. Ctrl o Shift suman filas.", "Asignar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                foreach (var turno in turnos)
                    _turnoRepository.AsignarProfesional(turno.Id, profesionalId);
                EjecutarBusqueda();
                MessageBox.Show($"Se asignaron {turnos.Count} turno(s).", "Asignar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Asignar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EjecutarBusqueda();
            }
        }
    }
}
