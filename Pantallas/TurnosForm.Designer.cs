namespace TESTSOLAPAS
{
    partial class TurnosForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelFiltros = new System.Windows.Forms.Panel();
            lblTitulo = new System.Windows.Forms.Label();
            lblDesde = new System.Windows.Forms.Label();
            dtpDesde = new System.Windows.Forms.DateTimePicker();
            lblHasta = new System.Windows.Forms.Label();
            dtpHasta = new System.Windows.Forms.DateTimePicker();
            lblProfesional = new System.Windows.Forms.Label();
            cmbProfesional = new System.Windows.Forms.ComboBox();
            lblEstado = new System.Windows.Forms.Label();
            cmbEstado = new System.Windows.Forms.ComboBox();
            lblBuscar = new System.Windows.Forms.Label();
            txtBuscar = new System.Windows.Forms.TextBox();
            btnFiltrar = new System.Windows.Forms.Button();
            btnLimpiar = new System.Windows.Forms.Button();

            panelBotones = new System.Windows.Forms.Panel();
            lblTotalResultados = new System.Windows.Forms.Label();
            btnMarcarLlegado = new System.Windows.Forms.Button();
            btnAtender = new System.Windows.Forms.Button();

            dgvTurnos = new System.Windows.Forms.DataGridView();
            colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCobertura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colProfesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDiagnostico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();

            panelFiltros.SuspendLayout();
            panelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTurnos).BeginInit();
            SuspendLayout();

            // ── panelFiltros ──────────────────────────────────────────
            panelFiltros.BackColor = System.Drawing.Color.FromArgb(0, 0, 64);
            panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            panelFiltros.Height = 110;
            panelFiltros.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            panelFiltros.Controls.Add(lblTitulo);
            panelFiltros.Controls.Add(lblDesde);
            panelFiltros.Controls.Add(dtpDesde);
            panelFiltros.Controls.Add(lblHasta);
            panelFiltros.Controls.Add(dtpHasta);
            panelFiltros.Controls.Add(lblProfesional);
            panelFiltros.Controls.Add(cmbProfesional);
            panelFiltros.Controls.Add(lblEstado);
            panelFiltros.Controls.Add(cmbEstado);
            panelFiltros.Controls.Add(lblBuscar);
            panelFiltros.Controls.Add(txtBuscar);
            panelFiltros.Controls.Add(btnFiltrar);
            panelFiltros.Controls.Add(btnLimpiar);

            // lblTitulo
            lblTitulo.Text = "Gestión y Búsqueda de Turnos";
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.White;
            lblTitulo.Location = new System.Drawing.Point(15, 8);
            lblTitulo.AutoSize = true;

            // Filtros fila
            int yFiltros = 45;
            int yLabels = 48;

            // Desde
            lblDesde.Text = "Desde:";
            lblDesde.ForeColor = System.Drawing.Color.LightGray;
            lblDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblDesde.Location = new System.Drawing.Point(15, yLabels);
            lblDesde.AutoSize = true;

            dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpDesde.Location = new System.Drawing.Point(60, yFiltros);
            dtpDesde.Width = 95;

            // Hasta
            lblHasta.Text = "Hasta:";
            lblHasta.ForeColor = System.Drawing.Color.LightGray;
            lblHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblHasta.Location = new System.Drawing.Point(165, yLabels);
            lblHasta.AutoSize = true;

            dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpHasta.Location = new System.Drawing.Point(208, yFiltros);
            dtpHasta.Width = 95;

            // Profesional
            lblProfesional.Text = "Profesional:";
            lblProfesional.ForeColor = System.Drawing.Color.LightGray;
            lblProfesional.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblProfesional.Location = new System.Drawing.Point(315, yLabels);
            lblProfesional.AutoSize = true;

            cmbProfesional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbProfesional.Location = new System.Drawing.Point(390, yFiltros);
            cmbProfesional.Width = 140;

            // Estado
            lblEstado.Text = "Estado:";
            lblEstado.ForeColor = System.Drawing.Color.LightGray;
            lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblEstado.Location = new System.Drawing.Point(540, yLabels);
            lblEstado.AutoSize = true;

            cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbEstado.Location = new System.Drawing.Point(590, yFiltros);
            cmbEstado.Width = 110;

            // Buscar
            lblBuscar.Text = "Buscar:";
            lblBuscar.ForeColor = System.Drawing.Color.LightGray;
            lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblBuscar.Location = new System.Drawing.Point(15, 80);
            lblBuscar.AutoSize = true;

            txtBuscar.Location = new System.Drawing.Point(60, 77);
            txtBuscar.Width = 243;
            txtBuscar.PlaceholderText = "Nombre o DNI del paciente...";

            // Botones Filtrar y Limpiar
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnFiltrar.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            btnFiltrar.ForeColor = System.Drawing.Color.White;
            btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnFiltrar.FlatAppearance.BorderSize = 0;
            btnFiltrar.Location = new System.Drawing.Point(315, 76);
            btnFiltrar.Size = new System.Drawing.Size(90, 26);
            btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;

            btnLimpiar.Text = "Limpiar";
            btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnLimpiar.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            btnLimpiar.ForeColor = System.Drawing.Color.White;
            btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.Location = new System.Drawing.Point(415, 76);
            btnLimpiar.Size = new System.Drawing.Size(85, 26);
            btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;

            // ── panelBotones (Inferior) ───────────────────────────────
            panelBotones.BackColor = System.Drawing.SystemColors.ControlLight;
            panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelBotones.Height = 55;
            panelBotones.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            panelBotones.Controls.Add(lblTotalResultados);
            panelBotones.Controls.Add(btnMarcarLlegado);
            panelBotones.Controls.Add(btnAtender);

            lblTotalResultados.Text = "0 turnos encontrados";
            lblTotalResultados.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblTotalResultados.ForeColor = System.Drawing.Color.FromArgb(0, 0, 64);
            lblTotalResultados.Location = new System.Drawing.Point(15, 18);
            lblTotalResultados.AutoSize = true;

            btnMarcarLlegado.Text = "Marcar Llegado";
            btnMarcarLlegado.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnMarcarLlegado.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            btnMarcarLlegado.ForeColor = System.Drawing.Color.White;
            btnMarcarLlegado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnMarcarLlegado.FlatAppearance.BorderSize = 0;
            btnMarcarLlegado.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnMarcarLlegado.Location = new System.Drawing.Point(620, 10);
            btnMarcarLlegado.Size = new System.Drawing.Size(160, 35);
            btnMarcarLlegado.Cursor = System.Windows.Forms.Cursors.Hand;

            btnAtender.Text = "Atender Paciente";
            btnAtender.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnAtender.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            btnAtender.ForeColor = System.Drawing.Color.White;
            btnAtender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAtender.FlatAppearance.BorderSize = 0;
            btnAtender.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAtender.Location = new System.Drawing.Point(790, 10);
            btnAtender.Size = new System.Drawing.Size(170, 35);
            btnAtender.Cursor = System.Windows.Forms.Cursors.Hand;

            // ── dgvTurnos ─────────────────────────────────────────────
            dgvTurnos.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvTurnos.ReadOnly = true;
            dgvTurnos.AllowUserToAddRows = false;
            dgvTurnos.AllowUserToDeleteRows = false;
            dgvTurnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvTurnos.MultiSelect = false;
            dgvTurnos.RowHeadersVisible = false;
            dgvTurnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvTurnos.BackgroundColor = System.Drawing.SystemColors.Window;
            dgvTurnos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvTurnos.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 244, 250);
            dgvTurnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                colId, colFecha, colHora, colPaciente, colDni, colCobertura, colProfesional, colDiagnostico, colEstado
            });

            colId.HeaderText = "ID";
            colId.Visible = false;

            colFecha.HeaderText = "Fecha";
            colFecha.FillWeight = 11;

            colHora.HeaderText = "Hora";
            colHora.FillWeight = 9;

            colPaciente.HeaderText = "Paciente";
            colPaciente.FillWeight = 20;

            colDni.HeaderText = "DNI";
            colDni.FillWeight = 11;

            colCobertura.HeaderText = "Obra Social";
            colCobertura.FillWeight = 13;

            colProfesional.HeaderText = "Profesional";
            colProfesional.FillWeight = 16;

            colDiagnostico.HeaderText = "Diagnóstico / Motivo";
            colDiagnostico.FillWeight = 20;

            colEstado.HeaderText = "Estado";
            colEstado.FillWeight = 12;

            // Form
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(980, 560);
            Controls.Add(dgvTurnos);
            Controls.Add(panelBotones);
            Controls.Add(panelFiltros);
            Name = "TurnosForm";
            Text = "Gestión de Turnos";

            panelFiltros.ResumeLayout(false);
            panelFiltros.PerformLayout();
            panelBotones.ResumeLayout(false);
            panelBotones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTurnos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblProfesional;
        private System.Windows.Forms.ComboBox cmbProfesional;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnLimpiar;

        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Label lblTotalResultados;
        private System.Windows.Forms.Button btnMarcarLlegado;
        private System.Windows.Forms.Button btnAtender;

        private System.Windows.Forms.DataGridView dgvTurnos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDni;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCobertura;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProfesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiagnostico;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
    }
}
