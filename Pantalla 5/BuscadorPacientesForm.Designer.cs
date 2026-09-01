namespace TESTSOLAPAS.Pantalla_5
{
    partial class BuscadorPacientesForm
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
            txtBoxcuadroBusquedaPacientes = new TextBox();
            btnBusquedaPacientes = new Button();
            dtvBusquedaDePacientes = new DataGridView();
            DNIDGV = new DataGridViewTextBoxColumn();
            NombreDGV = new DataGridViewTextBoxColumn();
            ObservacionesDGV = new DataGridViewTextBoxColumn();
            panelPantallaBuscador = new Panel();
            panelIzquierdo = new Panel();
            labelTituloPantallaBuscadora = new Label();
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
            ((System.ComponentModel.ISupportInitialize)dtvBusquedaDePacientes).BeginInit();
            panelPantallaBuscador.SuspendLayout();
            panelIzquierdo.SuspendLayout();
            SuspendLayout();
            // 
            // txtBoxcuadroBusquedaPacientes
            // 
            txtBoxcuadroBusquedaPacientes.Location = new Point(144, 52);
            txtBoxcuadroBusquedaPacientes.Name = "txtBoxcuadroBusquedaPacientes";
            txtBoxcuadroBusquedaPacientes.Size = new Size(225, 27);
            txtBoxcuadroBusquedaPacientes.TabIndex = 0;
            txtBoxcuadroBusquedaPacientes.Text = "busqueda por nombre";
            txtBoxcuadroBusquedaPacientes.TextChanged += txtBoxcuadroBusquedaPacientes_TextChanged;
            // 
            // btnBusquedaPacientes
            // 
            btnBusquedaPacientes.Location = new Point(375, 52);
            btnBusquedaPacientes.Name = "btnBusquedaPacientes";
            btnBusquedaPacientes.Size = new Size(94, 29);
            btnBusquedaPacientes.TabIndex = 1;
            btnBusquedaPacientes.Text = "Buscar";
            btnBusquedaPacientes.UseVisualStyleBackColor = true;
            btnBusquedaPacientes.Click += btnBusquedaPacientes_Click_1;
            // 
            // dtvBusquedaDePacientes
            // 
            dtvBusquedaDePacientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtvBusquedaDePacientes.Columns.AddRange(new DataGridViewColumn[] { DNIDGV, NombreDGV, ObservacionesDGV });
            dtvBusquedaDePacientes.Location = new Point(183, 120);
            dtvBusquedaDePacientes.Name = "dtvBusquedaDePacientes";
            dtvBusquedaDePacientes.RowHeadersWidth = 51;
            dtvBusquedaDePacientes.Size = new Size(1110, 623);
            dtvBusquedaDePacientes.TabIndex = 2;
            dtvBusquedaDePacientes.CellContentClick += dtvBusquedaDePacientes_CellContentClick;
            // 
            // DNIDGV
            // 
            DNIDGV.HeaderText = "DNI";
            DNIDGV.MinimumWidth = 6;
            DNIDGV.Name = "DNIDGV";
            DNIDGV.Width = 125;
            // 
            // NombreDGV
            // 
            NombreDGV.HeaderText = "Nombre";
            NombreDGV.MinimumWidth = 6;
            NombreDGV.Name = "NombreDGV";
            NombreDGV.Width = 125;
            // 
            // ObservacionesDGV
            // 
            ObservacionesDGV.HeaderText = "Observaciones";
            ObservacionesDGV.MinimumWidth = 6;
            ObservacionesDGV.Name = "ObservacionesDGV";
            ObservacionesDGV.Width = 125;
            // 
            // panelPantallaBuscador
            // 
            panelPantallaBuscador.BackColor = Color.FromArgb(0, 0, 64);
            panelPantallaBuscador.Controls.Add(labelTituloPantallaBuscadora);
            panelPantallaBuscador.Controls.Add(txtBoxcuadroBusquedaPacientes);
            panelPantallaBuscador.Controls.Add(btnBusquedaPacientes);
            panelPantallaBuscador.Location = new Point(183, 1);
            panelPantallaBuscador.Name = "panelPantallaBuscador";
            panelPantallaBuscador.Size = new Size(1110, 113);
            panelPantallaBuscador.TabIndex = 3;
            // 
            // panelIzquierdo
            // 
            panelIzquierdo.Anchor = AnchorStyles.Left;
            panelIzquierdo.BackColor = Color.FromArgb(0, 0, 64);
            panelIzquierdo.Controls.Add(btnConfig);
            panelIzquierdo.Controls.Add(panel6);
            panelIzquierdo.Controls.Add(btnTurnos);
            panelIzquierdo.Controls.Add(panel7);
            panelIzquierdo.Controls.Add(btnAgenda);
            panelIzquierdo.Controls.Add(panel5);
            panelIzquierdo.Controls.Add(btnPacientes);
            panelIzquierdo.Controls.Add(panel4);
            panelIzquierdo.Controls.Add(btnDashboard);
            panelIzquierdo.Controls.Add(panel8);
            panelIzquierdo.Location = new Point(-3, 120);
            panelIzquierdo.Name = "panelIzquierdo";
            panelIzquierdo.Size = new Size(180, 761);
            panelIzquierdo.TabIndex = 2;
            // 
            // labelTituloPantallaBuscadora
            // 
            labelTituloPantallaBuscadora.AutoSize = true;
            labelTituloPantallaBuscadora.BackColor = Color.FromArgb(0, 0, 64);
            labelTituloPantallaBuscadora.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTituloPantallaBuscadora.ForeColor = Color.SeaShell;
            labelTituloPantallaBuscadora.Location = new Point(3, 8);
            labelTituloPantallaBuscadora.Name = "labelTituloPantallaBuscadora";
            labelTituloPantallaBuscadora.Size = new Size(147, 41);
            labelTituloPantallaBuscadora.TabIndex = 2;
            labelTituloPantallaBuscadora.Text = "Buscador";
            labelTituloPantallaBuscadora.Click += label1_Click;
            // 
            // btnConfig
            // 
            btnConfig.BackColor = SystemColors.ControlLight;
            btnConfig.Dock = DockStyle.Top;
            btnConfig.FlatStyle = FlatStyle.Flat;
            btnConfig.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnConfig.ForeColor = Color.FromArgb(0, 0, 64);
            btnConfig.Location = new Point(0, 347);
            btnConfig.Margin = new Padding(29, 33, 29, 33);
            btnConfig.Name = "btnConfig";
            btnConfig.Padding = new Padding(11, 0, 0, 0);
            btnConfig.Size = new Size(180, 53);
            btnConfig.TabIndex = 41;
            btnConfig.Text = "Configuración";
            btnConfig.UseVisualStyleBackColor = false;
            // 
            // panel6
            // 
            panel6.BackColor = Color.MidnightBlue;
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 320);
            panel6.Margin = new Padding(3, 4, 3, 4);
            panel6.Name = "panel6";
            panel6.Size = new Size(180, 27);
            panel6.TabIndex = 40;
            // 
            // btnTurnos
            // 
            btnTurnos.BackColor = SystemColors.ControlLight;
            btnTurnos.Dock = DockStyle.Top;
            btnTurnos.FlatStyle = FlatStyle.Flat;
            btnTurnos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTurnos.ForeColor = Color.FromArgb(0, 0, 64);
            btnTurnos.Location = new Point(0, 267);
            btnTurnos.Margin = new Padding(29, 33, 29, 33);
            btnTurnos.Name = "btnTurnos";
            btnTurnos.Padding = new Padding(11, 0, 0, 0);
            btnTurnos.Size = new Size(180, 53);
            btnTurnos.TabIndex = 39;
            btnTurnos.Text = "Turnos";
            btnTurnos.UseVisualStyleBackColor = false;
            // 
            // panel7
            // 
            panel7.BackColor = Color.MidnightBlue;
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 240);
            panel7.Margin = new Padding(3, 4, 3, 4);
            panel7.Name = "panel7";
            panel7.Size = new Size(180, 27);
            panel7.TabIndex = 38;
            // 
            // btnAgenda
            // 
            btnAgenda.BackColor = SystemColors.ControlLight;
            btnAgenda.Dock = DockStyle.Top;
            btnAgenda.FlatStyle = FlatStyle.Flat;
            btnAgenda.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAgenda.ForeColor = Color.FromArgb(0, 0, 64);
            btnAgenda.Location = new Point(0, 187);
            btnAgenda.Margin = new Padding(29, 33, 29, 33);
            btnAgenda.Name = "btnAgenda";
            btnAgenda.Padding = new Padding(11, 0, 0, 0);
            btnAgenda.Size = new Size(180, 53);
            btnAgenda.TabIndex = 37;
            btnAgenda.Text = "Agenda";
            btnAgenda.UseVisualStyleBackColor = false;
            // 
            // panel5
            // 
            panel5.BackColor = Color.MidnightBlue;
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 160);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(180, 27);
            panel5.TabIndex = 36;
            // 
            // btnPacientes
            // 
            btnPacientes.BackColor = SystemColors.ControlLight;
            btnPacientes.Dock = DockStyle.Top;
            btnPacientes.FlatStyle = FlatStyle.Flat;
            btnPacientes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPacientes.ForeColor = Color.FromArgb(0, 0, 64);
            btnPacientes.Location = new Point(0, 107);
            btnPacientes.Margin = new Padding(29, 33, 29, 33);
            btnPacientes.Name = "btnPacientes";
            btnPacientes.Padding = new Padding(11, 0, 0, 0);
            btnPacientes.Size = new Size(180, 53);
            btnPacientes.TabIndex = 35;
            btnPacientes.Text = "Pacientes";
            btnPacientes.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            panel4.BackColor = Color.MidnightBlue;
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 80);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(180, 27);
            panel4.TabIndex = 34;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = SystemColors.ControlLight;
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDashboard.ForeColor = Color.FromArgb(0, 0, 64);
            btnDashboard.Location = new Point(0, 27);
            btnDashboard.Margin = new Padding(29, 33, 29, 33);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(11, 0, 0, 0);
            btnDashboard.Size = new Size(180, 53);
            btnDashboard.TabIndex = 33;
            btnDashboard.Text = "Dashboard";
            btnDashboard.UseVisualStyleBackColor = false;
            // 
            // panel8
            // 
            panel8.BackColor = Color.MidnightBlue;
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 0);
            panel8.Margin = new Padding(3, 4, 3, 4);
            panel8.Name = "panel8";
            panel8.Size = new Size(180, 27);
            panel8.TabIndex = 32;
            // 
            // BuscadorPacientesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1296, 743);
            Controls.Add(panelIzquierdo);
            Controls.Add(panelPantallaBuscador);
            Controls.Add(dtvBusquedaDePacientes);
            Name = "BuscadorPacientesForm";
            Text = "Form1";
            Load += BuscadorPacientesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dtvBusquedaDePacientes).EndInit();
            panelPantallaBuscador.ResumeLayout(false);
            panelPantallaBuscador.PerformLayout();
            panelIzquierdo.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtBoxcuadroBusquedaPacientes;
        private Button btnBusquedaPacientes;
        private DataGridView dtvBusquedaDePacientes;
        private DataGridViewTextBoxColumn DNIDGV;
        private DataGridViewTextBoxColumn NombreDGV;
        private DataGridViewTextBoxColumn ObservacionesDGV;
        private Panel panelPantallaBuscador;
        private Panel panelIzquierdo;
        private Label labelTituloPantallaBuscadora;
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