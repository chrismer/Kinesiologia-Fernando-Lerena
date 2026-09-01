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
            labelTituloPantallaBuscadora = new Label();
            ((System.ComponentModel.ISupportInitialize)dtvBusquedaDePacientes).BeginInit();
            panelPantallaBuscador.SuspendLayout();
            SuspendLayout();
            // 
            // txtBoxcuadroBusquedaPacientes
            // 
            txtBoxcuadroBusquedaPacientes.Location = new Point(126, 39);
            txtBoxcuadroBusquedaPacientes.Margin = new Padding(3, 2, 3, 2);
            txtBoxcuadroBusquedaPacientes.Name = "txtBoxcuadroBusquedaPacientes";
            txtBoxcuadroBusquedaPacientes.Size = new Size(197, 23);
            txtBoxcuadroBusquedaPacientes.TabIndex = 0;
            txtBoxcuadroBusquedaPacientes.Text = "busqueda por nombre";
            txtBoxcuadroBusquedaPacientes.TextChanged += txtBoxcuadroBusquedaPacientes_TextChanged;
            // 
            // btnBusquedaPacientes
            // 
            btnBusquedaPacientes.Location = new Point(328, 39);
            btnBusquedaPacientes.Margin = new Padding(3, 2, 3, 2);
            btnBusquedaPacientes.Name = "btnBusquedaPacientes";
            btnBusquedaPacientes.Size = new Size(82, 22);
            btnBusquedaPacientes.TabIndex = 1;
            btnBusquedaPacientes.Text = "Buscar";
            btnBusquedaPacientes.UseVisualStyleBackColor = true;
            btnBusquedaPacientes.Click += btnBusquedaPacientes_Click_1;
            // 
            // dtvBusquedaDePacientes
            // 
            dtvBusquedaDePacientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtvBusquedaDePacientes.Columns.AddRange(new DataGridViewColumn[] { DNIDGV, NombreDGV, ObservacionesDGV });
            dtvBusquedaDePacientes.Location = new Point(0, 90);
            dtvBusquedaDePacientes.Margin = new Padding(3, 2, 3, 2);
            dtvBusquedaDePacientes.Name = "dtvBusquedaDePacientes";
            dtvBusquedaDePacientes.RowHeadersWidth = 51;
            dtvBusquedaDePacientes.Size = new Size(1131, 467);
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
            panelPantallaBuscador.Dock = DockStyle.Top;
            panelPantallaBuscador.Location = new Point(0, 0);
            panelPantallaBuscador.Margin = new Padding(3, 2, 3, 2);
            panelPantallaBuscador.Name = "panelPantallaBuscador";
            panelPantallaBuscador.Size = new Size(1134, 85);
            panelPantallaBuscador.TabIndex = 3;
            // 
            // labelTituloPantallaBuscadora
            // 
            labelTituloPantallaBuscadora.AutoSize = true;
            labelTituloPantallaBuscadora.BackColor = Color.FromArgb(0, 0, 64);
            labelTituloPantallaBuscadora.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTituloPantallaBuscadora.ForeColor = Color.SeaShell;
            labelTituloPantallaBuscadora.Location = new Point(3, 6);
            labelTituloPantallaBuscadora.Name = "labelTituloPantallaBuscadora";
            labelTituloPantallaBuscadora.Size = new Size(120, 32);
            labelTituloPantallaBuscadora.TabIndex = 2;
            labelTituloPantallaBuscadora.Text = "Buscador";
            labelTituloPantallaBuscadora.Click += label1_Click;
            // 
            // BuscadorPacientesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1134, 559);
            Controls.Add(panelPantallaBuscador);
            Controls.Add(dtvBusquedaDePacientes);
            Margin = new Padding(3, 2, 3, 2);
            Name = "BuscadorPacientesForm";
            Text = "Form1";
            Load += BuscadorPacientesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dtvBusquedaDePacientes).EndInit();
            panelPantallaBuscador.ResumeLayout(false);
            panelPantallaBuscador.PerformLayout();
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
        private Label labelTituloPantallaBuscadora;
    }
}