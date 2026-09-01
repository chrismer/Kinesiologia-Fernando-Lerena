namespace TESTSOLAPAS
{
    partial class PacienteForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // ── Controles ──────────────────────────────────────────
            tableLayoutMain    = new System.Windows.Forms.TableLayoutPanel();
            panelHeader        = new System.Windows.Forms.Panel();
            lblTitulo          = new System.Windows.Forms.Label();
            lblNombre          = new System.Windows.Forms.Label();
            lblDniEdad         = new System.Windows.Forms.Label();
            lblCobertura       = new System.Windows.Forms.Label();
            lblMotivo          = new System.Windows.Forms.Label();
            lblDiagnostico     = new System.Windows.Forms.Label();
            lblEstado          = new System.Windows.Forms.Label();

            tableLayoutBody    = new System.Windows.Forms.TableLayoutPanel();

            // Historial
            panelHistorial     = new System.Windows.Forms.Panel();
            lblTituloHistorial = new System.Windows.Forms.Label();
            gridHistorial      = new System.Windows.Forms.DataGridView();
            colFecha           = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colProfesional     = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colEva             = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colEvolucion       = new System.Windows.Forms.DataGridViewTextBoxColumn();

            // Nueva evolución
            panelEvolucion     = new System.Windows.Forms.Panel();
            lblTituloEvolucion = new System.Windows.Forms.Label();
            lblEva             = new System.Windows.Forms.Label();
            numEva             = new System.Windows.Forms.NumericUpDown();
            lblEvaValor        = new System.Windows.Forms.Label();
            lblTecnicas        = new System.Windows.Forms.Label();
            chkMagnetoterapia  = new System.Windows.Forms.CheckBox();
            chkUltrasonido     = new System.Windows.Forms.CheckBox();
            chkTerapiaManual   = new System.Windows.Forms.CheckBox();
            chkEjercicio       = new System.Windows.Forms.CheckBox();
            lblComentarios     = new System.Windows.Forms.Label();
            txtComentarios     = new System.Windows.Forms.TextBox();
            btnGuardar         = new System.Windows.Forms.Button();

            tableLayoutMain.SuspendLayout();
            panelHeader.SuspendLayout();
            tableLayoutBody.SuspendLayout();
            panelHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridHistorial).BeginInit();
            panelEvolucion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numEva).BeginInit();
            SuspendLayout();

            // ── tableLayoutMain (Ficha arriba / Cuerpo abajo) ──────
            tableLayoutMain.Dock        = System.Windows.Forms.DockStyle.Fill;
            tableLayoutMain.RowCount    = 2;
            tableLayoutMain.ColumnCount = 1;
            tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutMain.Controls.Add(panelHeader,    0, 0);
            tableLayoutMain.Controls.Add(tableLayoutBody,0, 1);

            // ── panelHeader – Ficha del Paciente ───────────────────
            panelHeader.Dock      = System.Windows.Forms.DockStyle.Fill;
            panelHeader.BackColor = System.Drawing.Color.FromArgb(0, 0, 64);
            panelHeader.Padding   = new System.Windows.Forms.Padding(20, 12, 20, 12);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Controls.Add(lblNombre);
            panelHeader.Controls.Add(lblDniEdad);
            panelHeader.Controls.Add(lblCobertura);
            panelHeader.Controls.Add(lblMotivo);
            panelHeader.Controls.Add(lblDiagnostico);
            panelHeader.Controls.Add(lblEstado);

            lblTitulo.Text      = "Consulta Activa";
            lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            lblTitulo.ForeColor = System.Drawing.Color.SkyBlue;
            lblTitulo.Location  = new System.Drawing.Point(20, 10);
            lblTitulo.AutoSize  = true;

            lblNombre.Text      = "— Cargando paciente —";
            lblNombre.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblNombre.ForeColor = System.Drawing.Color.White;
            lblNombre.Location  = new System.Drawing.Point(20, 30);
            lblNombre.AutoSize  = true;

            lblDniEdad.Text      = "";
            lblDniEdad.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            lblDniEdad.ForeColor = System.Drawing.Color.LightGray;
            lblDniEdad.Location  = new System.Drawing.Point(20, 60);
            lblDniEdad.AutoSize  = true;

            lblCobertura.Text      = "";
            lblCobertura.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            lblCobertura.ForeColor = System.Drawing.Color.LightGray;
            lblCobertura.Location  = new System.Drawing.Point(20, 78);
            lblCobertura.AutoSize  = true;

            lblMotivo.Text      = "";
            lblMotivo.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            lblMotivo.ForeColor = System.Drawing.Color.LightYellow;
            lblMotivo.Location  = new System.Drawing.Point(20, 97);
            lblMotivo.AutoSize  = true;

            lblDiagnostico.Text      = "";
            lblDiagnostico.Font      = new System.Drawing.Font("Segoe UI", 9F);
            lblDiagnostico.ForeColor = System.Drawing.Color.LightGray;
            lblDiagnostico.Location  = new System.Drawing.Point(500, 60);
            lblDiagnostico.AutoSize  = true;

            lblEstado.Text      = "EN ATENCION";
            lblEstado.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            lblEstado.ForeColor = System.Drawing.Color.White;
            lblEstado.BackColor = System.Drawing.Color.FromArgb(0, 160, 80);
            lblEstado.Location  = new System.Drawing.Point(500, 30);
            lblEstado.AutoSize  = true;
            lblEstado.Padding   = new System.Windows.Forms.Padding(6, 3, 6, 3);

            // ── tableLayoutBody (Historial | Nueva Evolución) ──────
            tableLayoutBody.Dock        = System.Windows.Forms.DockStyle.Fill;
            tableLayoutBody.RowCount    = 1;
            tableLayoutBody.ColumnCount = 2;
            tableLayoutBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            tableLayoutBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            tableLayoutBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutBody.Controls.Add(panelHistorial,  0, 0);
            tableLayoutBody.Controls.Add(panelEvolucion,  1, 0);

            // ── panelHistorial ─────────────────────────────────────
            panelHistorial.Dock      = System.Windows.Forms.DockStyle.Fill;
            panelHistorial.Padding   = new System.Windows.Forms.Padding(12);
            panelHistorial.BackColor = System.Drawing.SystemColors.Control;
            panelHistorial.Controls.Add(lblTituloHistorial);
            panelHistorial.Controls.Add(gridHistorial);

            lblTituloHistorial.Text     = "Historial de Sesiones";
            lblTituloHistorial.Font     = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblTituloHistorial.ForeColor = System.Drawing.Color.FromArgb(0, 0, 64);
            lblTituloHistorial.Dock     = System.Windows.Forms.DockStyle.Top;
            lblTituloHistorial.Height   = 30;

            gridHistorial.Dock                          = System.Windows.Forms.DockStyle.Fill;
            gridHistorial.ReadOnly                      = true;
            gridHistorial.AllowUserToAddRows            = false;
            gridHistorial.AllowUserToDeleteRows         = false;
            gridHistorial.AllowUserToOrderColumns       = false;
            gridHistorial.SelectionMode                 = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            gridHistorial.MultiSelect                   = false;
            gridHistorial.RowHeadersVisible             = false;
            gridHistorial.AutoSizeColumnsMode           = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            gridHistorial.ColumnHeadersHeightSizeMode   = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridHistorial.Font                          = new System.Drawing.Font("Segoe UI", 9F);
            gridHistorial.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(235, 242, 252);
            gridHistorial.GridColor                     = System.Drawing.Color.FromArgb(210, 220, 235);
            gridHistorial.BackgroundColor               = System.Drawing.SystemColors.Control;
            gridHistorial.BorderStyle                   = System.Windows.Forms.BorderStyle.None;
            gridHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colFecha, colProfesional, colEva, colEvolucion });

            colFecha.HeaderText     = "Fecha";
            colFecha.Name           = "colFecha";
            colFecha.FillWeight     = 18;
            colFecha.ReadOnly       = true;

            colProfesional.HeaderText = "Profesional";
            colProfesional.Name       = "colProfesional";
            colProfesional.FillWeight = 22;
            colProfesional.ReadOnly   = true;

            colEva.HeaderText     = "Dolor EVA";
            colEva.Name           = "colEva";
            colEva.FillWeight     = 12;
            colEva.ReadOnly       = true;

            colEvolucion.HeaderText = "Evolucion / Resumen";
            colEvolucion.Name       = "colEvolucion";
            colEvolucion.FillWeight = 48;
            colEvolucion.ReadOnly   = true;

            // ── panelEvolucion ─────────────────────────────────────
            panelEvolucion.Dock        = System.Windows.Forms.DockStyle.Fill;
            panelEvolucion.Padding     = new System.Windows.Forms.Padding(12);
            panelEvolucion.BackColor   = System.Drawing.Color.FromArgb(248, 249, 252);
            panelEvolucion.AutoScroll  = true;
            panelEvolucion.Controls.Add(lblTituloEvolucion);
            panelEvolucion.Controls.Add(lblEva);
            panelEvolucion.Controls.Add(numEva);
            panelEvolucion.Controls.Add(lblEvaValor);
            panelEvolucion.Controls.Add(lblTecnicas);
            panelEvolucion.Controls.Add(chkMagnetoterapia);
            panelEvolucion.Controls.Add(chkUltrasonido);
            panelEvolucion.Controls.Add(chkTerapiaManual);
            panelEvolucion.Controls.Add(chkEjercicio);
            panelEvolucion.Controls.Add(lblComentarios);
            panelEvolucion.Controls.Add(txtComentarios);
            panelEvolucion.Controls.Add(btnGuardar);

            lblTituloEvolucion.Text      = "Registrar Evolución de Hoy";
            lblTituloEvolucion.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblTituloEvolucion.ForeColor = System.Drawing.Color.FromArgb(0, 0, 64);
            lblTituloEvolucion.Location  = new System.Drawing.Point(12, 12);
            lblTituloEvolucion.AutoSize  = true;

            lblEva.Text      = "Nivel de Dolor (EVA 0-10):";
            lblEva.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblEva.ForeColor = System.Drawing.Color.FromArgb(40, 40, 80);
            lblEva.Location  = new System.Drawing.Point(12, 45);
            lblEva.AutoSize  = true;

            numEva.Location  = new System.Drawing.Point(12, 68);
            numEva.Minimum   = 0;
            numEva.Maximum   = 10;
            numEva.Value     = 0;
            numEva.Width     = 60;
            numEva.Font      = new System.Drawing.Font("Segoe UI", 11F);
            numEva.ValueChanged += numEva_ValueChanged;

            lblEvaValor.Text      = "Sin dolor";
            lblEvaValor.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            lblEvaValor.ForeColor = System.Drawing.Color.DimGray;
            lblEvaValor.Location  = new System.Drawing.Point(82, 72);
            lblEvaValor.AutoSize  = true;

            lblTecnicas.Text      = "Técnicas aplicadas:";
            lblTecnicas.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblTecnicas.ForeColor = System.Drawing.Color.FromArgb(40, 40, 80);
            lblTecnicas.Location  = new System.Drawing.Point(12, 102);
            lblTecnicas.AutoSize  = true;

            int chkX = 12, chkY = 124;
            ConfigurarCheckBox(chkMagnetoterapia, "Magnetoterapia",        chkX,       chkY);
            ConfigurarCheckBox(chkUltrasonido,    "Ultrasonido",           chkX + 160, chkY);
            ConfigurarCheckBox(chkTerapiaManual,  "Terapia Manual",        chkX,       chkY + 26);
            ConfigurarCheckBox(chkEjercicio,      "Ejercicio Terapéutico", chkX + 160, chkY + 26);

            lblComentarios.Text      = "Evolución / Notas de la sesión:";
            lblComentarios.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblComentarios.ForeColor = System.Drawing.Color.FromArgb(40, 40, 80);
            lblComentarios.Location  = new System.Drawing.Point(12, 185);
            lblComentarios.AutoSize  = true;

            txtComentarios.Location    = new System.Drawing.Point(12, 208);
            txtComentarios.Multiline   = true;
            txtComentarios.ScrollBars  = System.Windows.Forms.ScrollBars.Vertical;
            txtComentarios.Font        = new System.Drawing.Font("Segoe UI", 10F);
            txtComentarios.Size        = new System.Drawing.Size(380, 130);
            txtComentarios.Anchor      = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtComentarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            btnGuardar.Text      = "Guardar Evolución";
            btnGuardar.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnGuardar.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            btnGuardar.ForeColor = System.Drawing.Color.White;
            btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Size      = new System.Drawing.Size(200, 42);
            btnGuardar.Location  = new System.Drawing.Point(12, 350);
            btnGuardar.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            btnGuardar.Cursor    = System.Windows.Forms.Cursors.Hand;
            btnGuardar.Click    += btnGuardar_Click;

            // ── Formulario ─────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize          = new System.Drawing.Size(1100, 620);
            Controls.Add(tableLayoutMain);
            Name = "Pagina3";
            Text = "Consulta Activa";
            Load += Pagina3_Load;

            ((System.ComponentModel.ISupportInitialize)numEva).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridHistorial).EndInit();
            panelEvolucion.ResumeLayout(false);
            panelEvolucion.PerformLayout();
            panelHistorial.ResumeLayout(false);
            tableLayoutBody.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            tableLayoutMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        private static void ConfigurarCheckBox(System.Windows.Forms.CheckBox chk, string texto, int x, int y)
        {
            chk.Text      = texto;
            chk.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            chk.ForeColor = System.Drawing.Color.FromArgb(40, 40, 80);
            chk.Location  = new System.Drawing.Point(x, y);
            chk.AutoSize  = true;
        }

        #endregion

        // ── Controles declarados ───────────────────────────────────
        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.Panel            panelHeader;
        private System.Windows.Forms.Label            lblTitulo;
        private System.Windows.Forms.Label            lblNombre;
        private System.Windows.Forms.Label            lblDniEdad;
        private System.Windows.Forms.Label            lblCobertura;
        private System.Windows.Forms.Label            lblMotivo;
        private System.Windows.Forms.Label            lblDiagnostico;
        private System.Windows.Forms.Label            lblEstado;

        private System.Windows.Forms.TableLayoutPanel tableLayoutBody;

        private System.Windows.Forms.Panel            panelHistorial;
        private System.Windows.Forms.Label            lblTituloHistorial;
        private System.Windows.Forms.DataGridView     gridHistorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProfesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEva;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEvolucion;

        private System.Windows.Forms.Panel            panelEvolucion;
        private System.Windows.Forms.Label            lblTituloEvolucion;
        private System.Windows.Forms.Label            lblEva;
        private System.Windows.Forms.NumericUpDown    numEva;
        private System.Windows.Forms.Label            lblEvaValor;
        private System.Windows.Forms.Label            lblTecnicas;
        private System.Windows.Forms.CheckBox         chkMagnetoterapia;
        private System.Windows.Forms.CheckBox         chkUltrasonido;
        private System.Windows.Forms.CheckBox         chkTerapiaManual;
        private System.Windows.Forms.CheckBox         chkEjercicio;
        private System.Windows.Forms.Label            lblComentarios;
        private System.Windows.Forms.TextBox          txtComentarios;
        private System.Windows.Forms.Button           btnGuardar;
    }
}
