using System;
using System.Drawing;
using System.Windows.Forms;
using TESTSOLAPAS.Pantalla_5;

namespace TESTSOLAPAS
{
    public partial class Principal : Form
    {
        /// <summary>
        /// Repositorios que viven durante toda la sesión de la aplicación.
        /// Si hay appsettings.json configurado → usa PostgreSQL (Neon).
        /// Si no → usa los repositorios en memoria (desarrollo offline).
        /// </summary>
        private readonly IEvolucionRepository _evolucionRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly ITurnoRepository _turnoRepository;

        public Principal()
        {
            InitializeComponent();

            if (DbConnectionFactory.IsConfigured)
            {
                _evolucionRepository = new NpgsqlEvolucionRepository();
                _pacienteRepository  = new NpgsqlPacienteRepository();
                _turnoRepository     = new NpgsqlTurnoRepository();
            }
            else
            {
                var memRepo = new MemoryEvolucionRepository();
                _evolucionRepository = memRepo;
                _pacienteRepository  = new MemoryPacienteRepository(memRepo.ObtenerPacienteDemo());
                _turnoRepository     = new MemoryTurnoRepository();
            }
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
        }

        // ── Helper de Navegación ─────────────────────────────────────

        /// <summary>
        /// Incrusta cualquier formulario secundario dentro de panelMain.
        /// </summary>
        private void AbrirFormularioEnPanel(Form formulario)
        {
            panelMain.Controls.Clear();
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            panelMain.Controls.Add(formulario);
            formulario.Show();
        }

        // ── Estilo de botones del menú lateral ───────────────────────

        private void ResetearBotones()
        {
            Button[] botones = { btnDashboard, btnPacientes, btnTurnos, btnAgenda, btnConfig };

            foreach (var btn in botones)
            {
                btn.BackColor = SystemColors.ControlLight;
                btn.ForeColor = Color.FromArgb(0, 0, 64);
                btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            }
        }

        private void MarcarBotonActivo(Button boton)
        {
            ResetearBotones();
            boton.BackColor = Color.FromArgb(0, 122, 204);
            boton.ForeColor = Color.White;
        }

        // ── Eventos de carga ─────────────────────────────────────────

        private void Inicio_Load(object sender, EventArgs e)
        {
            // Recorte circular para la foto de perfil
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pictureBox2.Width, pictureBox2.Height);
            pictureBox2.Region = new Region(path);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

            // Abrir el Dashboard por defecto al iniciar
            btnDashboard_Click(this, EventArgs.Empty);
        }

        // ── Eventos de clic de botones del menú ──────────────────────

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            MarcarBotonActivo(btnDashboard);
            AbrirFormularioEnPanel(new DashBoard(_turnoRepository, _pacienteRepository, _evolucionRepository, AbrirFormularioEnPanel));
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            MarcarBotonActivo(btnPacientes);

            // Obtener el primer paciente disponible (demo o de la DB)
            var pacientes = _pacienteRepository.ObtenerTodos();
            var paciente = pacientes.Count > 0
                ? pacientes[0]
                : new Paciente { Id = 0, NombreCompleto = "Sin pacientes", Dni = "—" };

            AbrirFormularioEnPanel(new PacienteForm(paciente, _evolucionRepository));
        }

        private void btnTurnos_Click(object sender, EventArgs e)
        {
            MarcarBotonActivo(btnTurnos);
            AbrirFormularioEnPanel(new TurnosForm(_turnoRepository, _pacienteRepository, _evolucionRepository, AbrirFormularioEnPanel));
        }

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            MarcarBotonActivo(btnAgenda);
            AbrirFormularioEnPanel(new AgendaForm(_turnoRepository));
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            MarcarBotonActivo(btnConfig);
            AbrirFormularioEnPanel(new ConfiguracionForm());
        }
    }

    /// <summary>
    /// Implementación mínima de IPacienteRepository para desarrollo offline.
    /// Solo devuelve el paciente demo de MemoryEvolucionRepository.
    /// </summary>
    internal class MemoryPacienteRepository : IPacienteRepository
    {
        private readonly Paciente _pacienteDemo;

        public MemoryPacienteRepository(Paciente pacienteDemo)
        {
            _pacienteDemo = pacienteDemo;
        }

        public List<Paciente> ObtenerTodos() => new List<Paciente> { _pacienteDemo };
        public Paciente? ObtenerPorId(int pacienteId) => _pacienteDemo;
        public void Guardar(Paciente paciente) { /* no-op en memoria */ }
    }
}
