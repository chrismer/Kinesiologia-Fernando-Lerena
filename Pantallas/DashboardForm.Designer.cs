namespace TESTSOLAPAS
{
    partial class DashBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            btnVerDetalles = new Button();
            lblContadorPacientes = new Label();
            progressBar1 = new ProgressBar();
            lblPacientesAtendidos = new Label();
            panel2 = new Panel();
            btnMarcarLlegado = new Button();
            lblTiempoProximoTurno = new Label();
            lblProximoTurno = new Label();
            dataGridView1 = new DataGridView();
            Hora = new DataGridViewTextBoxColumn();
            Paciente = new DataGridViewTextBoxColumn();
            Tratamiento = new DataGridViewTextBoxColumn();
            Estado = new DataGridViewTextBoxColumn();
            Profesional = new DataGridViewTextBoxColumn();
            splitContainer1 = new SplitContainer();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 1);
            tableLayoutPanel1.Controls.Add(splitContainer1, 0, 3);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15.0000048F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 60.0000038F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 0F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(1089, 438);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnVerDetalles);
            panel1.Controls.Add(lblContadorPacientes);
            panel1.Controls.Add(progressBar1);
            panel1.Controls.Add(lblPacientesAtendidos);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(518, 105);
            panel1.TabIndex = 3;
            // 
            // btnVerDetalles
            // 
            btnVerDetalles.Dock = DockStyle.Right;
            btnVerDetalles.Location = new Point(422, 30);
            btnVerDetalles.Name = "btnVerDetalles";
            btnVerDetalles.Size = new Size(96, 46);
            btnVerDetalles.TabIndex = 3;
            btnVerDetalles.Text = "Ver Detalles";
            btnVerDetalles.UseVisualStyleBackColor = true;
            // 
            // lblContadorPacientes
            // 
            lblContadorPacientes.AutoSize = true;
            lblContadorPacientes.Dock = DockStyle.Fill;
            lblContadorPacientes.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContadorPacientes.Location = new Point(0, 30);
            lblContadorPacientes.Name = "lblContadorPacientes";
            lblContadorPacientes.Size = new Size(69, 46);
            lblContadorPacientes.TabIndex = 2;
            lblContadorPacientes.Text = "0/0";
            // 
            // progressBar1
            // 
            progressBar1.Dock = DockStyle.Bottom;
            progressBar1.Location = new Point(0, 76);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(518, 29);
            progressBar1.TabIndex = 1;
            // 
            // lblPacientesAtendidos
            // 
            lblPacientesAtendidos.AutoSize = true;
            lblPacientesAtendidos.Dock = DockStyle.Top;
            lblPacientesAtendidos.Font = new Font("Segoe UI", 12.2F);
            lblPacientesAtendidos.Location = new Point(0, 0);
            lblPacientesAtendidos.Name = "lblPacientesAtendidos";
            lblPacientesAtendidos.Size = new Size(248, 30);
            lblPacientesAtendidos.TabIndex = 0;
            lblPacientesAtendidos.Text = "Pacientes Atendidos Hoy:";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnMarcarLlegado);
            panel2.Controls.Add(lblTiempoProximoTurno);
            panel2.Controls.Add(lblProximoTurno);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(561, 105);
            panel2.TabIndex = 4;
            // 
            // btnMarcarLlegado
            // 
            btnMarcarLlegado.Dock = DockStyle.Right;
            btnMarcarLlegado.Location = new Point(405, 38);
            btnMarcarLlegado.Name = "btnMarcarLlegado";
            btnMarcarLlegado.Size = new Size(156, 67);
            btnMarcarLlegado.TabIndex = 2;
            btnMarcarLlegado.Text = "Marcar Como LLegado";
            btnMarcarLlegado.UseVisualStyleBackColor = true;
            // 
            // lblTiempoProximoTurno
            // 
            lblTiempoProximoTurno.AutoSize = true;
            lblTiempoProximoTurno.Dock = DockStyle.Left;
            lblTiempoProximoTurno.Font = new Font("Segoe UI", 16F);
            lblTiempoProximoTurno.Location = new Point(0, 38);
            lblTiempoProximoTurno.Name = "lblTiempoProximoTurno";
            lblTiempoProximoTurno.Size = new Size(131, 37);
            lblTiempoProximoTurno.TabIndex = 1;
            lblTiempoProximoTurno.Text = "10:30 AM";
            // 
            // lblProximoTurno
            // 
            lblProximoTurno.AutoSize = true;
            lblProximoTurno.Dock = DockStyle.Top;
            lblProximoTurno.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProximoTurno.Location = new Point(0, 0);
            lblProximoTurno.Name = "lblProximoTurno";
            lblProximoTurno.Size = new Size(200, 38);
            lblProximoTurno.TabIndex = 0;
            lblProximoTurno.Text = "Proximo Turno";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Hora, Paciente, Tratamiento, Estado, Profesional });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 68);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1083, 256);
            dataGridView1.TabIndex = 1;
            // 
            // Hora
            // 
            Hora.HeaderText = "Hora";
            Hora.MinimumWidth = 6;
            Hora.Name = "Hora";
            Hora.Width = 125;
            // 
            // Paciente
            // 
            Paciente.HeaderText = "Paciente";
            Paciente.MinimumWidth = 6;
            Paciente.Name = "Paciente";
            Paciente.Width = 125;
            // 
            // Tratamiento
            // 
            Tratamiento.HeaderText = "Tratamiento";
            Tratamiento.MinimumWidth = 6;
            Tratamiento.Name = "Tratamiento";
            Tratamiento.Width = 125;
            // 
            // Estado
            // 
            Estado.HeaderText = "Estado";
            Estado.MinimumWidth = 6;
            Estado.Name = "Estado";
            Estado.Width = 125;
            // 
            // Profesional
            // 
            Profesional.HeaderText = "Profesional";
            Profesional.MinimumWidth = 6;
            Profesional.Name = "Profesional";
            Profesional.Width = 125;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 330);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel2);
            splitContainer1.Size = new Size(1083, 105);
            splitContainer1.SplitterDistance = 518;
            splitContainer1.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(1083, 54);
            label1.TabIndex = 6;
            label1.Text = "DASH BOARD";
            // 
            // DashBoard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1089, 438);
            Controls.Add(tableLayoutPanel1);
            Name = "DashBoard";
            Text = "Dash Board";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Button btnVerDetalles;
        private Label lblContadorPacientes;
        private ProgressBar progressBar1;
        private Label lblPacientesAtendidos;
        private Panel panel2;
        private Button btnMarcarLlegado;
        private Label lblTiempoProximoTurno;
        private Label lblProximoTurno;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Hora;
        private DataGridViewTextBoxColumn Paciente;
        private DataGridViewTextBoxColumn Tratamiento;
        private DataGridViewTextBoxColumn Estado;
        private DataGridViewTextBoxColumn Profesional;
        private SplitContainer splitContainer1;
        private Label label1;
    }
}