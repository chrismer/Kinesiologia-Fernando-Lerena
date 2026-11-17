using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TESTSOLAPAS
{
    /// <summary>
    /// El admin cambia el titular de una franja o el reemplazo de un día.
    /// Ninguno de los dos mueve turnos que ya existen.
    /// </summary>
    public class FranjasDialog : Form
    {
        private readonly IFranjaRepository _franjas;
        private readonly List<ProfesionalItem> _profesionales;

        private DataGridView _grilla = null!;
        private ComboBox _cmbTitular = null!;
        private DateTimePicker _dtpFecha = null!;
        private ComboBox _cmbFranja = null!;
        private ComboBox _cmbReemplazo = null!;
        private ListBox _lista = null!;

        public FranjasDialog(IFranjaRepository franjas, IReadOnlyList<ProfesionalItem> profesionales)
        {
            _franjas = franjas;
            _profesionales = profesionales.OrderBy(p => p.Nombre).ToList();
            BuildUi();
            Recargar();
        }

        private void BuildUi()
        {
            Text = "Franjas horarias";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(640, 520);
            MinimizeBox = false;
            MaximizeBox = false;
            Font = new Font("Segoe UI", 9.5F);

            var header = new Panel { Dock = DockStyle.Top, Height = 58, BackColor = Color.FromArgb(0, 0, 64) };
            header.Controls.Add(new Label
            {
                Text = "Un kinesiólogo por franja",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(16, 8)
            });
            header.Controls.Add(new Label
            {
                Text = "El cambio vale para turnos nuevos. Los que ya están no se mueven.",
                ForeColor = Color.LightGray,
                AutoSize = true,
                Location = new Point(16, 34)
            });

            _grilla = new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 140,
                ReadOnly = true,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = SystemColors.Window
            };
            _grilla.Columns.Add("nombre", "Franja");
            _grilla.Columns.Add("horario", "Horario");
            _grilla.Columns.Add("titular", "Titular");
            _grilla.SelectionChanged += (_, _) => SincronizarTitular();

            var panelTitular = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 48,
                Padding = new Padding(12, 8, 12, 4),
                WrapContents = false
            };
            _cmbTitular = ComboProfesionales();
            var btnTitular = Boton("Guardar titular", GuardarTitular);
            panelTitular.Controls.Add(new Label { Text = "Titular de la fila", AutoSize = true, Padding = new Padding(0, 6, 8, 0) });
            panelTitular.Controls.Add(_cmbTitular);
            panelTitular.Controls.Add(btnTitular);

            var panelEx = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 80,
                Padding = new Padding(12, 4, 12, 4),
                WrapContents = true
            };
            _dtpFecha = new DateTimePicker { Format = DateTimePickerFormat.Short, Width = 120 };
            _cmbFranja = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 130 };
            _cmbReemplazo = ComboProfesionales();
            panelEx.Controls.Add(new Label { Text = "Ese día", AutoSize = true, Padding = new Padding(0, 6, 6, 0) });
            panelEx.Controls.Add(_dtpFecha);
            panelEx.Controls.Add(_cmbFranja);
            panelEx.Controls.Add(_cmbReemplazo);
            panelEx.Controls.Add(Boton("Guardar reemplazo", GuardarReemplazo));
            panelEx.Controls.Add(Boton("Quitar", QuitarReemplazo));

            _lista = new ListBox { Dock = DockStyle.Fill, IntegralHeight = false };

            var pie = new Panel { Dock = DockStyle.Bottom, Height = 48 };
            var cerrar = new Button { Text = "Cerrar", DialogResult = DialogResult.Cancel, Size = new Size(100, 32), Location = new Point(524, 8) };
            pie.Controls.Add(cerrar);

            Controls.Add(_lista);
            Controls.Add(panelEx);
            Controls.Add(panelTitular);
            Controls.Add(_grilla);
            Controls.Add(pie);
            Controls.Add(header);
            CancelButton = cerrar;
        }

        private ComboBox ComboProfesionales()
        {
            var combo = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 180 };
            combo.DisplayMember = nameof(ProfesionalItem.Nombre);
            foreach (var prof in _profesionales)
                combo.Items.Add(prof);
            if (combo.Items.Count > 0)
                combo.SelectedIndex = 0;
            return combo;
        }

        private static Button Boton(string texto, EventHandler click)
        {
            var boton = new Button
            {
                Text = texto,
                AutoSize = true,
                BackColor = Color.FromArgb(0, 122, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Padding = new Padding(6, 2, 6, 2)
            };
            boton.FlatAppearance.BorderSize = 0;
            boton.Click += click;
            return boton;
        }

        private void Recargar()
        {
            List<FranjaItem> franjas;
            List<FranjaExcepcionItem> excepciones;
            try
            {
                franjas = _franjas.ObtenerFranjas();
                excepciones = _franjas.ObtenerExcepciones(DateTime.Today, DateTime.Today.AddMonths(3));
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron leer las franjas. Si la base es Neon, corré sql/007_franja.sql.\n" + ex.Message,
                    "Franjas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            _grilla.Rows.Clear();
            _cmbFranja.Items.Clear();
            foreach (var franja in franjas)
            {
                var i = _grilla.Rows.Add(franja.Nombre, franja.Horario, franja.ProfesionalNombre);
                _grilla.Rows[i].Tag = franja;
                _cmbFranja.Items.Add(franja);
            }

            _cmbFranja.DisplayMember = nameof(FranjaItem.Nombre);
            if (_cmbFranja.Items.Count > 0)
                _cmbFranja.SelectedIndex = 0;
            if (_grilla.Rows.Count > 0)
                _grilla.Rows[0].Selected = true;

            _lista.Items.Clear();
            foreach (var ex in excepciones)
                _lista.Items.Add($"{ex.Fecha:dd/MM/yyyy}  {ex.FranjaNombre}  →  {ex.ProfesionalNombre}");
            if (_lista.Items.Count == 0)
                _lista.Items.Add("No hay reemplazos en los próximos 3 meses.");
        }

        private FranjaItem? FranjaSeleccionada =>
            _grilla.CurrentRow?.Tag as FranjaItem;

        private void SincronizarTitular()
        {
            var franja = FranjaSeleccionada;
            if (franja is null)
                return;

            for (var i = 0; i < _cmbTitular.Items.Count; i++)
            {
                if (_cmbTitular.Items[i] is ProfesionalItem prof && prof.Id == franja.ProfesionalId)
                {
                    _cmbTitular.SelectedIndex = i;
                    return;
                }
            }
        }

        private void GuardarTitular(object? sender, EventArgs e)
        {
            if (FranjaSeleccionada is not FranjaItem franja || _cmbTitular.SelectedItem is not ProfesionalItem prof)
                return;

            try
            {
                _franjas.GuardarTitular(franja.Id, prof.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Franjas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Recargar();
        }

        private void GuardarReemplazo(object? sender, EventArgs e)
        {
            if (_cmbFranja.SelectedItem is not FranjaItem franja || _cmbReemplazo.SelectedItem is not ProfesionalItem prof)
                return;

            try
            {
                _franjas.GuardarExcepcion(_dtpFecha.Value, franja.Id, prof.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Franjas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Recargar();
        }

        private void QuitarReemplazo(object? sender, EventArgs e)
        {
            if (_cmbFranja.SelectedItem is not FranjaItem franja)
                return;

            try
            {
                _franjas.QuitarExcepcion(_dtpFecha.Value, franja.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Franjas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Recargar();
        }
    }
}
