using System;
using System.Drawing;
using System.Windows.Forms;

namespace TESTSOLAPAS
{
    /// <summary>
    /// Modal para cambiar la foto de perfil y/o la clave de un usuario existente
    /// (Configuración, solo admin). Si la clave queda vacía, no se cambia.
    ///
    /// DialogResult.OK     → se guardó al menos un cambio.
    /// DialogResult.Cancel → no se guardó nada.
    /// </summary>
    public class EditarUsuarioDialog : Form
    {
        private readonly IUsuarioRepository _repository;
        private readonly UsuarioItem _usuario;

        private byte[]? _foto;

        /// <summary>True si se guardó una foto distinta (o se quitó).</summary>
        public bool FotoCambiada { get; private set; }

        // ── Controles ──────────────────────────────────────────────────
        private PictureBox picFoto       = null!;
        private Button     btnFoto       = null!;
        private Button     btnQuitarFoto = null!;
        private TextBox    txtClave      = null!;
        private TextBox    txtRepetir    = null!;
        private Button     btnGuardar    = null!;
        private Button     btnCancelar   = null!;

        private bool _fotoTocada;

        // ── Constructor ────────────────────────────────────────────────

        public EditarUsuarioDialog(IUsuarioRepository repository, UsuarioItem usuario, byte[]? fotoActual)
        {
            _repository = repository;
            _usuario = usuario;
            BuildUI();
            MostrarFoto(fotoActual);
            _fotoTocada = false;
        }

        // ── Construcción de la UI ──────────────────────────────────────

        private void BuildUI()
        {
            Text            = $"Foto y clave - {_usuario.Usuario}";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition   = FormStartPosition.CenterParent;
            ClientSize      = new Size(520, 300);
            MinimizeBox     = false;
            MaximizeBox     = false;
            ShowInTaskbar   = false;
            Font            = new Font("Segoe UI", 10F);

            var lblQuien = new Label
            {
                Text     = $"{_usuario.Nombre} ({_usuario.Rol})",
                Font     = new Font("Segoe UI", 11F, FontStyle.Bold),
                Location = new Point(16, 16),
                AutoSize = true
            };

            // ── Foto ──────────────────────────────────────────────────
            picFoto = new PictureBox
            {
                Location    = new Point(16, 52),
                Size        = new Size(140, 140),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode    = PictureBoxSizeMode.Zoom,
                BackColor   = Color.WhiteSmoke
            };
            btnFoto = new Button { Text = "Subir foto…", Location = new Point(16, 200), Size = new Size(140, 34) };
            btnFoto.Click += btnFoto_Click;
            btnQuitarFoto = new Button { Text = "Quitar", Location = new Point(16, 240), Size = new Size(140, 34) };
            btnQuitarFoto.Click += (_, _) => MostrarFoto(null);

            // ── Clave ─────────────────────────────────────────────────
            var grpClave = new GroupBox
            {
                Text     = "Clave nueva (dejar vacío para no cambiarla)",
                Location = new Point(176, 52),
                Size     = new Size(328, 140)
            };
            grpClave.Controls.Add(new Label { Text = "Clave",   Location = new Point(14, 40), AutoSize = true });
            grpClave.Controls.Add(new Label { Text = "Repetir", Location = new Point(14, 88), AutoSize = true });
            txtClave   = new TextBox { Location = new Point(100, 36), Size = new Size(210, 27), PasswordChar = '*' };
            txtRepetir = new TextBox { Location = new Point(100, 84), Size = new Size(210, 27), PasswordChar = '*' };
            grpClave.Controls.Add(txtClave);
            grpClave.Controls.Add(txtRepetir);

            // ── Pie ───────────────────────────────────────────────────
            btnGuardar  = new Button { Text = "💾 Guardar", Size = new Size(120, 36), Location = new Point(252, 248) };
            btnCancelar = new Button { Text = "Cancelar",   Size = new Size(120, 36), Location = new Point(384, 248), DialogResult = DialogResult.Cancel };
            btnGuardar.Click += btnGuardar_Click;

            Controls.Add(lblQuien);
            Controls.Add(picFoto);
            Controls.Add(btnFoto);
            Controls.Add(btnQuitarFoto);
            Controls.Add(grpClave);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);

            AcceptButton = btnGuardar;
            CancelButton = btnCancelar;
        }

        // ── Comportamiento ─────────────────────────────────────────────

        private void btnFoto_Click(object? sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Title  = "Elegir foto de perfil",
                Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            };
            if (dlg.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                MostrarFoto(FotoHelper.DesdeArchivo(dlg.FileName));
            }
            catch (Exception ex) when (ex is OutOfMemoryException or ArgumentException or System.IO.IOException)
            {
                // Image.FromFile tira OutOfMemoryException cuando el archivo no es una imagen válida.
                MessageBox.Show("No se pudo leer la imagen. Probá con un JPG o PNG.",
                    "Foto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MostrarFoto(byte[]? foto)
        {
            _foto = foto;
            _fotoTocada = true;
            picFoto.Image?.Dispose();
            picFoto.Image = FotoHelper.ABitmap(foto);
            btnQuitarFoto.Enabled = foto is not null;
        }

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            var cambiaClave = txtClave.Text.Length > 0 || txtRepetir.Text.Length > 0;

            if (cambiaClave && txtClave.Text.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres.",
                    "Foto y clave", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cambiaClave && txtClave.Text != txtRepetir.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.",
                    "Foto y clave", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!cambiaClave && !_fotoTocada)
            {
                DialogResult = DialogResult.Cancel;
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                if (_fotoTocada)
                {
                    _repository.CambiarFoto(_usuario.Id, _foto);
                    FotoCambiada = true;
                }
                if (cambiaClave)
                    _repository.CambiarClave(_usuario.Id, txtClave.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron guardar los cambios.\n" + ex.Message,
                    "Foto y clave", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            var hecho = cambiaClave && FotoCambiada ? "La foto y la clave se guardaron."
                      : cambiaClave                 ? "La clave se guardó."
                      :                               "La foto se guardó.";
            MessageBox.Show(hecho, "Foto y clave", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                picFoto?.Image?.Dispose();
            base.Dispose(disposing);
        }
    }
}
