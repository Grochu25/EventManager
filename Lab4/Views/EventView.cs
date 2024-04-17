using Lab4.Models;
using Lab4.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab4
{
    public partial class EventView : Form, IEventView
    {
        private Color[] _colors = { Color.Crimson, Color.PaleGreen, Color.HotPink, Color.Goldenrod, Color.YellowGreen };

        public EventView()
        {
            InitializeComponent();
            _associateViewEvents();
        }

        public string Title { get => textBoxName.Text; set => textBoxName.Text = value; }
        public string Description { get => textBoxDescription.Text; set => textBoxDescription.Text = value; }
        public DateTime Date { get => dateTimePicker.Value; set => dateTimePicker.Value = Convert.ToDateTime(value); }
        public string Type { get => comboBoxType.Text; set => comboBoxType.Text = value; }
        public string Priority { get => comboBoxPriority.Text; set => comboBoxPriority.Text = value; }

        public event Action AddNewEvent;
        public event Action<int> DeleteEvent;
        public event Action<int> SortEvents;
        public event Action<string, string, string> FilterEvents;
        public event Action SaveToFile;
        public event Action ReadFromFile;
        public event Action<int> ShowDetails;

        private void _associateViewEvents()
        {
            dataGridView.DataBindingComplete += (sender, e) => { _setColors(); };
            buttonExport.Click += (sender, e) => { SaveToFile?.Invoke(); };
            buttonImport.Click += (sender, e) => { ReadFromFile?.Invoke(); };
            dataGridView.ColumnHeaderMouseClick += (sender, e) => { SortEvents?.Invoke(e.ColumnIndex); };
            dataGridView.CellMouseDoubleClick += (sender, e) => { ShowDetails?.Invoke(e.RowIndex); };

            buttonAdd.Click += (sender, e) => {
                if (_notEmpty(textBoxName) & _notEmpty(textBoxDescription) & _notEmpty(dateTimePicker) & _notEmpty(comboBoxType) & _notEmpty(comboBoxPriority))
                    AddNewEvent?.Invoke();
            };

            buttonDelete.Click += (sender, e) =>
            {
                DataGridView? dgv = dataGridView;
                DeleteEvent?.Invoke(dgv.CurrentCell.RowIndex);
            };
        }

        private void _setColors()
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                int typeIndex = comboBoxType.Items.IndexOf(row.Cells[2].Value.ToString());
                if (typeIndex > _colors.Length)
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 32, 51, 84);
                else
                    row.DefaultCellStyle.BackColor = _colors[typeIndex];
            }
        }

        private bool _notEmpty(Control control)
        {
            if (control.Text.Trim().Length == 0)
            {
                errorProvider.SetError(control, "Puste pole");
                return false;
            }
            errorProvider.SetError(control,"");
            return true;
        }

        public void SetEventListBindingSource(BindingSource bs)
        {
            dataGridView.DataSource = bs;
        }

        public void SetComboBoxes(IEnumerable<string> types, IEnumerable<string> priorities)
        {
            comboBoxType.Items.AddRange(types.ToArray());
            comboBoxPriority.Items.AddRange(priorities.ToArray());
        }

        public void checkboxFilterClicked(object sender, EventArgs e)
        {
            string[] filters = prepareFilters();
            FilterEvents?.Invoke(filters[0], filters[1], filters[2]);
        }

        private string[] prepareFilters()
        {
            StringBuilder filterString = new StringBuilder();

            filterString.Append("");
            foreach (Control x in flowLayoutPanelType.Controls)  
            { 
                {
                    CheckBox checkbox = x as CheckBox;
                    if (checkbox.Checked)
                        filterString.Append(checkbox.Text + ",");
                }
            }

            filterString.Append("!");
            foreach (Control x in flowLayoutPanelPriority.Controls)
            {
                {
                    CheckBox checkbox = x as CheckBox;
                    if (checkbox.Checked)
                        filterString.Append(checkbox.Text + ",");
                }
            }

            filterString.Append("!");
            if (checkBoxData.Checked == true)
            {
                dateTimePickerFilterFrom.Enabled = true;
                dateTimePickerFilterTo.Enabled = true;
                filterString.Append(dateTimePickerFilterFrom.Value.ToString() + ",");
                filterString.Append(dateTimePickerFilterTo.Value.ToString());
            }
            else
            {
                dateTimePickerFilterFrom.Enabled = false;
                dateTimePickerFilterTo.Enabled = false;
            }

            return filterString.ToString().Split("!");
        }
    }
}
