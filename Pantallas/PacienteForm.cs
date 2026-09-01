using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TESTSOLAPAS
{
    /// <summary>
    /// Pantalla 3 – Módulo de Atención y Comentarios ("Consulta Activa").
    /// Muestra la ficha del paciente en atención, el historial de sus sesiones anteriores
    /// y permite registrar la evolución de la sesión actual.
    /// 
    /// Uso desde Inicio.cs:
    ///   var p = new Pagina3(_evolucionRepository.ObtenerPacienteDemo(), _evolucionRepository);
    ///   AbrirFormularioEnPanel(p);
    /// </summary>
    public partial class PacienteForm : Form
    {
        private readonly Paciente _paciente;
        private readonly IEvolucionRepository _repository;

        // ── Constructor ──────────────────────────────────────────────

        /// <summary>
        /// Crea la pantalla con el paciente y repositorio inyectados desde Inicio.cs.
        /// El repositorio se mantiene vivo en Inicio (campo de clase) para que los datos
        /// persistan al navegar entre pantallas.
        /// </summary>
        public PacienteForm(Paciente paciente, IEvolucionRepository repository)
        {
            InitializeComponent();

            // Si el paciente llega nulo (ej. vista previa del diseñador) usamos uno de prueba
            _repository = repository ?? new MemoryEvolucionRepository();
            _paciente   = paciente   ?? (_repository as MemoryEvolucionRepository)?.ObtenerPacienteDemo() 
                                     ?? new Paciente 
                                     { 
                                         Id = 1, 
                                         NombreCompleto = "María Gómez Blanía", 
                                         Dni = "12378738", 
                                         Edad = 34, 
                                         Cobertura = "OSDE 210", 
                                         MotivoConsulta = "Dolor lumbar", 
                                         DiagnosticoInicial = "Lumbalgia crónica" 
                                     };
        }

        // ── Carga inicial ────────────────────────────────────────────

        private void Pagina3_Load(object sender, EventArgs e)
        {
            CargarDatosPaciente();
            CargarHistorial();
        }

        /// <summary>Rellena las etiquetas del header con los datos del paciente.</summary>
        private void CargarDatosPaciente()
        {
            lblNombre.Text      = _paciente.NombreCompleto;
            lblDniEdad.Text     = $"DNI: {_paciente.Dni}   |   Edad: {_paciente.Edad} años";
            lblCobertura.Text   = $"Cobertura: {_paciente.Cobertura}";
            lblMotivo.Text      = $"Motivo: {_paciente.MotivoConsulta}";
            lblDiagnostico.Text = $"Diagnóstico: {_paciente.DiagnosticoInicial}";
        }

        // ── Historial de Sesiones ────────────────────────────────────

        /// <summary>
        /// Limpia y recarga el DataGridView con el historial del paciente actual.
        /// Se llama al cargar la pantalla y después de cada guardado exitoso.
        /// </summary>
        private void CargarHistorial()
        {
            gridHistorial.Rows.Clear();

            List<EvolucionSesion> historial = _repository.ObtenerHistorialPorPaciente(_paciente.Id);

            foreach (var sesion in historial)
            {
                string tecnicas = string.IsNullOrWhiteSpace(sesion.TecnicasAplicadas)
                    ? "—"
                    : sesion.TecnicasAplicadas;

                // Truncamos el comentario para que no desborde la celda
                string resumen = sesion.ComentariosEvolucion.Length > 80
                    ? sesion.ComentariosEvolucion.Substring(0, 77) + "..."
                    : sesion.ComentariosEvolucion;

                gridHistorial.Rows.Add(
                    sesion.Fecha.ToString("dd/MM/yyyy"),
                    sesion.Profesional,
                    $"{sesion.NivelDolorEva}/10",
                    resumen
                );
            }
        }

        // ── Selector EVA ─────────────────────────────────────────────

        private void numEva_ValueChanged(object sender, EventArgs e)
        {
            int valor = (int)numEva.Value;
            lblEvaValor.Text = valor switch
            {
                0 => "Sin dolor",
                1 or 2 or 3 => "Dolor leve",
                4 or 5 or 6 => "Dolor moderado",
                7 or 8 => "Dolor intenso",
                _ => "Dolor insoportable"
            };

            lblEvaValor.ForeColor = valor switch
            {
                0 => Color.DimGray,
                1 or 2 or 3 => Color.Green,
                4 or 5 or 6 => Color.DarkOrange,
                _ => Color.Crimson
            };
        }

        // ── Guardar Evolución ────────────────────────────────────────

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación: el campo de comentarios no puede estar vacío
            if (string.IsNullOrWhiteSpace(txtComentarios.Text))
            {
                MessageBox.Show(
                    "Por favor, ingrese las notas de evolución de la sesión antes de guardar.",
                    "Campo requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtComentarios.Focus();
                return;
            }

            // Armar lista de técnicas seleccionadas
            var tecnicas = new List<string>();
            if (chkMagnetoterapia.Checked) tecnicas.Add("Magnetoterapia");
            if (chkUltrasonido.Checked)    tecnicas.Add("Ultrasonido");
            if (chkTerapiaManual.Checked)  tecnicas.Add("Terapia Manual");
            if (chkEjercicio.Checked)      tecnicas.Add("Ejercicio Terapeutico");

            // Crear y persistir la evolución
            var nuevaEvolucion = new EvolucionSesion
            {
                PacienteId           = _paciente.Id,
                Fecha                = DateTime.Now,
                Profesional          = "Dr. Juan Pérez",   // TODO: reemplazar con el usuario logueado
                NivelDolorEva        = (int)numEva.Value,
                TecnicasAplicadas    = string.Join(", ", tecnicas),
                ComentariosEvolucion = txtComentarios.Text.Trim()
            };

            _repository.GuardarEvolucion(nuevaEvolucion);

            // Actualizar el historial en pantalla
            CargarHistorial();

            // Limpiar el formulario de nueva evolución
            LimpiarFormularioEvolucion();

            MessageBox.Show(
                "La evolución fue guardada correctamente.",
                "Guardado exitoso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        /// <summary>Resetea los controles del panel de registro tras un guardado exitoso.</summary>
        private void LimpiarFormularioEvolucion()
        {
            txtComentarios.Clear();
            numEva.Value          = 0;
            chkMagnetoterapia.Checked = false;
            chkUltrasonido.Checked    = false;
            chkTerapiaManual.Checked  = false;
            chkEjercicio.Checked      = false;
        }
    }
}
