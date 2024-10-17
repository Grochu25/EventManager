using System.Text;

namespace Lab4.Views
{
    public partial class EventView : Form, IEventView
    {
        private IEnumerable<string> types;
        private IEnumerable<string> priorities;
        private Color[] _colors = { Color.Crimson, Color.PaleGreen, Color.HotPink, Color.Goldenrod, Color.YellowGreen };

        public EventView()
        {
            InitializeComponent();
            _associateViewEvents();
            types = new List<string>();
            priorities = new List<string>();
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
        public event Action exitEvent;
        public event Action ReadFromFile;
        public event Action<int> ShowDetails;

        private void _associateViewEvents()
        {
            dataGridView.DataBindingComplete += (sender, e) => { _setColors(); };
            this.FormClosing += (sender, e) => { exitEvent?.Invoke(); };
            buttonExport.Click += (sender, e) => { SaveToFile?.Invoke(); };
            buttonImport.Click += (sender, e) => { ReadFromFile?.Invoke(); };
            dataGridView.ColumnHeaderMouseClick += (sender, e) => { SortEvents?.Invoke(e.ColumnIndex); };
            dataGridView.CellMouseDoubleClick += (sender, e) => { ShowDetails?.Invoke(e.RowIndex); };

            buttonAdd.Click += (sender, e) =>
            {
                if (_controlNotEmpty(textBoxName) & _controlNotEmpty(textBoxDescription) & _controlNotEmpty(dateTimePicker) & _controlNotEmpty(comboBoxType) & _controlNotEmpty(comboBoxPriority))
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

        private bool _controlNotEmpty(Control control)
        {
            if (control.Text.Trim().Length == 0)
            {
                errorProvider.SetError(control, "Puste pole");
                return false;
            }
            errorProvider.SetError(control, "");
            return true;
        }

        public void SetEventListBindingSource(BindingSource bs)
        {
            dataGridView.DataSource = bs;
        }

        public void SetTypesAndPriorites(IEnumerable<string> types, IEnumerable<string> priorities)
        {
            this.types = types;
            this.priorities = priorities;

            addTypesAndPrioritiesToComboBoxes();
            createFiltersCheckBoxes();
        }

        private void addTypesAndPrioritiesToComboBoxes()
        {
            comboBoxType.Items.AddRange(types.ToArray());
            comboBoxPriority.Items.AddRange(priorities.ToArray());
        }

        private void createFiltersCheckBoxes()
        {
            foreach (string type in types)
            {
                string name = "checkBox" + type.Substring(0, 1).ToUpper() + type.Substring(1);
                CheckBox newBox = createCheckBox(name, type);
                flowLayoutPanelType.Controls.Add(newBox);
            }

            foreach (string priority in priorities)
            {
                string name = "checkBox" + priority.Substring(0, 1).ToUpper() + priority.Substring(1);
                CheckBox newBox = createCheckBox(name, priority);
                flowLayoutPanelPriority.Controls.Add(newBox);
            }
        }

        private CheckBox createCheckBox(string name, string label)
        {
            CheckBox newBox = new CheckBox();
            newBox.AutoSize = true;
            newBox.Name = name;
            newBox.Text = label;
            newBox.UseVisualStyleBackColor = true;
            newBox.CheckedChanged += checkboxFilterClicked;
            return newBox;
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
