using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicaWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // El TabControl ocupa toda la pantalla
            tabControl1.Dock = DockStyle.Fill;

            // Tamaño fijo de las solapas
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.ItemSize = new Size(120, 40); // ancho = 120, alto = 40

            // Activar dibujo personalizado
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.DrawItem += TabControl1_DrawItem;

            // Mostrar Form2 en la primera pestaña
            Form2 frm2 = new Form2();
            frm2.TopLevel = false;
            frm2.FormBorderStyle = FormBorderStyle.None;
            frm2.Dock = DockStyle.Fill;
            tabControl1.TabPages[0].Controls.Add(frm2);
            frm2.Show();

            // Mostrar Form3 en la segunda pestaña
            Form3 frm3 = new Form3();
            frm3.TopLevel = false;
            frm3.FormBorderStyle = FormBorderStyle.None;
            frm3.Dock = DockStyle.Fill;
            tabControl1.TabPages[1].Controls.Add(frm3);
            frm3.Show();

            // Mostrar Form3 en la segunda pestaña
            Form4 frm4 = new Form4();
            frm4.TopLevel = false;
            frm4.FormBorderStyle = FormBorderStyle.None;
            frm4.Dock = DockStyle.Fill;
            tabControl1.TabPages[2].Controls.Add(frm4);
            frm4.Show();
        }

        private void TabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage page = tabControl1.TabPages[e.Index];
            Font f = new Font("Segoe UI", 10, FontStyle.Bold);
            Color textColor = Color.Blue;

            // Fondo de la solapa
            e.Graphics.FillRectangle(SystemBrushes.Control, e.Bounds);

            // Texto centrado
            TextRenderer.DrawText(e.Graphics, page.Text, f, e.Bounds, textColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}


