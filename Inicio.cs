using System;
using System.Drawing;
using System.Windows.Forms;

namespace TESTSOLAPAS
{
    public partial class Inicio : Form
    {
        /// <summary>
        /// Instancia única del repositorio de evoluciones que vive durante toda la sesión.
        /// Se inyecta en Pagina3 cada vez que se abre para que los datos no se pierdan
        /// al navegar entre pantallas. Cuando se integre la base de datos, solo se cambia
        /// esta línea por la implementación concreta de IEvolucionRepository.
        /// </summary>
        private readonly IEvolucionRepository _evolucionRepository = new MemoryEvolucionRepository();

        public Inicio()
        {
            InitializeComponent();
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
        }

        // ── Helper de Navegación ─────────────────────────────────────

        /// <summary>
        /// Incrusta cualquier formulario secundario dentro de panelMain.
        /// Centraliza la lógica que antes estaba duplicada en button5_Click y btnConfig_Click.
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
                btn.Font      = new Font("Segoe UI", 10, FontStyle.Bold);
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
            pictureBox2.Region   = new Region(path);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        // ── Eventos de clic de botones del menú ──────────────────────

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            MarcarBotonActivo(btnDashboard);
            // TODO: AbrirFormularioEnPanel(new Dashboard());
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            MarcarBotonActivo(btnPacientes);
            var paciente = _evolucionRepository.ObtenerPacienteDemo();
            AbrirFormularioEnPanel(new Pagina3(paciente, _evolucionRepository));
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            MarcarBotonActivo(btnConfig);
            AbrirFormularioEnPanel(new Pagina5());
        }

        // ── Eventos de controles de cabecera ─────────────────────────

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
