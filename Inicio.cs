using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TESTSOLAPAS
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }




        private void button5_Click(object sender, EventArgs e)
        {


            // Crear instancia del formulario que querés mostrar
            Pagina5 pagina5 = new Pagina5();

            // Configurarlo para que se incruste en el panel
            pagina5.TopLevel = false;
            pagina5.FormBorderStyle = FormBorderStyle.None;
            pagina5.Dock = DockStyle.Fill;

            // Limpiar el panel y agregar el formulario
            panelMain.Controls.Clear();
            panelMain.Controls.Add(pagina5);

            // Mostrarlo
            pagina5.Show();
        }
        private void ResetearBotones()
        {
            btnDashboard.BackColor = Color.LightGray;
            btnPacientes.BackColor = Color.LightGray;
            btnTurnos.BackColor = Color.LightGray;
            btnAgenda.BackColor = Color.LightGray;

            btnDashboard.ForeColor = Color.Black;
            btnPacientes.ForeColor = Color.Black;
            btnTurnos.ForeColor = Color.Black;
            btnAgenda.ForeColor = Color.Black;

            btnDashboard.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            btnPacientes.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            btnTurnos.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            btnAgenda.Font = new Font("Segoe UI", 10, FontStyle.Regular);
        }


        private void Inicio_Load(object sender, EventArgs e)
        {

            // Crear una región circular del mismo tamaño que el PictureBox
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pictureBox2.Width, pictureBox2.Height);

            pictureBox2.Region = new Region(path);

            // Opcional: ajustar el SizeMode para que la imagen se vea bien
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnConfig_Click(object sender, EventArgs e)

        {
            // Mostrar la página 5 en el panel principal
            panelMain.Controls.Clear();
            Pagina5 pagina = new Pagina5();
            pagina.TopLevel = false;
            pagina.FormBorderStyle = FormBorderStyle.None;
            pagina.Dock = DockStyle.Fill;
            panelMain.Controls.Add(pagina);
            pagina.Show();

            // Cambiar estilo del botón activo
            btnConfig.BackColor = Color.FromArgb(0, 122, 204); // azul activo
            btnConfig.ForeColor = Color.White;
            btnConfig.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Resetear los demás botones
            ResetearBotones();



        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            // Cambiar estilo del botón activo
            btnDashboard.BackColor = Color.FromArgb(0, 122, 204); // azul activo
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Font = new Font("Segoe UI", 10, FontStyle.Bold);


        }
    }

}
