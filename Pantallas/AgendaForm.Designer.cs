namespace TESTSOLAPAS
{
    partial class AgendaForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelTitulo = null!;
        private Label lblTitulo = null!;
        private GroupBox grpFiltros = null!;
        private Label lblDesde = null!;
        private Label lblHasta = null!;
        private Label lblProfesional = null!;
        private Label lblEspecialidad = null!;
        private DateTimePicker dtpDesde = null!;
        private DateTimePicker dtpHasta = null!;
        private ComboBox cmbProfesional = null!;
        private ComboBox cmbEspecialidad = null!;
        private Button btnLimpiar = null!;
        private Panel panelLateral = null!;
        private MonthCalendar calendario = null!;
        private GroupBox grpVista = null!;
        private RadioButton rdbDia = null!;
        private RadioButton rdbSemana = null!;
        private RadioButton rdbMes = null!;
        private Label lblReferencias = null!;
        private Panel panelContenido = null!;
        private Panel panelEncabezadoAgenda = null!;
        private Label lblVistaActual = null!;
        private Label lblResumen = null!;
        private DataGridView grillaAgenda = null!;
        private Panel panelPie = null!;
        private Button btnVerCita = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panelTitulo = new Panel();
            lblTitulo = new Label();
            grpFiltros = new GroupBox();
            lblDesde = new Label();
            dtpDesde = new DateTimePicker();
            lblHasta = new Label();
            dtpHasta = new DateTimePicker();
            lblProfesional = new Label();
            cmbProfesional = new ComboBox();
            lblEspecialidad = new Label();
            cmbEspecialidad = new ComboBox();
            btnLimpiar = new Button();
            panelLateral = new Panel();
            lblReferencias = new Label();
            grpVista = new GroupBox();
            rdbDia = new RadioButton();
            rdbSemana = new RadioButton();
            rdbMes = new RadioButton();
            calendario = new MonthCalendar();
            panelContenido = new Panel();
            grillaAgenda = new DataGridView();
            panelPie = new Panel();
            btnVerCita = new Button();
            panelEncabezadoAgenda = new Panel();
            lblVistaActual = new Label();
            lblResumen = new Label();
            panelTitulo.SuspendLayout();
            grpFiltros.SuspendLayout();
            panelLateral.SuspendLayout();
            grpVista.SuspendLayout();
            panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grillaAgenda).BeginInit();
            panelPie.SuspendLayout();
            panelEncabezadoAgenda.SuspendLayout();
            SuspendLayout();
            // 
            // panelTitulo
            // 
            panelTitulo.BackColor = SystemColors.ButtonFace;
            panelTitulo.Controls.Add(lblTitulo);
            panelTitulo.Dock = DockStyle.Top;
            panelTitulo.Location = new Point(14, 14);
            panelTitulo.Name = "panelTitulo";
            panelTitulo.Size = new Size(1121, 62);
            panelTitulo.TabIndex = 3;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(0, 0, 64);
            lblTitulo.Location = new Point(0, 8);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(277, 45);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Agenda Completa";
            // 
            // grpFiltros
            // 
            grpFiltros.Controls.Add(lblDesde);
            grpFiltros.Controls.Add(dtpDesde);
            grpFiltros.Controls.Add(lblHasta);
            grpFiltros.Controls.Add(dtpHasta);
            grpFiltros.Controls.Add(lblProfesional);
            grpFiltros.Controls.Add(cmbProfesional);
            grpFiltros.Controls.Add(lblEspecialidad);
            grpFiltros.Controls.Add(cmbEspecialidad);
            grpFiltros.Controls.Add(btnLimpiar);
            grpFiltros.Dock = DockStyle.Top;
            grpFiltros.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpFiltros.Location = new Point(14, 76);
            grpFiltros.Name = "grpFiltros";
            grpFiltros.Size = new Size(1121, 86);
            grpFiltros.TabIndex = 2;
            grpFiltros.TabStop = false;
            grpFiltros.Text = "Filtros de agenda";
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Font = new Font("Segoe UI", 8.5F);
            lblDesde.Location = new Point(15, 27);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(39, 15);
            lblDesde.TabIndex = 0;
            lblDesde.Text = "Desde";
            // 
            // dtpDesde
            // 
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(15, 46);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(115, 25);
            dtpDesde.TabIndex = 1;
            dtpDesde.ValueChanged += FiltroCambiado;
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Font = new Font("Segoe UI", 8.5F);
            lblHasta.Location = new Point(143, 27);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(37, 15);
            lblHasta.TabIndex = 2;
            lblHasta.Text = "Hasta";
            // 
            // dtpHasta
            // 
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(143, 46);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(115, 25);
            dtpHasta.TabIndex = 3;
            dtpHasta.ValueChanged += FiltroCambiado;
            // 
            // lblProfesional
            // 
            lblProfesional.AutoSize = true;
            lblProfesional.Font = new Font("Segoe UI", 8.5F);
            lblProfesional.Location = new Point(271, 27);
            lblProfesional.Name = "lblProfesional";
            lblProfesional.Size = new Size(66, 15);
            lblProfesional.TabIndex = 4;
            lblProfesional.Text = "Profesional";
            // 
            // cmbProfesional
            // 
            cmbProfesional.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProfesional.FormattingEnabled = true;
            cmbProfesional.Items.AddRange(new object[] { "Todos", "Dr. Juan Pérez", "Lic. Ana Torres", "Lic. Martín López" });
            cmbProfesional.Location = new Point(271, 45);
            cmbProfesional.Name = "cmbProfesional";
            cmbProfesional.Size = new Size(173, 25);
            cmbProfesional.TabIndex = 5;
            cmbProfesional.SelectedIndexChanged += FiltroCambiado;
            // 
            // lblEspecialidad
            // 
            lblEspecialidad.AutoSize = true;
            lblEspecialidad.Font = new Font("Segoe UI", 8.5F);
            lblEspecialidad.Location = new Point(457, 27);
            lblEspecialidad.Name = "lblEspecialidad";
            lblEspecialidad.Size = new Size(72, 15);
            lblEspecialidad.TabIndex = 6;
            lblEspecialidad.Text = "Especialidad";
            // 
            // cmbEspecialidad
            // 
            cmbEspecialidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEspecialidad.FormattingEnabled = true;
            cmbEspecialidad.Items.AddRange(new object[] { "Todas", "Rehabilitación Lumbar", "Kinesiología Deportiva", "Fisioterapia" });
            cmbEspecialidad.Location = new Point(457, 45);
            cmbEspecialidad.Name = "cmbEspecialidad";
            cmbEspecialidad.Size = new Size(190, 25);
            cmbEspecialidad.TabIndex = 7;
            cmbEspecialidad.SelectedIndexChanged += FiltroCambiado;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(665, 43);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(92, 30);
            btnLimpiar.TabIndex = 8;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // panelLateral
            // 
            panelLateral.Controls.Add(lblReferencias);
            panelLateral.Controls.Add(grpVista);
            panelLateral.Controls.Add(calendario);
            panelLateral.Dock = DockStyle.Left;
            panelLateral.Location = new Point(14, 162);
            panelLateral.Name = "panelLateral";
            panelLateral.Padding = new Padding(0, 10, 12, 0);
            panelLateral.Size = new Size(250, 415);
            panelLateral.TabIndex = 1;
            // 
            // lblReferencias
            // 
            lblReferencias.Dock = DockStyle.Fill;
            lblReferencias.ForeColor = Color.DimGray;
            lblReferencias.Location = new Point(0, 289);
            lblReferencias.Name = "lblReferencias";
            lblReferencias.Padding = new Padding(6, 13, 6, 0);
            lblReferencias.Size = new Size(238, 126);
            lblReferencias.TabIndex = 0;
            lblReferencias.Text = "Referencias\r\n■ Verde: confirmado\r\n■ Azul: en curso\r\n■ Gris: disponible\r\n\r\nEn la vista mensual, un color más intenso indica mayor cantidad de turnos.";
            // 
            // grpVista
            // 
            grpVista.Controls.Add(rdbDia);
            grpVista.Controls.Add(rdbSemana);
            grpVista.Controls.Add(rdbMes);
            grpVista.Dock = DockStyle.Top;
            grpVista.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpVista.Location = new Point(0, 172);
            grpVista.Name = "grpVista";
            grpVista.Size = new Size(238, 117);
            grpVista.TabIndex = 1;
            grpVista.TabStop = false;
            grpVista.Text = "Vista";
            // 
            // rdbDia
            // 
            rdbDia.AutoSize = true;
            rdbDia.Location = new Point(16, 25);
            rdbDia.Name = "rdbDia";
            rdbDia.Size = new Size(49, 23);
            rdbDia.TabIndex = 0;
            rdbDia.Text = "Día";
            rdbDia.CheckedChanged += VistaCambiada;
            // 
            // rdbSemana
            // 
            rdbSemana.AutoSize = true;
            rdbSemana.Checked = true;
            rdbSemana.Location = new Point(16, 51);
            rdbSemana.Name = "rdbSemana";
            rdbSemana.Size = new Size(80, 23);
            rdbSemana.TabIndex = 1;
            rdbSemana.TabStop = true;
            rdbSemana.Text = "Semana";
            rdbSemana.CheckedChanged += VistaCambiada;
            // 
            // rdbMes
            // 
            rdbMes.AutoSize = true;
            rdbMes.Location = new Point(16, 77);
            rdbMes.Name = "rdbMes";
            rdbMes.Size = new Size(137, 23);
            rdbMes.TabIndex = 2;
            rdbMes.Text = "Mes (saturación)";
            rdbMes.CheckedChanged += VistaCambiada;
            // 
            // calendario
            // 
            calendario.Dock = DockStyle.Top;
            calendario.Location = new Point(0, 10);
            calendario.MaxSelectionCount = 1;
            calendario.Name = "calendario";
            calendario.TabIndex = 2;
            calendario.DateSelected += Calendario_DateSelected;
            // 
            // panelContenido
            // 
            panelContenido.Controls.Add(grillaAgenda);
            panelContenido.Controls.Add(panelPie);
            panelContenido.Controls.Add(panelEncabezadoAgenda);
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(264, 162);
            panelContenido.Name = "panelContenido";
            panelContenido.Padding = new Padding(0, 10, 0, 0);
            panelContenido.Size = new Size(871, 415);
            panelContenido.TabIndex = 0;
            // 
            // grillaAgenda
            // 
            grillaAgenda.AllowUserToAddRows = false;
            grillaAgenda.AllowUserToDeleteRows = false;
            grillaAgenda.AllowUserToResizeRows = false;
            grillaAgenda.BackgroundColor = Color.White;
            grillaAgenda.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            grillaAgenda.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaAgenda.Dock = DockStyle.Fill;
            grillaAgenda.EnableHeadersVisualStyles = false;
            grillaAgenda.Location = new Point(0, 52);
            grillaAgenda.MultiSelect = false;
            grillaAgenda.Name = "grillaAgenda";
            grillaAgenda.ReadOnly = true;
            grillaAgenda.RowHeadersVisible = false;
            grillaAgenda.SelectionMode = DataGridViewSelectionMode.CellSelect;
            grillaAgenda.Size = new Size(871, 315);
            grillaAgenda.TabIndex = 0;
            grillaAgenda.CellClick += grillaAgenda_CellClick;
            // 
            // panelPie
            // 
            panelPie.Controls.Add(btnVerCita);
            panelPie.Dock = DockStyle.Bottom;
            panelPie.Location = new Point(0, 367);
            panelPie.Name = "panelPie";
            panelPie.Size = new Size(871, 48);
            panelPie.TabIndex = 1;
            // 
            // btnVerCita
            // 
            btnVerCita.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnVerCita.Enabled = false;
            btnVerCita.Location = new Point(1417, 7);
            btnVerCita.Name = "btnVerCita";
            btnVerCita.Size = new Size(110, 32);
            btnVerCita.TabIndex = 0;
            btnVerCita.Text = "Ver cita";
            btnVerCita.UseVisualStyleBackColor = true;
            btnVerCita.Click += btnVerCita_Click;
            // 
            // panelEncabezadoAgenda
            // 
            panelEncabezadoAgenda.Controls.Add(lblVistaActual);
            panelEncabezadoAgenda.Controls.Add(lblResumen);
            panelEncabezadoAgenda.Dock = DockStyle.Top;
            panelEncabezadoAgenda.Location = new Point(0, 10);
            panelEncabezadoAgenda.Name = "panelEncabezadoAgenda";
            panelEncabezadoAgenda.Size = new Size(871, 42);
            panelEncabezadoAgenda.TabIndex = 2;
            // 
            // lblVistaActual
            // 
            lblVistaActual.AutoSize = true;
            lblVistaActual.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblVistaActual.ForeColor = Color.FromArgb(0, 0, 64);
            lblVistaActual.Location = new Point(0, 7);
            lblVistaActual.Name = "lblVistaActual";
            lblVistaActual.Size = new Size(158, 25);
            lblVistaActual.TabIndex = 0;
            lblVistaActual.Text = "Agenda semanal";
            // 
            // lblResumen
            // 
            lblResumen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblResumen.AutoSize = true;
            lblResumen.Location = new Point(1251, 13);
            lblResumen.Name = "lblResumen";
            lblResumen.Size = new Size(118, 15);
            lblResumen.TabIndex = 1;
            lblResumen.Text = "Turnos programados";
            // 
            // AgendaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1149, 591);
            Controls.Add(panelContenido);
            Controls.Add(panelLateral);
            Controls.Add(grpFiltros);
            Controls.Add(panelTitulo);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "AgendaForm";
            Padding = new Padding(14);
            Text = "Agenda Completa";
            panelTitulo.ResumeLayout(false);
            panelTitulo.PerformLayout();
            grpFiltros.ResumeLayout(false);
            grpFiltros.PerformLayout();
            panelLateral.ResumeLayout(false);
            grpVista.ResumeLayout(false);
            grpVista.PerformLayout();
            panelContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grillaAgenda).EndInit();
            panelPie.ResumeLayout(false);
            panelEncabezadoAgenda.ResumeLayout(false);
            panelEncabezadoAgenda.PerformLayout();
            ResumeLayout(false);
        }
    }
}
