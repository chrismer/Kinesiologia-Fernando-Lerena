using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace TESTSOLAPAS;

/// <summary>Página 2 – Agenda / Calendario General, sin dependencia de base de datos.</summary>
public partial class AgendaForm : Form
{
    private readonly List<TurnoAgenda> _turnos = new();

    public AgendaForm()
    {
        InitializeComponent();
        CargarTurnosDeEjemplo();
        dtpDesde.Value = DateTime.Today.AddDays(-7);
        dtpHasta.Value = DateTime.Today.AddDays(31);
    }

    private void Pagina2_Load(object? sender, EventArgs e) => ActualizarAgenda();

    private void FiltroCambiado(object? sender, EventArgs e) => ActualizarAgenda();

    private void Calendario_DateSelected(object? sender, DateRangeEventArgs e) => ActualizarAgenda();

    private void VistaCambiada(object? sender, EventArgs e)
    {
        if (sender is RadioButton opcion && opcion.Checked) ActualizarAgenda();
    }

    private void btnLimpiar_Click(object? sender, EventArgs e)
    {
        dtpDesde.Value = DateTime.Today.AddDays(-7);
        dtpHasta.Value = DateTime.Today.AddDays(31);
        cmbProfesional.SelectedIndex = 0;
        cmbEspecialidad.SelectedIndex = 0;
        ActualizarAgenda();
    }

    private void grillaAgenda_CellClick(object? sender, DataGridViewCellEventArgs e) =>
        btnVerCita.Enabled = e.RowIndex >= 0 && grillaAgenda.CurrentCell?.Tag is TurnoAgenda;

    private void ActualizarAgenda()
    {
        if (!IsHandleCreated || dtpDesde.Value.Date > dtpHasta.Value.Date) return;
        if (rdbMes.Checked) CargarVistaMes();
        else if (rdbDia.Checked) CargarVistaDia();
        else CargarVistaSemana();
        btnVerCita.Enabled = false;
    }

    private IEnumerable<TurnoAgenda> TurnosFiltrados() => _turnos.Where(t =>
        t.FechaHora.Date >= dtpDesde.Value.Date && t.FechaHora.Date <= dtpHasta.Value.Date &&
        (cmbProfesional.SelectedIndex == 0 || t.Profesional == cmbProfesional.Text) &&
        (cmbEspecialidad.SelectedIndex == 0 || t.Especialidad == cmbEspecialidad.Text));

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
        List<TurnoAgenda> turnos = TurnosFiltrados().Where(t => dias.Contains(t.FechaHora.Date)).ToList();
        for (int hora = 8; hora <= 18; hora++)
        {
            int fila = grillaAgenda.Rows.Add($"{hora:00}:00");
            grillaAgenda.Rows[fila].Height = 42;
            foreach (TurnoAgenda turno in turnos.Where(t => t.FechaHora.Hour == hora))
                PintarTurno(grillaAgenda.Rows[fila].Cells[Array.IndexOf(dias, turno.FechaHora.Date) + 1], turno);
        }
        lblResumen.Text = $"{turnos.Count} turnos en la semana";
    }

    private void CargarVistaDia()
    {
        lblVistaActual.Text = "Agenda diaria";
        DateTime dia = calendario.SelectionStart.Date;
        PrepararColumnas("Hora", dia.ToString("dddd dd 'de' MMMM", new CultureInfo("es-AR")));
        List<TurnoAgenda> turnos = TurnosFiltrados().Where(t => t.FechaHora.Date == dia).ToList();
        for (int hora = 8; hora <= 18; hora++)
        {
            int fila = grillaAgenda.Rows.Add($"{hora:00}:00");
            grillaAgenda.Rows[fila].Height = 42;
            TurnoAgenda? turno = turnos.FirstOrDefault(t => t.FechaHora.Hour == hora);
            if (turno is not null) PintarTurno(grillaAgenda.Rows[fila].Cells[1], turno);
        }
        lblResumen.Text = $"{turnos.Count} turnos el día seleccionado";
    }

    private void CargarVistaMes()
    {
        lblVistaActual.Text = "Agenda mensual / Saturación";
        DateTime primerDia = new(calendario.SelectionStart.Year, calendario.SelectionStart.Month, 1);
        DateTime inicio = InicioSemana(primerDia);
        PrepararColumnas("Semana", "Lun", "Mar", "Mié", "Jue", "Vie", "Sáb", "Dom");
        List<TurnoAgenda> turnos = TurnosFiltrados().Where(t => t.FechaHora.Month == primerDia.Month && t.FechaHora.Year == primerDia.Year).ToList();
        for (int semana = 0; semana < 6; semana++)
        {
            DateTime lunes = inicio.AddDays(semana * 7);
            if (lunes.Month != primerDia.Month && lunes.AddDays(6).Month != primerDia.Month) continue;
            int fila = grillaAgenda.Rows.Add($"Sem. {semana + 1}");
            grillaAgenda.Rows[fila].Height = 52;
            for (int dia = 0; dia < 7; dia++)
            {
                DateTime fecha = lunes.AddDays(dia);
                int cantidad = turnos.Count(t => t.FechaHora.Date == fecha);
                DataGridViewCell celda = grillaAgenda.Rows[fila].Cells[dia + 1];
                celda.Value = fecha.Month == primerDia.Month ? $"{fecha:dd}\n{cantidad} turno(s)" : string.Empty;
                if (fecha.Month == primerDia.Month) PintarSaturacion(celda, cantidad);
            }
        }
        lblResumen.Text = $"{turnos.Count} turnos en {primerDia.ToString("MMMM yyyy", new CultureInfo("es-AR"))}";
    }

    private static DateTime InicioSemana(DateTime fecha) => fecha.Date.AddDays(-((int)fecha.DayOfWeek + 6) % 7);

    private static void PintarTurno(DataGridViewCell celda, TurnoAgenda turno)
    {
        celda.Value = $"{turno.Paciente}\n{turno.Especialidad}";
        celda.Tag = turno;
        celda.ToolTipText = $"{turno.FechaHora:dd/MM HH:mm} · {turno.Profesional} · {turno.Estado}";
        celda.Style.BackColor = turno.Estado == "En curso" ? Color.FromArgb(0, 122, 204) : Color.ForestGreen;
        celda.Style.ForeColor = Color.White;
        celda.Style.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
    }

    private static void PintarSaturacion(DataGridViewCell celda, int cantidad)
    {
        celda.Style.BackColor = cantidad switch { 0 => Color.WhiteSmoke, 1 => Color.FromArgb(198, 224, 180), 2 => Color.FromArgb(112, 173, 71), _ => Color.FromArgb(56, 118, 29) };
        celda.Style.ForeColor = cantidad >= 2 ? Color.White : Color.FromArgb(0, 0, 64);
        celda.ToolTipText = cantidad == 0 ? "Sin turnos" : $"{cantidad} turno(s) programado(s)";
    }

    private void btnVerCita_Click(object? sender, EventArgs e)
    {
        if (grillaAgenda.CurrentCell?.Tag is not TurnoAgenda turno) return;
        MessageBox.Show($"Paciente: {turno.Paciente}\nFecha: {turno.FechaHora:dddd dd/MM HH:mm}\nProfesional: {turno.Profesional}\nEspecialidad: {turno.Especialidad}\nEstado: {turno.Estado}", "Detalle de la cita", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void CargarTurnosDeEjemplo()
    {
        DateTime lunes = InicioSemana(DateTime.Today);
        _turnos.AddRange(new[]
        {
            new TurnoAgenda(lunes.AddHours(8), "María Gómez", "Dr. Juan Pérez", "Rehabilitación Lumbar", "Confirmado"),
            new TurnoAgenda(lunes.AddHours(10), "Carlos Fernández", "Lic. Ana Torres", "Fisioterapia", "Confirmado"),
            new TurnoAgenda(lunes.AddDays(1).AddHours(9), "Sofía Ramírez", "Dr. Juan Pérez", "Rehabilitación Lumbar", "Confirmado"),
            new TurnoAgenda(lunes.AddDays(1).AddHours(11), "Lucas Díaz", "Lic. Martín López", "Kinesiología Deportiva", "En curso"),
            new TurnoAgenda(lunes.AddDays(2).AddHours(8), "Valentina Suárez", "Dr. Juan Pérez", "Rehabilitación Lumbar", "Confirmado"),
            new TurnoAgenda(lunes.AddDays(2).AddHours(10), "Tomás Molina", "Lic. Ana Torres", "Fisioterapia", "En curso"),
            new TurnoAgenda(lunes.AddDays(3).AddHours(9), "Elena Castro", "Lic. Martín López", "Kinesiología Deportiva", "Confirmado"),
            new TurnoAgenda(lunes.AddDays(3).AddHours(11), "Pedro Acosta", "Dr. Juan Pérez", "Rehabilitación Lumbar", "Confirmado"),
            new TurnoAgenda(lunes.AddDays(4).AddHours(8), "Julieta Vega", "Lic. Ana Torres", "Fisioterapia", "Confirmado"),
            new TurnoAgenda(lunes.AddDays(4).AddHours(10), "Bruno Silva", "Dr. Juan Pérez", "Rehabilitación Lumbar", "Confirmado")
        });
    }

    private sealed record TurnoAgenda(DateTime FechaHora, string Paciente, string Profesional, string Especialidad, string Estado);
}
