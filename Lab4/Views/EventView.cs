using Lab4.Models;
using Lab4.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab4
{
    public partial class EventView : Form, IEventView
    { 
        private Color[] _colors = { Color.Crimson, Color.PaleGreen, Color.HotPink, Color.Goldenrod, Color.YellowGreen};

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

        public event EventHandler<EventArgs> AddNewEvent;
        public event EventHandler<EventArgs> DeleteEvent;
        public event EventHandler<EventArgs> SortEvents;
        public event EventHandler<EventArgs> SaveToFile;
        public event EventHandler<EventArgs> ReadFromFile;
        public event EventHandler<EventArgs> ShowDetails;

        private void _associateViewEvents()
        {
            dataGridView.DataBindingComplete += (sender, e) => { _setColors(); };

            buttonAdd.Click += (sender, e) => { AddNewEvent?.Invoke(this, EventArgs.Empty); };
            buttonExport.Click += (sender, e) => { SaveToFile?.Invoke(this, EventArgs.Empty); };
            buttonImport.Click += (sender, e) => { ReadFromFile?.Invoke(this, EventArgs.Empty);  };

            dataGridView.ColumnHeaderMouseClick += (sender, e) => 
            {
                SortEvents?.Invoke(e.ColumnIndex, EventArgs.Empty); 
                dataGridView.Refresh(); 
            };

            dataGridView.CellMouseDoubleClick += (sender, e) => 
            { 
                ShowDetails?.Invoke(e.RowIndex, e); 
            };

            buttonDelete.Click += (sender, e) =>
            { 
                DataGridView? dgv = dataGridView;
                DeleteEvent?.Invoke(dgv?.CurrentCell.RowIndex, e); 
            };
        }

        private void _setColors()
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                int typeIndex = comboBoxType.Items.IndexOf(row.Cells[2].Value.ToString());
                if(typeIndex > _colors.Length)
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255,32,51,84);
                else
                    row.DefaultCellStyle.BackColor = _colors[typeIndex];
            }
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
    }
}
