using System.Windows.Forms;

namespace ClinicaWinForms
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            // Control simple para probar
            Label lbl = new Label();
            lbl.Text = "Contenido de Form3";
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.Controls.Add(lbl);
        }
    }
}
