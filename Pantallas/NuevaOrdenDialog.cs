using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TESTSOLAPAS
{
    /// <summary>
    /// Crea una orden y un turno por sesión, de lunes a viernes, a la misma hora.
    /// Cada turno nace con el kinesiólogo de esa franja (o la excepción de ese día).
    /// </summary>
    public class NuevaOrdenDialog : Form
    {
        private readonly IPacienteRepository _pacientes;
        private readonly IFranjaRepository _franjas;
        private readonly ITurnoRepository _turnos;

        private ComboBox _cmbPaciente = null!;
        private NumericUpDown _numSesiones = null!;
        private DateTimePicker _dtpInicio = null!;
        private DateTimePicker _dtpHora = null!;
        private TextBox _txtMedico = null!;
        private TextBox _txtDiagnostico = null!;

        public NuevaOrdenDialog(IPacienteRepository pacientes, IFranjaRepository franjas, ITurnoRepository turnos)
        {
            _pacientes = pacientes;
            _franjas = franjas;
            _turnos = turnos;
            BuildUi();
            CargarPacientes();
        }

        private void BuildUi()
        {
            Text = "Nueva orden";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(480, 420);
            MinimizeBox = false;
            MaximizeBox = false;
            Font = new Font("Segoe UI", 9.5F);

            var header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 64,
                BackColor = Color.FromArgb(0, 0, 64),
                Padding = new Padding(16, 12, 16, 8)
            };
            header.Controls.Add(new Label
            {
                Text = "Orden y turnos",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(16, 8)
            });
            header.Controls.Add(new Label
            {
                Text = "Días hábiles, misma hora. El finde no se agenda.",
                ForeColor = Color.LightGray,
                AutoSize = true,
                Location = new Point(16, 36)
            });

            var cuerpo = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(16, 12, 16, 8),
                ColumnCount = 2,
                RowCount = 6
            };
            cuerpo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
            cuerpo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            _cmbPaciente = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Dock = DockStyle.Fill };
            _numSesiones = new NumericUpDown { Minimum = 1, Maximum = 40, Value = 10, Dock = DockStyle.Left, Width = 80 };
            _dtpInicio = new DateTimePicker { Format = DateTimePickerFormat.Short, Dock = DockStyle.Left, Width = 140 };
            _dtpHora = new DateTimePicker
            {
                Format = DateTimePickerFormat.Time,
                ShowUpDown = true,
                Dock = DockStyle.Left,
                Width = 100,
                Value = DateTime.Today.AddHours(8)
            };
            _txtMedico = new TextBox { Dock = DockStyle.Fill };
            _txtDiagnostico = new TextBox { Dock = DockStyle.Fill };

            AgregarFila(cuerpo, 0, "Paciente", _cmbPaciente);
            AgregarFila(cuerpo, 1, "Sesiones", _numSesiones);
            AgregarFila(cuerpo, 2, "Desde", _dtpInicio);
            AgregarFila(cuerpo, 3, "Hora", _dtpHora);
            AgregarFila(cuerpo, 4, "Médico", _txtMedico);
            AgregarFila(cuerpo, 5, "Diagnóstico", _txtDiagnostico);

            var pie = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                Height = 56,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(12, 8, 12, 8)
            };
            var btnCrear = new Button
            {
                Text = "Crear turnos",
                DialogResult = DialogResult.None,
                BackColor = Color.FromArgb(0, 122, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(130, 34)
            };
            btnCrear.FlatAppearance.BorderSize = 0;
            btnCrear.Click += (_, _) => Crear();

            var btnCancelar = new Button { Text = "Cancelar", DialogResult = DialogResult.Cancel, Size = new Size(100, 34) };
            pie.Controls.Add(btnCrear);
            pie.Controls.Add(btnCancelar);

            Controls.Add(cuerpo);
            Controls.Add(pie);
            Controls.Add(header);
            AcceptButton = btnCrear;
            CancelButton = btnCancelar;
        }

        private static void AgregarFila(TableLayoutPanel tabla, int fila, string etiqueta, Control campo)
        {
            tabla.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            tabla.Controls.Add(new Label
            {
                Text = etiqueta,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill
            }, 0, fila);
            tabla.Controls.Add(campo, 1, fila);
        }

        private void CargarPacientes()
        {
            _cmbPaciente.DisplayMember = nameof(Paciente.NombreCompleto);
            foreach (var paciente in _pacientes.ObtenerTodos().OrderBy(p => p.NombreCompleto))
                _cmbPaciente.Items.Add(paciente);

            if (_cmbPaciente.Items.Count > 0)
                _cmbPaciente.SelectedIndex = 0;
        }

        private void Crear()
        {
            if (_cmbPaciente.SelectedItem is not Paciente paciente)
            {
                MessageBox.Show("Elegí un paciente.", "Nueva orden", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sesiones = (int)_numSesiones.Value;
            var hora = _dtpHora.Value.TimeOfDay;
            var fechas = FranjaCalendario.DiasHabiles(_dtpInicio.Value, sesiones);
            var generados = fechas.Select(fecha =>
            {
                var asignacion = _franjas.ResolverProfesional(fecha, hora);
                return new TurnoGenerado
                {
                    Fecha = fecha,
                    ProfesionalId = asignacion.ProfesionalId,
                    ProfesionalNombre = asignacion.ProfesionalNombre,
                    ProfesionalColor = asignacion.ProfesionalColor
                };
            }).ToList();

            var datos = new NuevaOrdenTurnos
            {
                PacienteId = paciente.Id,
                PacienteNombre = paciente.NombreCompleto,
                PacienteDni = paciente.Dni,
                Cobertura = paciente.Cobertura,
                Medico = _txtMedico.Text.Trim(),
                Diagnostico = _txtDiagnostico.Text.Trim(),
                Hora = hora
            };

            try
            {
                _turnos.CrearOrdenConTurnos(datos, generados);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo crear la orden.\n" + ex.Message, "Nueva orden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var primero = generados[0];
            MessageBox.Show(
                $"Se crearon {generados.Count} turnos.\nEl primero es el {primero.Fecha:dd/MM/yyyy} a las {hora:hh\\:mm}, con {primero.ProfesionalNombre}.",
                "Nueva orden",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
