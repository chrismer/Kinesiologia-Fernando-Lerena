using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TESTSOLAPAS.Pantallas
{
    /// <summary>
    /// Pantalla de ingreso. Valida contra IAuthRepository y, si entra,
    /// deja la sesión en Sesion y cierra con DialogResult.OK.
    /// Cancelar (o cerrar la ventana) devuelve DialogResult.Cancel.
    /// </summary>
    public partial class LogIn : Form
    {
        private readonly IAuthRepository _auth;

        public SesionActual? Sesion { get; private set; }

        public LogIn(IAuthRepository auth)
        {
            InitializeComponent();
            _auth = auth;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            SesionActual? sesion;
            try
            {
                sesion = _auth.Validar(IdUsername.Text.Trim(), IdPassword.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar con la base de datos.\n" + ex.Message,
                    "Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (sesion is null)
            {
                MessageBox.Show("Usuario o clave incorrectos.",
                    "Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                IdPassword.Clear();
                IdPassword.Focus();
                return;
            }

            Sesion = sesion;
            DialogResult = DialogResult.OK;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }
    }
}