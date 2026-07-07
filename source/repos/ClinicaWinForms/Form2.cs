using System.Windows.Forms;

namespace ClinicaWinForms
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            // Control simple para probar
            Label lbl = new Label();
            lbl.Text = "Contenido de Form2";
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.Controls.Add(lbl);
        }
    }
}
