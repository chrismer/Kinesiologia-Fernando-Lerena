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
            ((System.ComponentModel.ISupportInitialize)dtvBusquedaDePacientes).BeginInit();
            SuspendLayout();
            // 
            // txtBoxcuadroBusquedaPacientes
            // 
            txtBoxcuadroBusquedaPacientes.Location = new Point(314, 30);
            txtBoxcuadroBusquedaPacientes.Name = "txtBoxcuadroBusquedaPacientes";
            txtBoxcuadroBusquedaPacientes.Size = new Size(225, 27);
            txtBoxcuadroBusquedaPacientes.TabIndex = 0;
            txtBoxcuadroBusquedaPacientes.Text = "busqueda por nombre";
            // 
            // btnBusquedaPacientes
            // 
            btnBusquedaPacientes.Location = new Point(545, 30);
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
            dtvBusquedaDePacientes.Location = new Point(156, 63);
            dtvBusquedaDePacientes.Name = "dtvBusquedaDePacientes";
            dtvBusquedaDePacientes.RowHeadersWidth = 51;
            dtvBusquedaDePacientes.Size = new Size(575, 357);
            dtvBusquedaDePacientes.TabIndex = 2;
            // 
            // BuscadorPacientesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dtvBusquedaDePacientes);
            Controls.Add(btnBusquedaPacientes);
            Controls.Add(txtBoxcuadroBusquedaPacientes);
            Name = "BuscadorPacientesForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dtvBusquedaDePacientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBoxcuadroBusquedaPacientes;
        private Button btnBusquedaPacientes;
        private DataGridView dtvBusquedaDePacientes;
    }
}