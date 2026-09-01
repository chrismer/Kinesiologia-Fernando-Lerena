using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace TESTSOLAPAS
{
    /// <summary>Agenda y Calendario General conectado a ITurnoRepository.</summary>
    public partial class AgendaForm : Form
    {
        private readonly ITurnoRepository _turnoRepository;
        private List<TurnoItem> _turnos = new();
        private List<ProfesionalItem> _profesionales = new();

        public AgendaForm(ITurnoRepository? turnoRepository = null)
        {
            InitializeComponent();
            _turnoRepository = turnoRepository ?? new MemoryTurnoRepository();

            dtpDesde.Value = DateTime.Today.AddDays(-7);
            dtpHasta.Value = DateTime.Today.AddDays(31);

            this.Load += AgendaForm_Load;
        }

        private void AgendaForm_Load(object? sender, EventArgs e)
        {
            CargarComboProfesionales();
            RecargarDatosDeBase();
        }

        private void CargarComboProfesionales()
        {
            cmbProfesional.Items.Clear();
            cmbProfesional.Items.Add("Todos");

            _profesionales = _turnoRepository.ObtenerProfesionales();
            foreach (var prof in _profesionales)
            {
                cmbProfesional.Items.Add(prof.Nombre);
            }

            cmbProfesional.SelectedIndex = 0;
        }

        private void RecargarDatosDeBase()
        {
            try
            {
                int? profId = null;
                if (cmbProfesional.SelectedIndex > 0)
                {
                    var seleccionado = _profesionales.FirstOrDefault(p => p.Nombre == cmbProfesional.Text);
                    if (seleccionado != null) profId = seleccionado.Id;
                }

                _turnos = _turnoRepository.ObtenerTurnosFiltrados(
                    dtpDesde.Value.Date,
                    dtpHasta.Value.Date,
                    profId,
                    null,
                    null
                );

                ActualizarAgenda();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la agenda: {ex.Message}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FiltroCambiado(object? sender, EventArgs e) => RecargarDatosDeBase();

        private void Calendario_DateSelected(object? sender, DateRangeEventArgs e) => ActualizarAgenda();

        private void VistaCambiada(object? sender, EventArgs e)
        {
            if (sender is RadioButton opcion && opcion.Checked) ActualizarAgenda();
        }

        private void btnLimpiar_Click(object? sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today.AddDays(-7);
            dtpHasta.Value = DateTime.Today.AddDays(31);
            if (cmbProfesional.Items.Count > 0) cmbProfesional.SelectedIndex = 0;
            if (cmbEspecialidad.Items.Count > 0) cmbEspecialidad.SelectedIndex = 0;
            RecargarDatosDeBase();
        }

        private void grillaAgenda_CellClick(object? sender, DataGridViewCellEventArgs e) =>
            btnVerCita.Enabled = e.RowIndex >= 0 && grillaAgenda.CurrentCell?.Tag is TurnoItem;

        private void ActualizarAgenda()
        {
            if (!IsHandleCreated || dtpDesde.Value.Date > dtpHasta.Value.Date) return;
            if (rdbMes.Checked) CargarVistaMes();
            else if (rdbDia.Checked) CargarVistaDia();
            else CargarVistaSemana();
            btnVerCita.Enabled = false;
        }

        private IEnumerable<TurnoItem> TurnosFiltrados()
        {
            var filtrados = _turnos.Where(t =>
                t.Fecha.Date >= dtpDesde.Value.Date && t.Fecha.Date <= dtpHasta.Value.Date &&
                (cmbProfesional.SelectedIndex <= 0 || t.ProfesionalNombre == cmbProfesional.Text));

            if (cmbEspecialidad.SelectedIndex > 0 && cmbEspecialidad.Text != "Todas")
            {
                filtrados = filtrados.Where(t => t.Diagnostico.Contains(cmbEspecialidad.Text, StringComparison.OrdinalIgnoreCase));
            }

            return filtrados;
        }

        private void PrepararColumnas(params string[] encabezados)
        {
            grillaAgenda.Columns.Clear();
            grillaAgenda.Rows.Clear();
            foreach (string encabezado in encabezados)
                grillaAgenda.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = encabezado,
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });
            grillaAgenda.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            grillaAgenda.Columns[0].Width = 64;
        }

        private void CargarVistaSemana()
        {
            lblVistaActual.Text = "Agenda semanal";
            DateTime inicio = InicioSemana(calendario.SelectionStart);
            DateTime[] dias = Enumerable.Range(0, 5).Select(i => inicio.AddDays(i)).ToArray();
            PrepararColumnas(new[] { "Hora" }.Concat(dias.Select(d => d.ToString("dddd\ndd/MM", new CultureInfo("es-AR")))).ToArray());

            List<TurnoItem> turnos = TurnosFiltrados().Where(t => dias.Contains(t.Fecha.Date)).ToList();

            for (int hora = 8; hora <= 18; hora++)
            {
                int fila = grillaAgenda.Rows.Add($"{hora:00}:00");
                grillaAgenda.Rows[fila].Height = 44;
                foreach (TurnoItem turno in turnos.Where(t => t.Hora.Hours == hora))
                {
                    int diaIdx = Array.IndexOf(dias, turno.Fecha.Date);
                    if (diaIdx >= 0)
                    {
                        PintarTurno(grillaAgenda.Rows[fila].Cells[diaIdx + 1], turno);
                    }
                }
            }
            lblResumen.Text = $"{turnos.Count} turnos en la semana";
        }

        private void CargarVistaDia()
        {
            lblVistaActual.Text = "Agenda diaria";
            DateTime dia = calendario.SelectionStart.Date;
            PrepararColumnas("Hora", dia.ToString("dddd dd 'de' MMMM", new CultureInfo("es-AR")));

            List<TurnoItem> turnos = TurnosFiltrados().Where(t => t.Fecha.Date == dia).ToList();

            for (int hora = 8; hora <= 18; hora++)
            {
                int fila = grillaAgenda.Rows.Add($"{hora:00}:00");
                grillaAgenda.Rows[fila].Height = 44;
                TurnoItem? turno = turnos.FirstOrDefault(t => t.Hora.Hours == hora);
                if (turno is not null)
                {
                    PintarTurno(grillaAgenda.Rows[fila].Cells[1], turno);
                }
            }
            lblResumen.Text = $"{turnos.Count} turnos el día seleccionado";
        }

        private void CargarVistaMes()
        {
            lblVistaActual.Text = "Agenda mensual / Saturación";
            DateTime primerDia = new(calendario.SelectionStart.Year, calendario.SelectionStart.Month, 1);
            DateTime inicio = InicioSemana(primerDia);
            PrepararColumnas("Semana", "Lun", "Mar", "Mié", "Jue", "Vie", "Sáb", "Dom");

            List<TurnoItem> turnos = TurnosFiltrados().Where(t => t.Fecha.Month == primerDia.Month && t.Fecha.Year == primerDia.Year).ToList();

            for (int semana = 0; semana < 6; semana++)
            {
                DateTime lunes = inicio.AddDays(semana * 7);
                if (lunes.Month != primerDia.Month && lunes.AddDays(6).Month != primerDia.Month) continue;
                int fila = grillaAgenda.Rows.Add($"Sem. {semana + 1}");
                grillaAgenda.Rows[fila].Height = 52;
                for (int dia = 0; dia < 7; dia++)
                {
                    DateTime fecha = lunes.AddDays(dia);
                    int cantidad = turnos.Count(t => t.Fecha.Date == fecha);
                    DataGridViewCell celda = grillaAgenda.Rows[fila].Cells[dia + 1];
                    celda.Value = fecha.Month == primerDia.Month ? $"{fecha:dd}\n{cantidad} turno(s)" : string.Empty;
                    if (fecha.Month == primerDia.Month) PintarSaturacion(celda, cantidad);
                }
            }
            lblResumen.Text = $"{turnos.Count} turnos en {primerDia.ToString("MMMM yyyy", new CultureInfo("es-AR"))}";
        }

        private static DateTime InicioSemana(DateTime fecha) => fecha.Date.AddDays(-((int)fecha.DayOfWeek + 6) % 7);

        private static void PintarTurno(DataGridViewCell celda, TurnoItem turno)
        {
            celda.Value = $"{turno.PacienteNombre}\n{turno.Hora:hh\\:mm} - {turno.Diagnostico}";
            celda.Tag = turno;
            celda.ToolTipText = $"{turno.Fecha:dd/MM} {turno.Hora:hh\\:mm} · {turno.ProfesionalNombre} · {turno.Estado}";

            Color colorBase = Color.FromArgb(0, 122, 204);
            try
            {
                if (!string.IsNullOrEmpty(turno.ProfesionalColor))
                {
                    colorBase = ColorTranslator.FromHtml(turno.ProfesionalColor);
                }
            }
            catch { }

            celda.Style.BackColor = turno.Estado == "Atendido" ? Color.FromArgb(40, 167, 69) : colorBase;
            celda.Style.ForeColor = Color.White;
            celda.Style.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        }

        private static void PintarSaturacion(DataGridViewCell celda, int cantidad)
        {
            celda.Style.BackColor = cantidad switch
            {
                0 => Color.WhiteSmoke,
                1 => Color.FromArgb(198, 224, 180),
                2 => Color.FromArgb(112, 173, 71),
                _ => Color.FromArgb(56, 118, 29)
            };
            celda.Style.ForeColor = cantidad >= 2 ? Color.White : Color.FromArgb(0, 0, 64);
            celda.ToolTipText = cantidad == 0 ? "Sin turnos" : $"{cantidad} turno(s) programado(s)";
        }

        private void btnVerCita_Click(object? sender, EventArgs e)
        {
            if (grillaAgenda.CurrentCell?.Tag is not TurnoItem turno) return;
            MessageBox.Show(
                $"Paciente: {turno.PacienteNombre}\n" +
                $"DNI: {turno.PacienteDni}\n" +
                $"Fecha: {turno.Fecha:dddd dd/MM} a las {turno.Hora:hh\\:mm}\n" +
                $"Profesional: {turno.ProfesionalNombre}\n" +
                $"Diagnóstico / Motivo: {turno.Diagnostico}\n" +
                $"Estado: {turno.Estado}",
                "Detalle del Turno",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
