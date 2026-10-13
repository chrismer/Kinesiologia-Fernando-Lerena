using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TESTSOLAPAS
{
    /// <summary>
    /// Modal de alta de usuario (Configuración, solo admin).
    /// Valida los datos y guarda con IUsuarioRepository.
    ///
    /// DialogResult.OK     → el usuario se creó; el llamador recarga la grilla.
    /// DialogResult.Cancel → no se guardó nada.
    /// </summary>
    public class NuevoUsuarioDialog : Form
    {
        private static readonly Regex FormatoUsuario = new Regex("^[a-zA-Z0-9._-]{3,50}$");

        private readonly IUsuarioRepository _repository;

        private string _color = "#007ACC";
        private byte[]? _foto;

        // ── Controles ──────────────────────────────────────────────────
        private TextBox  txtUsuario   = null!;
        private TextBox  txtClave     = null!;
        private TextBox  txtRepetir   = null!;
        private ComboBox cmbRol       = null!;
        private TextBox  txtNombre    = null!;
        private Label    lblColor     = null!;
        private Button   btnColor     = null!;
        private PictureBox picFoto    = null!;
        private Button   btnFoto      = null!;
        private Button   btnQuitarFoto = null!;
        private Button   btnGuardar   = null!;
        private Button   btnCancelar  = null!;

        // ── Constructor ────────────────────────────────────────────────

        public NuevoUsuarioDialog(IUsuarioRepository repository)
        {
            _repository = repository;
            BuildUI();
            ActualizarSegunRol();
        }

        // ── Construcción de la UI ──────────────────────────────────────

        private void BuildUI()
        {
            Text            = "Crear Usuario";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition   = FormStartPosition.CenterParent;
            ClientSize      = new Size(560, 380);
            MinimizeBox     = false;
            MaximizeBox     = false;
            ShowInTaskbar   = false;
            Font            = new Font("Segoe UI", 10F);

            var tabla = new TableLayoutPanel
            {
                Location    = new Point(16, 16),
                Size        = new Size(340, 300),
                ColumnCount = 2,
                RowCount    = 6
            };
            tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            for (int i = 0; i < 6; i++)
                tabla.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));

            txtUsuario = new TextBox { Dock = DockStyle.Fill, MaxLength = 50 };
            txtClave   = new TextBox { Dock = DockStyle.Fill, PasswordChar = '*' };
            txtRepetir = new TextBox { Dock = DockStyle.Fill, PasswordChar = '*' };
            txtNombre  = new TextBox { Dock = DockStyle.Fill, MaxLength = 100, PlaceholderText = "Ej.: Lic. Laura Díaz" };

            cmbRol = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbRol.Items.AddRange(new object[] { "kinesiologo", "recepcion", "admin" });
            cmbRol.SelectedIndex = 0;
            cmbRol.SelectedIndexChanged += (_, _) => ActualizarSegunRol();

            var panelColor = new FlowLayoutPanel { Dock = DockStyle.Fill, Margin = Padding.Empty };
            lblColor = new Label { Size = new Size(28, 28), BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(3, 6, 6, 3) };
            btnColor = new Button { Text = "Elegir…", AutoSize = true };
            btnColor.Click += btnColor_Click;
            panelColor.Controls.Add(lblColor);
            panelColor.Controls.Add(btnColor);

            AgregarFila(tabla, 0, "Usuario",        txtUsuario);
            AgregarFila(tabla, 1, "Contraseña",     txtClave);
            AgregarFila(tabla, 2, "Repetir",        txtRepetir);
            AgregarFila(tabla, 3, "Rol",            cmbRol);
            AgregarFila(tabla, 4, "Nombre",         txtNombre);
            AgregarFila(tabla, 5, "Color agenda",   panelColor);

            // ── Foto ──────────────────────────────────────────────────
            var grpFoto = new GroupBox
            {
                Text     = "Foto de perfil",
                Location = new Point(372, 16),
                Size     = new Size(172, 300)
            };
            picFoto = new PictureBox
            {
                Location    = new Point(16, 30),
                Size        = new Size(140, 140),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode    = PictureBoxSizeMode.Zoom,
                BackColor   = Color.WhiteSmoke
            };
            btnFoto = new Button { Text = "Subir foto…", Location = new Point(16, 184), Size = new Size(140, 34) };
            btnFoto.Click += btnFoto_Click;
            btnQuitarFoto = new Button { Text = "Quitar", Location = new Point(16, 224), Size = new Size(140, 34), Enabled = false };
            btnQuitarFoto.Click += (_, _) => MostrarFoto(null);
            grpFoto.Controls.Add(picFoto);
            grpFoto.Controls.Add(btnFoto);
            grpFoto.Controls.Add(btnQuitarFoto);

            // ── Pie ───────────────────────────────────────────────────
            btnGuardar  = new Button { Text = "💾 Guardar", Size = new Size(120, 36), Location = new Point(292, 330) };
            btnCancelar = new Button { Text = "Cancelar",   Size = new Size(120, 36), Location = new Point(424, 330), DialogResult = DialogResult.Cancel };
            btnGuardar.Click += btnGuardar_Click;

            Controls.Add(tabla);
            Controls.Add(grpFoto);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);

            AcceptButton = btnGuardar;
            CancelButton = btnCancelar;

            PintarColor();
        }

        private static void AgregarFila(TableLayoutPanel tabla, int fila, string texto, Control control)
        {
            tabla.Controls.Add(new Label
            {
                Text      = texto,
                Dock      = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, fila);
            control.Margin = new Padding(3, 8, 3, 3);
            tabla.Controls.Add(control, 1, fila);
        }

        // ── Comportamiento ─────────────────────────────────────────────

        /// <summary>El color de agenda solo tiene sentido para un kinesiólogo.</summary>
        private void ActualizarSegunRol()
        {
            var esKine = (string?)cmbRol.SelectedItem == "kinesiologo";
            btnColor.Enabled = esKine;
            lblColor.Visible = esKine;
        }

        private void PintarColor() => lblColor.BackColor = ColorTranslator.FromHtml(_color);

        private void btnColor_Click(object? sender, EventArgs e)
        {
            using var dlg = new ColorDialog { Color = ColorTranslator.FromHtml(_color), FullOpen = true };
            if (dlg.ShowDialog(this) != DialogResult.OK)
                return;

            _color = $"#{dlg.Color.R:X2}{dlg.Color.G:X2}{dlg.Color.B:X2}";
            PintarColor();
        }

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
            picFoto.Image?.Dispose();
            picFoto.Image = FotoHelper.ABitmap(foto);
            btnQuitarFoto.Enabled = foto is not null;
        }

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            var error = Validar();
            if (error is not null)
            {
                MessageBox.Show(error, "Crear Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nuevo = new NuevoUsuario
            {
                Usuario = txtUsuario.Text.Trim(),
                Clave   = txtClave.Text,
                Rol     = (string)cmbRol.SelectedItem!,
                Nombre  = txtNombre.Text.Trim(),
                Color   = _color,
                Foto    = _foto
            };

            try
            {
                Cursor = Cursors.WaitCursor;
                _repository.Crear(nuevo);
            }
            catch (UsuarioDuplicadoException ex)
            {
                MessageBox.Show(ex.Message, "Crear Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el usuario.\n" + ex.Message,
                    "Crear Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            DialogResult = DialogResult.OK;
        }

        /// <summary>Devuelve el primer problema encontrado, o null si todo está bien.</summary>
        private string? Validar()
        {
            if (!FormatoUsuario.IsMatch(txtUsuario.Text.Trim()))
                return "El usuario debe tener entre 3 y 50 caracteres: letras, números, punto, guion o guion bajo, sin espacios.";
            if (txtClave.Text.Length < 6)
                return "La contraseña debe tener al menos 6 caracteres.";
            if (txtClave.Text != txtRepetir.Text)
                return "Las contraseñas no coinciden.";
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
                return "Completá el nombre. En kinesiólogos es el que aparece en la agenda.";
            return null;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                picFoto?.Image?.Dispose();
            base.Dispose(disposing);
        }
    }
}
