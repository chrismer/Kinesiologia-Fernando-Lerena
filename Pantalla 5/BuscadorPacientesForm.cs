using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TESTSOLAPAS.Pantalla_5
{
    public partial class BuscadorPacientesForm : Form
    {
        private PacienteRepository repo;
        public BuscadorPacientesForm()
        {
            InitializeComponent();
            repo = new PacienteRepository();
        }

        private void btnBusquedaPacientes_Click_1(object sender, EventArgs e)
        {
            {
                string criterio = txtBoxcuadroBusquedaPacientes.Text;
                var resultados = repo.Buscar(criterio);
                dtvBusquedaDePacientes.DataSource = resultados;
            }
        }
    }
}
