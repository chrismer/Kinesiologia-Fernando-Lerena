using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaWinForms
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

            // Esto hace que las pestañas se vuelvan invisibles
            tabControltest.Appearance = TabAppearance.Buttons;
            tabControltest.ItemSize = new Size(0, 1);
            tabControltest.SizeMode = TabSizeMode.Fixed;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            tabControltest.SelectedIndex = 0; // Muestra la primera pestaña
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            tabControltest.SelectedIndex = 1; // Muestra la primera pestaña

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            tabControltest.SelectedIndex = 1; // Muestra la primera pestaña
        }
    }
}
