namespace TESTSOLAPAS
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            panel1 = new Panel();
            panel3 = new Panel();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            btnConfig = new Button();
            panel6 = new Panel();
            btnTurnos = new Button();
            panel7 = new Panel();
            btnAgenda = new Button();
            panel5 = new Panel();
            btnPacientes = new Button();
            panel4 = new Panel();
            btnDashboard = new Button();
            panel8 = new Panel();
            panelMain = new Panel();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 0, 64);
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1328, 86);
            panel1.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(label1);
            panel3.Controls.Add(pictureBox2);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(1029, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(295, 82);
            panel3.TabIndex = 3;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(69, 23);
            label1.Name = "label1";
            label1.Size = new Size(150, 30);
            label1.TabIndex = 3;
            label1.Text = "Dr. Juan Pérez";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.ActiveCaptionText;
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(3, 10);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(60, 60);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveCaptionText;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(177, 82);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.MidnightBlue;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(btnConfig);
            panel2.Controls.Add(panel6);
            panel2.Controls.Add(btnTurnos);
            panel2.Controls.Add(panel7);
            panel2.Controls.Add(btnAgenda);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(btnPacientes);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(btnDashboard);
            panel2.Controls.Add(panel8);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 86);
            panel2.Name = "panel2";
            panel2.Size = new Size(179, 591);
            panel2.TabIndex = 2;
            // 
            // btnConfig
            // 
            btnConfig.BackColor = SystemColors.ControlLight;
            btnConfig.Dock = DockStyle.Top;
            btnConfig.FlatStyle = FlatStyle.Flat;
            btnConfig.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnConfig.ForeColor = Color.FromArgb(0, 0, 64);
            btnConfig.Location = new Point(0, 260);
            btnConfig.Margin = new Padding(25);
            btnConfig.Name = "btnConfig";
            btnConfig.Padding = new Padding(10, 0, 0, 0);
            btnConfig.Size = new Size(175, 40);
            btnConfig.TabIndex = 31;
            btnConfig.Text = "Configuración";
            btnConfig.UseVisualStyleBackColor = false;
            btnConfig.Click += btnConfig_Click;
            // 
            // panel6
            // 
            panel6.BackColor = Color.MidnightBlue;
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 240);
            panel6.Name = "panel6";
            panel6.Size = new Size(175, 20);
            panel6.TabIndex = 30;
            // 
            // btnTurnos
            // 
            btnTurnos.BackColor = SystemColors.ControlLight;
            btnTurnos.Dock = DockStyle.Top;
            btnTurnos.FlatStyle = FlatStyle.Flat;
            btnTurnos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTurnos.ForeColor = Color.FromArgb(0, 0, 64);
            btnTurnos.Location = new Point(0, 200);
            btnTurnos.Margin = new Padding(25);
            btnTurnos.Name = "btnTurnos";
            btnTurnos.Padding = new Padding(10, 0, 0, 0);
            btnTurnos.Size = new Size(175, 40);
            btnTurnos.TabIndex = 29;
            btnTurnos.Text = "Turnos";
            btnTurnos.UseVisualStyleBackColor = false;
            btnTurnos.Click += btnTurnos_Click;
            // 
            // panel7
            // 
            panel7.BackColor = Color.MidnightBlue;
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 180);
            panel7.Name = "panel7";
            panel7.Size = new Size(175, 20);
            panel7.TabIndex = 28;
            // 
            // btnAgenda
            // 
            btnAgenda.BackColor = SystemColors.ControlLight;
            btnAgenda.Dock = DockStyle.Top;
            btnAgenda.FlatStyle = FlatStyle.Flat;
            btnAgenda.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAgenda.ForeColor = Color.FromArgb(0, 0, 64);
            btnAgenda.Location = new Point(0, 140);
            btnAgenda.Margin = new Padding(25);
            btnAgenda.Name = "btnAgenda";
            btnAgenda.Padding = new Padding(10, 0, 0, 0);
            btnAgenda.Size = new Size(175, 40);
            btnAgenda.TabIndex = 27;
            btnAgenda.Text = "Agenda";
            btnAgenda.UseVisualStyleBackColor = false;
            btnAgenda.Click += btnAgenda_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.MidnightBlue;
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 120);
            panel5.Name = "panel5";
            panel5.Size = new Size(175, 20);
            panel5.TabIndex = 26;
            // 
            // btnPacientes
            // 
            btnPacientes.BackColor = SystemColors.ControlLight;
            btnPacientes.Dock = DockStyle.Top;
            btnPacientes.FlatStyle = FlatStyle.Flat;
            btnPacientes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPacientes.ForeColor = Color.FromArgb(0, 0, 64);
            btnPacientes.Location = new Point(0, 80);
            btnPacientes.Margin = new Padding(25);
            btnPacientes.Name = "btnPacientes";
            btnPacientes.Padding = new Padding(10, 0, 0, 0);
            btnPacientes.Size = new Size(175, 40);
            btnPacientes.TabIndex = 25;
            btnPacientes.Text = "Pacientes";
            btnPacientes.UseVisualStyleBackColor = false;
            btnPacientes.Click += btnPacientes_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.MidnightBlue;
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 60);
            panel4.Name = "panel4";
            panel4.Size = new Size(175, 20);
            panel4.TabIndex = 24;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = SystemColors.ControlLight;
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDashboard.ForeColor = Color.FromArgb(0, 0, 64);
            btnDashboard.Location = new Point(0, 20);
            btnDashboard.Margin = new Padding(25);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(10, 0, 0, 0);
            btnDashboard.Size = new Size(175, 40);
            btnDashboard.TabIndex = 23;
            btnDashboard.Text = "Dashboard";
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // panel8
            // 
            panel8.BackColor = Color.MidnightBlue;
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(175, 20);
            panel8.TabIndex = 22;
            // 
            // panelMain
            // 
            panelMain.BorderStyle = BorderStyle.Fixed3D;
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(179, 86);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1149, 591);
            panelMain.TabIndex = 3;
            panelMain.Paint += panelMain_Paint;
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1328, 677);
            Controls.Add(panelMain);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Inicio";
            Text = "Form1";
            Load += Inicio_Load;
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panelMain;
        private PictureBox pictureBox1;
        private Panel panel3;
        private Label label1;
        private PictureBox pictureBox2;
        private Button btnConfig;
        private Panel panel6;
        private Button btnTurnos;
        private Panel panel7;
        private Button btnAgenda;
        private Panel panel5;
        private Button btnPacientes;
        private Panel panel4;
        private Button btnDashboard;
        private Panel panel8;
    }
}
