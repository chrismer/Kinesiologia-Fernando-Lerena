using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TESTSOLAPAS
{
    public partial class DashBoard : Form
    {
        private readonly ITurnoRepository _turnoRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IEvolucionRepository _evolucionRepository;
        private readonly Action<Form>? _abrirEnPanel;

        private List<TurnoItem> _turnosHoy = new();

        public DashBoard(
            ITurnoRepository? turnoRepository = null,
            IPacienteRepository? pacienteRepository = null,
            IEvolucionRepository? evolucionRepository = null,
            Action<Form>? abrirEnPanel = null)
        {
            InitializeComponent();

            _turnoRepository     = turnoRepository     ?? new MemoryTurnoRepository();
            _pacienteRepository  = pacienteRepository  ?? new MemoryPacienteRepository(new Paciente { Id = 1, NombreCompleto = "María Gómez Blanía", Dni = "12378738" });
            _evolucionRepository = evolucionRepository ?? new MemoryEvolucionRepository();
            _abrirEnPanel        = abrirEnPanel;

            ConfigurarEstilosGrilla();
        }

        private void ConfigurarEstilosGrilla()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 244, 250);

            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;

            btnVerDetalles.Click += BtnVerDetalles_Click;
            btnMarcarLlegado.Click += BtnMarcarLlegado_Click;

            this.Load += DashBoard_Load;
        }

        private void DashBoard_Load(object? sender, EventArgs e)
        {
            CargarTurnosDeHoy();
        }

        public void CargarTurnosDeHoy()
        {
            try
            {
                _turnosHoy = _turnoRepository.ObtenerTurnosDelDia(DateTime.Today);
                PoblarGrilla();
                ActualizarMetricas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los turnos de hoy: {ex.Message}", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PoblarGrilla()
        {
            dataGridView1.Rows.Clear();

            foreach (var turno in _turnosHoy)
            {
                int rowIndex = dataGridView1.Rows.Add(
                    turno.Hora.ToString(@"hh\:mm"),
                    turno.PacienteNombre,
                    turno.Diagnostico,
                    turno.Estado,
                    turno.ProfesionalNombre
                );

                var row = dataGridView1.Rows[rowIndex];
                row.Tag = turno;

                // Estilos por estado
                var celdaEstado = row.Cells[3];
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
        }

        private void ActualizarMetricas()
        {
            int total = _turnosHoy.Count;
            int atendidos = _turnosHoy.Count(t => t.Estado == "Atendido");

            lblContadorPacientes.Text = $"{atendidos}/{total}";
            progressBar1.Maximum = Math.Max(total, 1);
            progressBar1.Value = Math.Min(atendidos, progressBar1.Maximum);

            var proximo = _turnosHoy.FirstOrDefault(t => t.Estado == "Pendiente" || t.Estado == "Presente");
            if (proximo != null)
            {
                lblTiempoProximoTurno.Text = $"{proximo.Hora:hh\\:mm} - {proximo.PacienteNombre}";
            }
            else
            {
                lblTiempoProximoTurno.Text = "No hay más turnos";
            }
        }

        private void DataGridView1_SelectionChanged(object? sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.Tag is TurnoItem turno)
            {
                btnMarcarLlegado.Text = turno.Presente ? "Desmarcar Llegada" : "Marcar Como Llegado";
                btnMarcarLlegado.BackColor = turno.Presente ? Color.FromArgb(220, 53, 69) : Color.FromArgb(40, 167, 69);
                btnMarcarLlegado.ForeColor = Color.White;
            }
        }

        private void BtnMarcarLlegado_Click(object? sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.Tag is not TurnoItem turno)
            {
                MessageBox.Show("Seleccione un turno de la grilla para marcar su llegada.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool nuevoEstado = !turno.Presente;
                _turnoRepository.MarcarPresente(turno.Id, nuevoEstado);
                CargarTurnosDeHoy();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la presencia: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnVerDetalles_Click(object? sender, EventArgs e)
        {
            AbrirAtencionTurnoSeleccionado();
        }

        private void DataGridView1_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                AbrirAtencionTurnoSeleccionado();
            }
        }

        private void AbrirAtencionTurnoSeleccionado()
        {
            if (dataGridView1.CurrentRow?.Tag is not TurnoItem turno) return;

            if (_abrirEnPanel == null)
            {
                MessageBox.Show($"Paciente: {turno.PacienteNombre}\nHorario: {turno.Hora:hh\\:mm}\nDiagnóstico: {turno.Diagnostico}\nEstado: {turno.Estado}", "Detalle de Turno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Obtener el paciente real o crear el modelo a partir de los datos del turno
            var paciente = _pacienteRepository.ObtenerPorId(turno.PacienteId) ?? new Paciente
            {
                Id = turno.PacienteId,
                NombreCompleto = turno.PacienteNombre,
                Dni = turno.PacienteDni,
                Cobertura = turno.Cobertura,
                MotivoConsulta = turno.Nota,
                DiagnosticoInicial = turno.Diagnostico
            };

            // Abrir PacienteForm inyectándole el turnoId para que al guardar la evolución pase a "Atendido"
            _abrirEnPanel(new PacienteForm(paciente, _evolucionRepository, turno.Id));
        }
    }
}
