namespace TESTSOLAPAS
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
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // ── Declaraciones ──────────────────────────────────────────
            txtBoxcuadroBusquedaPacientes   = new System.Windows.Forms.TextBox();
            btnBusquedaPacientes            = new System.Windows.Forms.Button();
            dtvBusquedaDePacientes          = new System.Windows.Forms.DataGridView();
            colDni                          = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colNombre                       = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colEdad                         = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCobertura                    = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colObservaciones                = new System.Windows.Forms.DataGridViewTextBoxColumn();
            panelPantallaBuscador           = new System.Windows.Forms.Panel();
            labelTituloPantallaBuscadora    = new System.Windows.Forms.Label();
            btnVerDetalle                   = new System.Windows.Forms.Button();
            btnAtender                      = new System.Windows.Forms.Button();
            lblTotalResultados              = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)dtvBusquedaDePacientes).BeginInit();
            panelPantallaBuscador.SuspendLayout();
            SuspendLayout();

            // ── panelPantallaBuscador (header azul) ───────────────────
            panelPantallaBuscador.BackColor = System.Drawing.Color.FromArgb(0, 0, 64);
            panelPantallaBuscador.Controls.Add(labelTituloPantallaBuscadora);
            panelPantallaBuscador.Controls.Add(txtBoxcuadroBusquedaPacientes);
            panelPantallaBuscador.Controls.Add(btnBusquedaPacientes);
            panelPantallaBuscador.Controls.Add(btnVerDetalle);
            panelPantallaBuscador.Controls.Add(btnAtender);
            panelPantallaBuscador.Dock     = System.Windows.Forms.DockStyle.Top;
            panelPantallaBuscador.Location = new System.Drawing.Point(0, 0);
            panelPantallaBuscador.Name     = "panelPantallaBuscador";
            panelPantallaBuscador.Size     = new System.Drawing.Size(1134, 90);
            panelPantallaBuscador.Padding  = new System.Windows.Forms.Padding(12, 8, 12, 8);

            // ── labelTituloPantallaBuscadora ──────────────────────────
            labelTituloPantallaBuscadora.AutoSize  = true;
            labelTituloPantallaBuscadora.BackColor = System.Drawing.Color.Transparent;
            labelTituloPantallaBuscadora.Font      = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            labelTituloPantallaBuscadora.ForeColor = System.Drawing.Color.SeaShell;
            labelTituloPantallaBuscadora.Location  = new System.Drawing.Point(14, 8);
            labelTituloPantallaBuscadora.Name      = "labelTituloPantallaBuscadora";
            labelTituloPantallaBuscadora.Text      = "Pacientes";

            // ── txtBoxcuadroBusquedaPacientes ─────────────────────────
            txtBoxcuadroBusquedaPacientes.Location    = new System.Drawing.Point(180, 48);
            txtBoxcuadroBusquedaPacientes.Name        = "txtBoxcuadroBusquedaPacientes";
            txtBoxcuadroBusquedaPacientes.Size        = new System.Drawing.Size(260, 28);
            txtBoxcuadroBusquedaPacientes.Font        = new System.Drawing.Font("Segoe UI", 10F);
            txtBoxcuadroBusquedaPacientes.PlaceholderText = "Buscar por nombre, apellido o DNI…";

            // ── btnBusquedaPacientes (Limpiar) ────────────────────────
            btnBusquedaPacientes.Location             = new System.Drawing.Point(452, 46);
            btnBusquedaPacientes.Name                 = "btnBusquedaPacientes";
            btnBusquedaPacientes.Size                 = new System.Drawing.Size(90, 30);
            btnBusquedaPacientes.Text                 = "Limpiar";
            btnBusquedaPacientes.Font                 = new System.Drawing.Font("Segoe UI", 9F);
            btnBusquedaPacientes.BackColor            = System.Drawing.Color.FromArgb(80, 80, 120);
            btnBusquedaPacientes.ForeColor            = System.Drawing.Color.White;
            btnBusquedaPacientes.FlatStyle            = System.Windows.Forms.FlatStyle.Flat;
            btnBusquedaPacientes.FlatAppearance.BorderSize = 0;
            btnBusquedaPacientes.Cursor               = System.Windows.Forms.Cursors.Hand;

            // ── btnVerDetalle ─────────────────────────────────────────
            btnVerDetalle.Location                    = new System.Drawing.Point(560, 46);
            btnVerDetalle.Name                        = "btnVerDetalle";
            btnVerDetalle.Size                        = new System.Drawing.Size(120, 30);
            btnVerDetalle.Text                        = "Ver Detalle";
            btnVerDetalle.Font                        = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnVerDetalle.BackColor                   = System.Drawing.Color.FromArgb(0, 100, 160);
            btnVerDetalle.ForeColor                   = System.Drawing.Color.White;
            btnVerDetalle.FlatStyle                   = System.Windows.Forms.FlatStyle.Flat;
            btnVerDetalle.FlatAppearance.BorderSize   = 0;
            btnVerDetalle.Cursor                      = System.Windows.Forms.Cursors.Hand;

            // ── btnAtender ────────────────────────────────────────────
            btnAtender.Location                       = new System.Drawing.Point(692, 46);
            btnAtender.Name                           = "btnAtender";
            btnAtender.Size                           = new System.Drawing.Size(140, 30);
            btnAtender.Text                           = "▶  Atender Paciente";
            btnAtender.Font                           = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnAtender.BackColor                      = System.Drawing.Color.FromArgb(0, 160, 80);
            btnAtender.ForeColor                      = System.Drawing.Color.White;
            btnAtender.FlatStyle                      = System.Windows.Forms.FlatStyle.Flat;
            btnAtender.FlatAppearance.BorderSize      = 0;
            btnAtender.Cursor                         = System.Windows.Forms.Cursors.Hand;

            // ── dtvBusquedaDePacientes ────────────────────────────────
            dtvBusquedaDePacientes.AllowUserToAddRows          = false;
            dtvBusquedaDePacientes.AllowUserToDeleteRows       = false;
            dtvBusquedaDePacientes.AllowUserToOrderColumns     = false;
            dtvBusquedaDePacientes.ReadOnly                    = true;
            dtvBusquedaDePacientes.SelectionMode               = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dtvBusquedaDePacientes.MultiSelect                 = false;
            dtvBusquedaDePacientes.RowHeadersVisible           = false;
            dtvBusquedaDePacientes.AutoSizeColumnsMode         = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dtvBusquedaDePacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtvBusquedaDePacientes.Font                        = new System.Drawing.Font("Segoe UI", 9.5F);
            dtvBusquedaDePacientes.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(235, 242, 252);
            dtvBusquedaDePacientes.GridColor                   = System.Drawing.Color.FromArgb(210, 220, 235);
            dtvBusquedaDePacientes.BackgroundColor             = System.Drawing.SystemColors.Control;
            dtvBusquedaDePacientes.BorderStyle                 = System.Windows.Forms.BorderStyle.None;
            dtvBusquedaDePacientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
                { colDni, colNombre, colEdad, colCobertura, colObservaciones });
            dtvBusquedaDePacientes.Location                    = new System.Drawing.Point(0, 90);
            dtvBusquedaDePacientes.Name                        = "dtvBusquedaDePacientes";
            dtvBusquedaDePacientes.Size                        = new System.Drawing.Size(1134, 490);
            dtvBusquedaDePacientes.Anchor                      = System.Windows.Forms.AnchorStyles.Top
                                                               | System.Windows.Forms.AnchorStyles.Bottom
                                                               | System.Windows.Forms.AnchorStyles.Left
                                                               | System.Windows.Forms.AnchorStyles.Right;

            // ── Columnas del grid ─────────────────────────────────────
            colDni.HeaderText  = "DNI";        colDni.Name  = "colDni";        colDni.FillWeight  = 12;  colDni.ReadOnly  = true;
            colNombre.HeaderText = "Nombre completo"; colNombre.Name = "colNombre"; colNombre.FillWeight = 28; colNombre.ReadOnly = true;
            colEdad.HeaderText = "Edad";       colEdad.Name = "colEdad";       colEdad.FillWeight = 8;   colEdad.ReadOnly = true;
            colCobertura.HeaderText = "Cobertura"; colCobertura.Name = "colCobertura"; colCobertura.FillWeight = 18; colCobertura.ReadOnly = true;
            colObservaciones.HeaderText = "Observaciones"; colObservaciones.Name = "colObservaciones"; colObservaciones.FillWeight = 34; colObservaciones.ReadOnly = true;

            // ── lblTotalResultados ────────────────────────────────────
            lblTotalResultados.Text      = "0 paciente(s)";
            lblTotalResultados.Font      = new System.Drawing.Font("Segoe UI", 9F);
            lblTotalResultados.ForeColor = System.Drawing.Color.FromArgb(80, 80, 100);
            lblTotalResultados.Dock      = System.Windows.Forms.DockStyle.Bottom;
            lblTotalResultados.Height    = 24;
            lblTotalResultados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblTotalResultados.Padding   = new System.Windows.Forms.Padding(6, 0, 0, 0);

            // ── Formulario ─────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize          = new System.Drawing.Size(1134, 620);
            Controls.Add(lblTotalResultados);
            Controls.Add(dtvBusquedaDePacientes);
            Controls.Add(panelPantallaBuscador);
            Name = "BuscadorPacientesForm";
            Text = "Pacientes";

            ((System.ComponentModel.ISupportInitialize)dtvBusquedaDePacientes).EndInit();
            panelPantallaBuscador.ResumeLayout(false);
            panelPantallaBuscador.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TextBox             txtBoxcuadroBusquedaPacientes;
        private System.Windows.Forms.Button              btnBusquedaPacientes;
        private System.Windows.Forms.DataGridView        dtvBusquedaDePacientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDni;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEdad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCobertura;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservaciones;
        private System.Windows.Forms.Panel               panelPantallaBuscador;
        private System.Windows.Forms.Label               labelTituloPantallaBuscadora;
        private System.Windows.Forms.Button              btnVerDetalle;
        private System.Windows.Forms.Button              btnAtender;
        private System.Windows.Forms.Label               lblTotalResultados;
    }
}