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
        List<Event> l;
        BindingSource bs;

        public EventView()
        {
            InitializeComponent();
            ROBOCZO();
        }

        private void ROBOCZO()
        {
            bs = new BindingSource();
            l = new List<Event>() {
                new Event("b","a",DateTime.Now,Event.EventType.SPORT,Event.EventPriority.NISKI),
                new Event("a","b",DateTime.Now,Event.EventType.SPORT,Event.EventPriority.NISKI)
            };
            //l.Sort((e1, e2) => e1.Title.CompareTo(e2.Title));
            bs.DataSource = l;
            
            dataGridView.DataSource = bs;
        }

        public string Title { get => textBoxName.Text; set => textBoxName.Text = value; }
        public string Description { get => textBoxDescription.Text; set => textBoxDescription.Text = value; }
        public DateTime Date { get => dateTimePicker.Value; set => dateTimePicker.Value = Convert.ToDateTime(value); }
        public string Type { get => comboBoxType.Text; set => comboBoxType.Text = value; }
        public string Priority { get => comboBoxPriority.Text; set => comboBoxPriority.Text = value; }

        public event EventHandler<EventArgs> AddNewEvent;

        private void dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            switch(e.ColumnIndex)
            {
                case 0:
                    l.Sort((e1, e2) => e1.Title.CompareTo(e2.Title));
                    break;
                case 1:
                    l.Sort((e1, e2) => e1.Descryption.CompareTo(e2.Descryption));
                    break;
                case 2:
                    l.Sort((e1, e2) => e1.Date.CompareTo(e2.Date));
                    break;
                case 3:
                    l.Sort((e1, e2) => e1.Type.CompareTo(e2.Type));
                    break;
                case 4:
                    l.Sort((e1, e2) => e1.Priority.CompareTo(e2.Priority));
                    break;
            }
            bs.DataSource = l;
            dataGridView.Refresh();
        }

    }
}
