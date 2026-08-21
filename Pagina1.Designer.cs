namespace TESTSOLAPAS
{
    public partial class DashBoard
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
            components = new System.ComponentModel.Container();
            dataGridHistorialPacientes = new DataGridView();
            Hora = new DataGridViewTextBoxColumn();
            Paciente = new DataGridViewTextBoxColumn();
            Tratamiento = new DataGridViewTextBoxColumn();
            Estado = new DataGridViewTextBoxColumn();
            Profesional = new DataGridViewTextBoxColumn();
            Title = new Label();
            groupBox1 = new GroupBox();
            Ver_Detalles = new Button();
            Contador = new Label();
            progressBar1 = new ProgressBar();
            groupBox2 = new GroupBox();
            label1 = new Label();
            lblProximoTurno = new Label();
            btnMarcarLLegado = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dataGridHistorialPacientes).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridHistorialPacientes
            // 
            dataGridHistorialPacientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridHistorialPacientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridHistorialPacientes.Columns.AddRange(new DataGridViewColumn[] { Hora, Paciente, Tratamiento, Estado, Profesional });
            dataGridHistorialPacientes.Location = new Point(58, 70);
            dataGridHistorialPacientes.Name = "dataGridHistorialPacientes";
            dataGridHistorialPacientes.RowHeadersWidth = 51;
            dataGridHistorialPacientes.Size = new Size(679, 248);
            dataGridHistorialPacientes.TabIndex = 0;
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
            // Title
            // 
            Title.AutoSize = true;
            Title.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Title.Location = new Point(49, 26);
            Title.Name = "Title";
            Title.Size = new Size(170, 41);
            Title.TabIndex = 1;
            Title.Text = "Dash Board";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.Control;
            groupBox1.Controls.Add(Ver_Detalles);
            groupBox1.Controls.Add(Contador);
            groupBox1.Controls.Add(progressBar1);
            groupBox1.Location = new Point(58, 341);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(250, 97);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            // 
            // Ver_Detalles
            // 
            Ver_Detalles.Location = new Point(129, 32);
            Ver_Detalles.Name = "Ver_Detalles";
            Ver_Detalles.Size = new Size(100, 29);
            Ver_Detalles.TabIndex = 2;
            Ver_Detalles.Text = "Ver Detalles";
            Ver_Detalles.UseVisualStyleBackColor = true;
            // 
            // Contador
            // 
            Contador.AutoSize = true;
            Contador.Font = new Font("Segoe UI", 16F);
            Contador.Location = new Point(38, 24);
            Contador.Name = "Contador";
            Contador.Size = new Size(58, 37);
            Contador.TabIndex = 1;
            Contador.Text = "0/0";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(6, 69);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(238, 22);
            progressBar1.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.Control;
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(lblProximoTurno);
            groupBox2.Controls.Add(btnMarcarLLegado);
            groupBox2.Location = new Point(369, 341);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(250, 97);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 60);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 3;
            label1.Text = "label1";
            // 
            // lblProximoTurno
            // 
            lblProximoTurno.AutoSize = true;
            lblProximoTurno.Font = new Font("Segoe UI", 12F);
            lblProximoTurno.Location = new Point(6, 18);
            lblProximoTurno.Name = "lblProximoTurno";
            lblProximoTurno.Size = new Size(141, 28);
            lblProximoTurno.TabIndex = 2;
            lblProximoTurno.Text = "Proximo Turno";
            // 
            // btnMarcarLLegado
            // 
            btnMarcarLLegado.BackColor = SystemColors.ButtonHighlight;
            btnMarcarLLegado.Location = new Point(147, 18);
            btnMarcarLLegado.Name = "btnMarcarLLegado";
            btnMarcarLLegado.Size = new Size(97, 73);
            btnMarcarLLegado.TabIndex = 0;
            btnMarcarLLegado.Text = "Marcar Como LLegado";
            btnMarcarLLegado.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Location = new Point(35, 26);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.Size = new Size(3, 4);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // DashBoard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            CausesValidation = false;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(Title);
            Controls.Add(dataGridHistorialPacientes);
            Name = "DashBoard";
            Text = "Dash Board";
            ((System.ComponentModel.ISupportInitialize)dataGridHistorialPacientes).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridHistorialPacientes;
        private Label Title;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button Ver_Detalles;
        private Label Contador;
        private ProgressBar progressBar1;
        private Button btnMarcarLLegado;
        private System.Windows.Forms.Timer timer1;
        private Label lblProximoTurno;
        private Label label1;
        private DataGridViewTextBoxColumn Hora;
        private DataGridViewTextBoxColumn Paciente;
        private DataGridViewTextBoxColumn Tratamiento;
        private DataGridViewTextBoxColumn Estado;
        private DataGridViewTextBoxColumn Profesional;
        private TableLayoutPanel tableLayoutPanel1;
    }
}