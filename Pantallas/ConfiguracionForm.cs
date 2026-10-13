namespace TESTSOLAPAS
{
    /// <summary>
    /// Configuración del sistema. Principal solo la muestra al rol admin.
    /// "Administración de Usuarios": lista, alta (con foto) y baja/alta lógica contra IUsuarioRepository.
    /// </summary>
    public partial class ConfiguracionForm : Form
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly int _usuarioActualId;

        public ConfiguracionForm(IUsuarioRepository usuarioRepository, int usuarioActualId)
        {
            InitializeComponent();
            _usuarioRepository = usuarioRepository;
            _usuarioActualId = usuarioActualId;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionChanged += (_, _) => ActualizarBotonBaja();

            button1.Click += btnCrearUsuario_Click;
            btnEditarUsuario.Click += btnEditarUsuario_Click;
            button3.Click += btnBajaActivar_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // ── Usuarios ──────────────────────────────────────────────────

        private void CargarUsuarios(int? seleccionarId = null)
        {
            List<UsuarioItem> usuarios;
            try
            {
                usuarios = _usuarioRepository.ObtenerTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los usuarios.\n" + ex.Message,
                    "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dataGridView1.Rows.Clear();
            foreach (var u in usuarios)
            {
                var i = dataGridView1.Rows.Add(u.Id, u.Usuario, u.Nombre, u.Activo ? u.Rol : $"{u.Rol} (inactivo)");
                var fila = dataGridView1.Rows[i];
                fila.Tag = u;
                if (!u.Activo)
                    fila.DefaultCellStyle.ForeColor = Color.Gray;
                if (u.Id == seleccionarId)
                    fila.Selected = true;
            }

            ActualizarBotonBaja();
        }

        private UsuarioItem? UsuarioSeleccionado =>
            dataGridView1.SelectedRows.Count > 0 ? dataGridView1.SelectedRows[0].Tag as UsuarioItem : null;

        /// <summary>El mismo botón da de baja o reactiva según la fila elegida.</summary>
        private void ActualizarBotonBaja()
        {
            var u = UsuarioSeleccionado;
            btnEditarUsuario.Enabled = u is not null;
            button3.Enabled = u is not null && u.Id != _usuarioActualId;
            button3.Text = u is { Activo: false } ? "✅👤 Reactivar" : "❌👤Baja / Desactivar";
        }

        private void btnCrearUsuario_Click(object? sender, EventArgs e)
        {
            using var dlg = new NuevoUsuarioDialog(_usuarioRepository);
            if (dlg.ShowDialog(this) == DialogResult.OK)
                CargarUsuarios();
        }

        private void btnEditarUsuario_Click(object? sender, EventArgs e)
        {
            var u = UsuarioSeleccionado;
            if (u is null)
                return;

            byte[]? fotoActual;
            try
            {
                fotoActual = _usuarioRepository.ObtenerFoto(u.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo leer el usuario.\n" + ex.Message,
                    "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using var dlg = new EditarUsuarioDialog(_usuarioRepository, u, fotoActual);
            if (dlg.ShowDialog(this) == DialogResult.OK && u.Id == _usuarioActualId && dlg.FotoCambiada)
                MessageBox.Show("Tu foto nueva se ve en el encabezado la próxima vez que entres.",
                    "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBajaActivar_Click(object? sender, EventArgs e)
        {
            var u = UsuarioSeleccionado;
            if (u is null)
                return;

            // El admin logueado no se puede dar de baja a sí mismo: se quedaría sin acceso.
            if (u.Id == _usuarioActualId)
                return;

            var activar = !u.Activo;
            var pregunta = activar
                ? $"¿Reactivar a \"{u.Usuario}\"? Va a poder volver a entrar."
                : $"¿Dar de baja a \"{u.Usuario}\"? No va a poder entrar. Sus turnos y evoluciones no se borran.";
            if (MessageBox.Show(pregunta, "Usuarios", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                _usuarioRepository.CambiarActivo(u.Id, activar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar el usuario.\n" + ex.Message,
                    "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CargarUsuarios(u.Id);
        }
    }
}
