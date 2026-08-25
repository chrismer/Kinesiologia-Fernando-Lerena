namespace TESTSOLAPAS
{
    partial class Pagina3
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            tableLayoutMain = new TableLayoutPanel();
            panelHeader = new Panel();
            lblTitulo = new Label();
            lblNombre = new Label();
            lblDniEdad = new Label();
            lblCobertura = new Label();
            lblMotivo = new Label();
            lblDiagnostico = new Label();
            lblEstado = new Label();
            tableLayoutBody = new TableLayoutPanel();
            panelHistorial = new Panel();
            lblTituloHistorial = new Label();
            gridHistorial = new DataGridView();
            colFecha = new DataGridViewTextBoxColumn();
            colProfesional = new DataGridViewTextBoxColumn();
            colEva = new DataGridViewTextBoxColumn();
            colEvolucion = new DataGridViewTextBoxColumn();
            panelEvolucion = new Panel();
            lblTituloEvolucion = new Label();
            lblEva = new Label();
            numEva = new NumericUpDown();
            lblEvaValor = new Label();
            lblTecnicas = new Label();
            chkMagnetoterapia = new CheckBox();
            chkUltrasonido = new CheckBox();
            chkTerapiaManual = new CheckBox();
            chkEjercicio = new CheckBox();
            lblComentarios = new Label();
            txtComentarios = new TextBox();
            btnGuardar = new Button();
            tableLayoutMain.SuspendLayout();
            panelHeader.SuspendLayout();
            tableLayoutBody.SuspendLayout();
            panelHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridHistorial).BeginInit();
            panelEvolucion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numEva).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutMain
            // 
            tableLayoutMain.ColumnCount = 1;
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutMain.Controls.Add(panelHeader, 0, 0);
            tableLayoutMain.Controls.Add(tableLayoutBody, 0, 1);
            tableLayoutMain.Dock = DockStyle.Fill;
            tableLayoutMain.Location = new Point(0, 0);
            tableLayoutMain.Name = "tableLayoutMain";
            tableLayoutMain.RowCount = 2;
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 130F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutMain.Size = new Size(1100, 620);
            tableLayoutMain.TabIndex = 0;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.SteelBlue;
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Controls.Add(lblNombre);
            panelHeader.Controls.Add(lblDniEdad);
            panelHeader.Controls.Add(lblCobertura);
            panelHeader.Controls.Add(lblMotivo);
            panelHeader.Controls.Add(lblDiagnostico);
            panelHeader.Controls.Add(lblEstado);
            panelHeader.Dock = DockStyle.Fill;
            panelHeader.Location = new Point(3, 3);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(20, 12, 20, 12);
            panelHeader.Size = new Size(1094, 124);
            panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 10F);
            lblTitulo.ForeColor = Color.SkyBlue;
            lblTitulo.Location = new Point(20, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(104, 19);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Consulta Activa";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblNombre.ForeColor = Color.White;
            lblNombre.Location = new Point(20, 30);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(265, 30);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "— Cargando paciente —";
            // 
            // lblDniEdad
            // 
            lblDniEdad.AutoSize = true;
            lblDniEdad.Font = new Font("Segoe UI", 9.5F);
            lblDniEdad.ForeColor = Color.LightGray;
            lblDniEdad.Location = new Point(20, 60);
            lblDniEdad.Name = "lblDniEdad";
            lblDniEdad.Size = new Size(0, 17);
            lblDniEdad.TabIndex = 2;
            // 
            // lblCobertura
            // 
            lblCobertura.AutoSize = true;
            lblCobertura.Font = new Font("Segoe UI", 9.5F);
            lblCobertura.ForeColor = Color.LightGray;
            lblCobertura.Location = new Point(20, 78);
            lblCobertura.Name = "lblCobertura";
            lblCobertura.Size = new Size(0, 17);
            lblCobertura.TabIndex = 3;
            // 
            // lblMotivo
            // 
            lblMotivo.AutoSize = true;
            lblMotivo.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblMotivo.ForeColor = Color.LightYellow;
            lblMotivo.Location = new Point(20, 97);
            lblMotivo.Name = "lblMotivo";
            lblMotivo.Size = new Size(0, 17);
            lblMotivo.TabIndex = 4;
            // 
            // lblDiagnostico
            // 
            lblDiagnostico.AutoSize = true;
            lblDiagnostico.Font = new Font("Segoe UI", 9F);
            lblDiagnostico.ForeColor = Color.LightGray;
            lblDiagnostico.Location = new Point(500, 60);
            lblDiagnostico.Name = "lblDiagnostico";
            lblDiagnostico.Size = new Size(0, 15);
            lblDiagnostico.TabIndex = 5;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.BackColor = Color.FromArgb(0, 160, 80);
            lblEstado.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblEstado.ForeColor = Color.White;
            lblEstado.Location = new Point(500, 30);
            lblEstado.Name = "lblEstado";
            lblEstado.Padding = new Padding(6, 3, 6, 3);
            lblEstado.Size = new Size(95, 21);
            lblEstado.TabIndex = 6;
            lblEstado.Text = "EN ATENCION";
            // 
            // tableLayoutBody
            // 
            tableLayoutBody.ColumnCount = 2;
            tableLayoutBody.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            tableLayoutBody.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            tableLayoutBody.Controls.Add(panelHistorial, 0, 0);
            tableLayoutBody.Controls.Add(panelEvolucion, 1, 0);
            tableLayoutBody.Dock = DockStyle.Fill;
            tableLayoutBody.Location = new Point(3, 133);
            tableLayoutBody.Name = "tableLayoutBody";
            tableLayoutBody.RowCount = 1;
            tableLayoutBody.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutBody.Size = new Size(1094, 484);
            tableLayoutBody.TabIndex = 1;
            // 
            // panelHistorial
            // 
            panelHistorial.BackColor = SystemColors.Control;
            panelHistorial.Controls.Add(lblTituloHistorial);
            panelHistorial.Controls.Add(gridHistorial);
            panelHistorial.Dock = DockStyle.Fill;
            panelHistorial.Location = new Point(3, 3);
            panelHistorial.Name = "panelHistorial";
            panelHistorial.Padding = new Padding(12);
            panelHistorial.Size = new Size(595, 478);
            panelHistorial.TabIndex = 0;
            // 
            // lblTituloHistorial
            // 
            lblTituloHistorial.Dock = DockStyle.Top;
            lblTituloHistorial.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTituloHistorial.ForeColor = Color.FromArgb(0, 0, 64);
            lblTituloHistorial.Location = new Point(12, 12);
            lblTituloHistorial.Name = "lblTituloHistorial";
            lblTituloHistorial.Size = new Size(571, 30);
            lblTituloHistorial.TabIndex = 0;
            lblTituloHistorial.Text = "Historial de Sesiones";
            // 
            // gridHistorial
            // 
            gridHistorial.AllowUserToAddRows = false;
            gridHistorial.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 242, 252);
            gridHistorial.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            gridHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridHistorial.BackgroundColor = SystemColors.Control;
            gridHistorial.BorderStyle = BorderStyle.None;
            gridHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridHistorial.Columns.AddRange(new DataGridViewColumn[] { colFecha, colProfesional, colEva, colEvolucion });
            gridHistorial.Dock = DockStyle.Fill;
            gridHistorial.Font = new Font("Segoe UI", 9F);
            gridHistorial.GridColor = Color.FromArgb(210, 220, 235);
            gridHistorial.Location = new Point(12, 12);
            gridHistorial.MultiSelect = false;
            gridHistorial.Name = "gridHistorial";
            gridHistorial.ReadOnly = true;
            gridHistorial.RowHeadersVisible = false;
            gridHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridHistorial.Size = new Size(571, 454);
            gridHistorial.TabIndex = 1;
            // 
            // colFecha
            // 
            colFecha.FillWeight = 18F;
            colFecha.HeaderText = "Fecha";
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            // 
            // colProfesional
            // 
            colProfesional.FillWeight = 22F;
            colProfesional.HeaderText = "Profesional";
            colProfesional.Name = "colProfesional";
            colProfesional.ReadOnly = true;
            // 
            // colEva
            // 
            colEva.FillWeight = 12F;
            colEva.HeaderText = "Dolor EVA";
            colEva.Name = "colEva";
            colEva.ReadOnly = true;
            // 
            // colEvolucion
            // 
            colEvolucion.FillWeight = 48F;
            colEvolucion.HeaderText = "Evolucion / Resumen";
            colEvolucion.Name = "colEvolucion";
            colEvolucion.ReadOnly = true;
            // 
            // panelEvolucion
            // 
            panelEvolucion.BackColor = Color.FromArgb(248, 249, 252);
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
            panelEvolucion.Dock = DockStyle.Fill;
            panelEvolucion.Location = new Point(604, 3);
            panelEvolucion.Name = "panelEvolucion";
            panelEvolucion.Padding = new Padding(12);
            panelEvolucion.Size = new Size(487, 478);
            panelEvolucion.TabIndex = 1;
            // 
            // lblTituloEvolucion
            // 
            lblTituloEvolucion.AutoSize = true;
            lblTituloEvolucion.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTituloEvolucion.ForeColor = Color.FromArgb(0, 0, 64);
            lblTituloEvolucion.Location = new Point(12, 12);
            lblTituloEvolucion.Name = "lblTituloEvolucion";
            lblTituloEvolucion.Size = new Size(197, 20);
            lblTituloEvolucion.TabIndex = 0;
            lblTituloEvolucion.Text = "Registrar Evolución de Hoy";
            // 
            // lblEva
            // 
            lblEva.AutoSize = true;
            lblEva.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblEva.ForeColor = Color.FromArgb(40, 40, 80);
            lblEva.Location = new Point(12, 52);
            lblEva.Name = "lblEva";
            lblEva.Size = new Size(170, 17);
            lblEva.TabIndex = 1;
            lblEva.Text = "Nivel de Dolor (EVA 0-10):";
            // 
            // numEva
            // 
            numEva.Font = new Font("Segoe UI", 11F);
            numEva.Location = new Point(12, 74);
            numEva.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numEva.Name = "numEva";
            numEva.Size = new Size(60, 27);
            numEva.TabIndex = 2;
            numEva.ValueChanged += numEva_ValueChanged;
            // 
            // lblEvaValor
            // 
            lblEvaValor.AutoSize = true;
            lblEvaValor.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblEvaValor.ForeColor = Color.DimGray;
            lblEvaValor.Location = new Point(82, 78);
            lblEvaValor.Name = "lblEvaValor";
            lblEvaValor.Size = new Size(52, 15);
            lblEvaValor.TabIndex = 3;
            lblEvaValor.Text = "Sin dolor";
            // 
            // lblTecnicas
            // 
            lblTecnicas.AutoSize = true;
            lblTecnicas.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblTecnicas.ForeColor = Color.FromArgb(40, 40, 80);
            lblTecnicas.Location = new Point(12, 112);
            lblTecnicas.Name = "lblTecnicas";
            lblTecnicas.Size = new Size(124, 17);
            lblTecnicas.TabIndex = 4;
            lblTecnicas.Text = "Técnicas aplicadas:";
            // 
            // chkMagnetoterapia
            // 
            chkMagnetoterapia.Location = new Point(0, 0);
            chkMagnetoterapia.Name = "chkMagnetoterapia";
            chkMagnetoterapia.Size = new Size(104, 24);
            chkMagnetoterapia.TabIndex = 5;
            // 
            // chkUltrasonido
            // 
            chkUltrasonido.Location = new Point(0, 0);
            chkUltrasonido.Name = "chkUltrasonido";
            chkUltrasonido.Size = new Size(104, 24);
            chkUltrasonido.TabIndex = 6;
            // 
            // chkTerapiaManual
            // 
            chkTerapiaManual.Location = new Point(0, 0);
            chkTerapiaManual.Name = "chkTerapiaManual";
            chkTerapiaManual.Size = new Size(104, 24);
            chkTerapiaManual.TabIndex = 7;
            // 
            // chkEjercicio
            // 
            chkEjercicio.Location = new Point(0, 0);
            chkEjercicio.Name = "chkEjercicio";
            chkEjercicio.Size = new Size(104, 24);
            chkEjercicio.TabIndex = 8;
            // 
            // lblComentarios
            // 
            lblComentarios.AutoSize = true;
            lblComentarios.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblComentarios.ForeColor = Color.FromArgb(40, 40, 80);
            lblComentarios.Location = new Point(12, 200);
            lblComentarios.Name = "lblComentarios";
            lblComentarios.Size = new Size(199, 17);
            lblComentarios.TabIndex = 9;
            lblComentarios.Text = "Evolución / Notas de la sesión:";
            // 
            // txtComentarios
            // 
            txtComentarios.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtComentarios.BorderStyle = BorderStyle.FixedSingle;
            txtComentarios.Font = new Font("Segoe UI", 10F);
            txtComentarios.Location = new Point(12, 224);
            txtComentarios.Multiline = true;
            txtComentarios.Name = "txtComentarios";
            txtComentarios.ScrollBars = ScrollBars.Vertical;
            txtComentarios.Size = new Size(667, 160);
            txtComentarios.TabIndex = 10;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnGuardar.BackColor = Color.FromArgb(0, 122, 204);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(12, 778);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(200, 44);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar Evolución";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // Pagina3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 620);
            Controls.Add(tableLayoutMain);
            Name = "Pagina3";
            Text = "Consulta Activa";
            Load += Pagina3_Load;
            tableLayoutMain.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            tableLayoutBody.ResumeLayout(false);
            panelHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridHistorial).EndInit();
            panelEvolucion.ResumeLayout(false);
            panelEvolucion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numEva).EndInit();
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
