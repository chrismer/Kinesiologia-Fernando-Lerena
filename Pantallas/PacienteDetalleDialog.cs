using System;
using System.Drawing;
using System.Windows.Forms;

namespace TESTSOLAPAS
{
    /// <summary>
    /// Modal que muestra la ficha demográfica y de cobertura completa de un paciente.
    /// No muestra historial de evoluciones (eso queda en PacienteForm).
    ///
    /// DialogResult.OK  → el llamador debe abrir la consulta activa.
    /// DialogResult.Cancel → cerrar sin acción.
    /// </summary>
    public class PacienteDetalleDialog : Form
    {
        private readonly PacienteDetalle _detalle;

        // ── Controles ──────────────────────────────────────────────────
        private Panel  panelHeader;
        private Label  lblNombre;
        private Label  lblDniEdadSexo;
        private Label  lblBadge;

        private TableLayoutPanel tableBody;

        // Columna izquierda – datos personales
        private GroupBox grpPersonal;
        private Label lblDireccion;
        private Label lblLocalidad;
        private Label lblTel1;
        private Label lblTel2;
        private Label lblTel3;
        private Label lblEmail;

        // Columna derecha – cobertura + información extra
        private GroupBox grpCobertura;
        private Label lblOS;
        private Label lblAfiliado;
        private Label lblPlan;

        private GroupBox grpInfo;
        private Label lblIngreso;
        private Label lblObs;

        // Pie
        private Panel  panelFooter;
        private Button btnIrConsulta;
        private Button btnCerrar;

        // ── Constructor ────────────────────────────────────────────────

        public PacienteDetalleDialog(PacienteDetalle detalle)
        {
            _detalle = detalle;
            BuildUI();
            PopularDatos();
        }

        // ── Construcción de la UI ──────────────────────────────────────

        private void BuildUI()
        {
            // Formulario
            Text            = "Ficha del Paciente";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition   = FormStartPosition.CenterParent;
            ClientSize      = new Size(700, 500);
            MinimizeBox     = false;
            MaximizeBox     = false;
            ShowInTaskbar   = false;
            Font            = new Font("Segoe UI", 9.5F);

            // ── HEADER ────────────────────────────────────────────────
            panelHeader = new Panel
            {
                Dock      = DockStyle.Top,
                Height    = 90,
                BackColor = Color.FromArgb(0, 0, 64),
                Padding   = new Padding(18, 10, 18, 10)
            };

            lblBadge = new Label
            {
                Text      = "ACTIVO",
                Font      = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(0, 160, 80),
                AutoSize  = true,
                Padding   = new Padding(6, 3, 6, 3),
                Location  = new Point(560, 14)
            };

            lblNombre = new Label
            {
                Text      = "— Cargando —",
                Font      = new Font("Segoe UI", 17F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize  = true,
                Location  = new Point(18, 10)
            };

            lblDniEdadSexo = new Label
            {
                Text      = "",
                Font      = new Font("Segoe UI", 9.5F),
                ForeColor = Color.LightGray,
                AutoSize  = true,
                Location  = new Point(18, 56)
            };

            panelHeader.Controls.Add(lblBadge);
            panelHeader.Controls.Add(lblNombre);
            panelHeader.Controls.Add(lblDniEdadSexo);

            // ── BODY (dos columnas) ───────────────────────────────────
            tableBody = new TableLayoutPanel
            {
                Dock        = DockStyle.Fill,
                ColumnCount = 2,
                RowCount    = 1,
                Padding     = new Padding(12),
            };
            tableBody.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52F));
            tableBody.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));
            tableBody.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // ── Columna izquierda: Datos Personales ───────────────────
            grpPersonal = new GroupBox
            {
                Text     = "Datos Personales",
                Dock     = DockStyle.Fill,
                Padding  = new Padding(10, 14, 10, 10),
                Font     = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 0, 64)
            };

            lblDireccion = CrearLabel(); lblDireccion.Location = new Point(10, 28);
            lblLocalidad = CrearLabel(); lblLocalidad.Location = new Point(10, 52);
            lblTel1      = CrearLabel(); lblTel1.Location      = new Point(10, 80);
            lblTel2      = CrearLabel(); lblTel2.Location      = new Point(10, 100);
            lblTel3      = CrearLabel(); lblTel3.Location      = new Point(10, 120);
            lblEmail     = CrearLabel(); lblEmail.Location     = new Point(10, 148);

            grpPersonal.Controls.AddRange(new Control[]
                { lblDireccion, lblLocalidad, lblTel1, lblTel2, lblTel3, lblEmail });

            // ── Columna derecha: Cobertura + Información ──────────────
            var panelDerecha = new Panel { Dock = DockStyle.Fill };

            grpCobertura = new GroupBox
            {
                Text      = "Cobertura",
                Dock      = DockStyle.Top,
                Height    = 120,
                Padding   = new Padding(10, 14, 10, 10),
                Font      = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 0, 64)
            };

            lblOS       = CrearLabel(); lblOS.Location       = new Point(10, 28);
            lblAfiliado = CrearLabel(); lblAfiliado.Location = new Point(10, 52);
            lblPlan     = CrearLabel(); lblPlan.Location     = new Point(10, 76);

            grpCobertura.Controls.AddRange(new Control[] { lblOS, lblAfiliado, lblPlan });

            grpInfo = new GroupBox
            {
                Text      = "Información adicional",
                Dock      = DockStyle.Fill,
                Padding   = new Padding(10, 14, 10, 10),
                Font      = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 0, 64)
            };

            lblIngreso = CrearLabel(); lblIngreso.Location = new Point(10, 28);
            lblObs     = new Label
            {
                Font      = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(40, 40, 80),
                Location  = new Point(10, 52),
                Size      = new Size(290, 80),
                AutoSize  = false
            };

            grpInfo.Controls.AddRange(new Control[] { lblIngreso, lblObs });

            panelDerecha.Controls.Add(grpInfo);
            panelDerecha.Controls.Add(grpCobertura);

            tableBody.Controls.Add(grpPersonal, 0, 0);
            tableBody.Controls.Add(panelDerecha, 1, 0);

            // ── FOOTER ────────────────────────────────────────────────
            panelFooter = new Panel
            {
                Dock      = DockStyle.Bottom,
                Height    = 54,
                BackColor = Color.FromArgb(245, 246, 250),
                Padding   = new Padding(12, 10, 12, 10)
            };

            btnIrConsulta = new Button
            {
                Text      = "▶  Ir a Consulta",
                Font      = new Font("Segoe UI", 10F, FontStyle.Bold),
                BackColor = Color.FromArgb(0, 122, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size      = new Size(160, 36),
                Location  = new Point(12, 10),
                Cursor    = Cursors.Hand,
                DialogResult = DialogResult.OK
            };
            btnIrConsulta.FlatAppearance.BorderSize = 0;

            btnCerrar = new Button
            {
                Text      = "Cerrar",
                Font      = new Font("Segoe UI", 10F),
                BackColor = Color.FromArgb(200, 200, 210),
                ForeColor = Color.FromArgb(40, 40, 80),
                FlatStyle = FlatStyle.Flat,
                Size      = new Size(100, 36),
                Location  = new Point(186, 10),
                Cursor    = Cursors.Hand,
                DialogResult = DialogResult.Cancel
            };
            btnCerrar.FlatAppearance.BorderSize = 0;

            panelFooter.Controls.Add(btnIrConsulta);
            panelFooter.Controls.Add(btnCerrar);

            // ── Ensamblar formulario ──────────────────────────────────
            Controls.Add(tableBody);
            Controls.Add(panelHeader);
            Controls.Add(panelFooter);

            AcceptButton = btnCerrar;
        }

        // ── Poblar con datos reales ────────────────────────────────────

        private void PopularDatos()
        {
            lblNombre.Text = _detalle.NombreCompleto;

            string edad = _detalle.Edad.HasValue ? $"{_detalle.Edad} años" : "—";
            string sexo = string.IsNullOrWhiteSpace(_detalle.Sexo) ? "—" : _detalle.Sexo;
            lblDniEdadSexo.Text = $"DNI: {O(_detalle.Documento)}   |   Edad: {edad}   |   Sexo: {sexo}";

            // Dirección
            lblDireccion.Text = $"📍 Dirección:   {O(_detalle.Calle)}";
            string localidadCp = string.Join("  –  ",
                new[] { O(_detalle.Localidad), O(_detalle.CodPostal) }
                    .Where(s => s != "—"));
            lblLocalidad.Text = $"         {(string.IsNullOrEmpty(localidadCp) ? "—" : localidadCp)}";

            lblTel1.Text = $"📞 Tel. 1:        {O(_detalle.Telefono1)}";

            lblTel2.Visible = !string.IsNullOrWhiteSpace(_detalle.Telefono2);
            lblTel2.Text    = $"📞 Tel. 2:        {_detalle.Telefono2}";

            lblTel3.Visible = !string.IsNullOrWhiteSpace(_detalle.Telefono3);
            lblTel3.Text    = $"📞 Tel. 3:        {_detalle.Telefono3}";

            lblEmail.Text = $"✉  Email:          {O(_detalle.Email)}";

            // Cobertura
            lblOS.Text       = $"Obra Social:   {O(_detalle.ObraSocial)}";
            lblAfiliado.Text = $"Afiliado:        {O(_detalle.OsAfiliado)}";
            lblPlan.Text     = $"Plan:               {O(_detalle.OsPlan)}";

            // Info adicional
            lblIngreso.Text = _detalle.FechaIngreso.HasValue
                ? $"Fecha de ingreso:   {_detalle.FechaIngreso.Value:dd/MM/yyyy}"
                : "Fecha de ingreso:   —";

            lblObs.Text = string.IsNullOrWhiteSpace(_detalle.Observaciones)
                ? "Sin observaciones."
                : _detalle.Observaciones;
        }

        // ── Helpers ────────────────────────────────────────────────────

        /// <summary>Devuelve "—" si el valor está vacío o nulo.</summary>
        private static string O(string? valor) =>
            string.IsNullOrWhiteSpace(valor) ? "—" : valor;

        private static Label CrearLabel() => new Label
        {
            AutoSize  = true,
            Font      = new Font("Segoe UI", 9.5F),
            ForeColor = Color.FromArgb(40, 40, 80)
        };
    }
}
