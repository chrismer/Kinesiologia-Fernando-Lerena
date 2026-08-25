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
            dataGridView1 = new DataGridView();
            Hora = new DataGridViewTextBoxColumn();
            Paciente = new DataGridViewTextBoxColumn();
            Tratamiento = new DataGridViewTextBoxColumn();
            Estado = new DataGridViewTextBoxColumn();
            Profesional = new DataGridViewTextBoxColumn();
            lblTitle = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            lblPacientesAtendidos = new Label();
            progressBar1 = new ProgressBar();
            lblContadorPacientes = new Label();
            btnVerDetalles = new Button();
            lblProximoTurno = new Label();
            lblTiempoProximoTurno = new Label();
            btnMarcarLlegado = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Hora, Paciente, Tratamiento, Estado, Profesional });
            dataGridView1.Location = new Point(54, 79);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(678, 257);
            dataGridView1.TabIndex = 0;
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
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(54, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(168, 38);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Dash Board";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnVerDetalles);
            panel1.Controls.Add(lblContadorPacientes);
            panel1.Controls.Add(progressBar1);
            panel1.Controls.Add(lblPacientesAtendidos);
            panel1.Location = new Point(54, 342);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 96);
            panel1.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnMarcarLlegado);
            panel2.Controls.Add(lblTiempoProximoTurno);
            panel2.Controls.Add(lblProximoTurno);
            panel2.Location = new Point(482, 342);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 96);
            panel2.TabIndex = 3;
            // 
            // lblPacientesAtendidos
            // 
            lblPacientesAtendidos.AutoSize = true;
            lblPacientesAtendidos.Location = new Point(3, 9);
            lblPacientesAtendidos.Name = "lblPacientesAtendidos";
            lblPacientesAtendidos.Size = new Size(176, 20);
            lblPacientesAtendidos.TabIndex = 0;
            lblPacientesAtendidos.Text = "Pacientes Atendidos Hoy:";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 64);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(222, 29);
            progressBar1.TabIndex = 1;
            // 
            // lblContadorPacientes
            // 
            lblContadorPacientes.AutoSize = true;
            lblContadorPacientes.Font = new Font("Segoe UI", 12F);
            lblContadorPacientes.Location = new Point(12, 32);
            lblContadorPacientes.Name = "lblContadorPacientes";
            lblContadorPacientes.Size = new Size(42, 28);
            lblContadorPacientes.TabIndex = 2;
            lblContadorPacientes.Text = "0/0";
            // 
            // btnVerDetalles
            // 
            btnVerDetalles.Location = new Point(138, 32);
            btnVerDetalles.Name = "btnVerDetalles";
            btnVerDetalles.Size = new Size(96, 29);
            btnVerDetalles.TabIndex = 3;
            btnVerDetalles.Text = "Ver Detalles";
            btnVerDetalles.UseVisualStyleBackColor = true;
            // 
            // lblProximoTurno
            // 
            lblProximoTurno.AutoSize = true;
            lblProximoTurno.Location = new Point(15, 10);
            lblProximoTurno.Name = "lblProximoTurno";
            lblProximoTurno.Size = new Size(106, 20);
            lblProximoTurno.TabIndex = 0;
            lblProximoTurno.Text = "Proximo Turno";
            // 
            // lblTiempoProximoTurno
            // 
            lblTiempoProximoTurno.AutoSize = true;
            lblTiempoProximoTurno.Font = new Font("Segoe UI", 16F);
            lblTiempoProximoTurno.Location = new Point(15, 45);
            lblTiempoProximoTurno.Name = "lblTiempoProximoTurno";
            lblTiempoProximoTurno.Size = new Size(131, 37);
            lblTiempoProximoTurno.TabIndex = 1;
            lblTiempoProximoTurno.Text = "10:30 AM";
            // 
            // btnMarcarLlegado
            // 
            btnMarcarLlegado.Location = new Point(153, 10);
            btnMarcarLlegado.Name = "btnMarcarLlegado";
            btnMarcarLlegado.Size = new Size(94, 72);
            btnMarcarLlegado.TabIndex = 2;
            btnMarcarLlegado.Text = "Marcar Como LLegado";
            btnMarcarLlegado.UseVisualStyleBackColor = true;
            // 
            // DashBoard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(lblTitle);
            Controls.Add(dataGridView1);
            Name = "DashBoard";
            Text = "Dash Board";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Hora;
        private DataGridViewTextBoxColumn Paciente;
        private DataGridViewTextBoxColumn Tratamiento;
        private DataGridViewTextBoxColumn Estado;
        private DataGridViewTextBoxColumn Profesional;
        private Label lblTitle;
        private Panel panel1;
        private Panel panel2;
        private Button btnVerDetalles;
        private Label lblContadorPacientes;
        private ProgressBar progressBar1;
        private Label lblPacientesAtendidos;
        private Button btnMarcarLlegado;
        private Label lblTiempoProximoTurno;
        private Label lblProximoTurno;
    }
}