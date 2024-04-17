using Lab4.Models;
using Lab4.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Lab4.Presneters
{
    internal class EventPresenter
    {
        private Views.IEventView _view;
        private BindingSource _eventBindingSource;
        private List<Models.Event> _eventFullList;
        private List<Models.Event> _eventFilteredList;
        private System.Xml.Serialization.XmlSerializer _serializer;
        private bool filtered = false;

        public EventPresenter(Views.IEventView view)
        {
            _view = view;
            _eventFullList = new List<Models.Event>();
            _eventBindingSource = new BindingSource();
            _serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<Models.Event>));

            setViewComboBoxes();
            setEventsAssociations();
            _view.SetEventListBindingSource(_eventBindingSource);
            _eventBindingSource.DataSource = _eventFullList;

            LoadDataFromDefaultFile();
        }

        private void setEventsAssociations()
        {
            _view.AddNewEvent += AddEvent;
            _view.DeleteEvent += DeleteEvent;
            _view.SaveToFile += writeToXMLFile;
            _view.ReadFromFile += readFromXMLFile;
            _view.ShowDetails += detailsAbout;
            _view.SortEvents += sortEventList;
            _view.FilterEvents += filterEvents;
        }

        private void setViewComboBoxes()
        {
            List<string> types = new List<string>();
            List<string> priori = new List<string>();

            foreach (Models.Event.EventType et in Enum.GetValues<Models.Event.EventType>().ToList())
            {
                types.Add(et.ToString());
            }

            foreach (Models.Event.EventPriority ep in Enum.GetValues<Models.Event.EventPriority>().ToList())
            {
                priori.Add(ep.ToString());
            }

            _view.SetComboBoxes(types, priori);
        }

        private void refreshList()
        {
            List<Models.Event> baseList;
            if (filtered)
                baseList = _eventFilteredList;
            else
                baseList = _eventFullList;
            _eventBindingSource.DataSource = new List<Models.Event>(baseList);
        }

        private void AddEvent(object sender, EventArgs e)
        {
            Models.Event.EventType eventType = (Models.Event.EventType)Enum.Parse(typeof(Models.Event.EventType), _view.Type);
            Models.Event.EventPriority eventPriority = (Models.Event.EventPriority)Enum.Parse(typeof(Models.Event.EventPriority), _view.Priority);
            Models.Event eve = new Models.Event(_view.Title, _view.Description, _view.Date, eventType, eventPriority);

            _eventFullList.Add(eve);
            refreshList();

            resetViewForm();
        }

        private void DeleteEvent(object senderRow, EventArgs e)
        {
            int elementNumber = Int32.Parse(senderRow.ToString());
            _eventFullList.RemoveAt(elementNumber);
            refreshList();
        }

        private void detailsAbout(object senderRow, EventArgs e)
        {
            if (senderRow != null)
            {
                string message = _eventFullList.ElementAt(Int32.Parse(senderRow.ToString())).ToString();
                MessageBox.Show(message, "Wydarzenie", MessageBoxButtons.OK);
            }
        }

        private void sortEventList(object senderColumn, EventArgs e)
        {
            List<Models.Event> baseList;
            if (filtered)
                baseList = _eventFilteredList;
            else
                baseList = _eventFullList;

            int? columnNumber = Int32.Parse(senderColumn.ToString());
            switch (columnNumber)
            {
                case 0:
                    baseList.Sort((e1, e2) => e1.Title.CompareTo(e2.Title));
                    break;
                case 1:
                    baseList.Sort((e1, e2) => e1.Date.CompareTo(e2.Date));
                    break;
                case 2:
                    baseList.Sort((e1, e2) => e1.Type.CompareTo(e2.Type));
                    break;
                case 3:
                    baseList.Sort((e1, e2) => e1.Priority.CompareTo(e2.Priority));
                    break;
            }

            refreshList();
        }

        private void filterEvents(object senderColumn, EventArgs e)
        {
            _eventFilteredList = new List<Event>(_eventFullList);
            string[] filters = _view.Filters.Split("!");

            foreach(Event ev in _eventFullList)
            {
                if (filters[0].Length > 0 && !filters[0].Split(",").Contains(ev.Type.ToString()))
                    _eventFilteredList.Remove(ev);
                else if (filters[1].Length > 0 && !filters[1].Split(",").Contains(ev.Priority.ToString()))
                    _eventFilteredList.Remove(ev);
                else if (filters[2].Length > 0)
                {
                    string[] dates = filters[2].Split(",");
                    if (ev.Date < DateTime.Parse(dates[0]).Date || ev.Date > DateTime.Parse(dates[1]).Date)
                        _eventFilteredList.Remove(ev);
                }
            }

            if (_eventFilteredList.Count == _eventFullList.Count)
                filtered = false;
            else
                filtered = true;

            refreshList();
        }

        private void resetViewForm()
        {
            _view.Title = "";
            _view.Description = "";
            _view.Date = DateTime.Now;
            _view.Type = "";
            _view.Priority = "";
        }

        private void LoadDataFromDefaultFile() 
        {
            if(File.Exists("default.xml"))
            {
                readFromXMLFile(null, EventArgs.Empty);
            }
        }

        private void readFromXMLFile(object sender, EventArgs e)
        {
            TextReader reader;
            if (sender == null)
                reader = new StreamReader("default.xml");
            else
                reader = new StreamReader(openReadFileByUser());

            _eventFullList = (List<Models.Event>)_serializer.Deserialize(reader);

            reader.Close();
            refreshList();
        }

        private void writeToXMLFile(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter(openWriteFileByUser());

            _serializer.Serialize(writer, _eventFullList);

            writer.Close();
        }

        private Stream openWriteFileByUser()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "xml files|*.xml|All files|*.*";
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return saveFileDialog.OpenFile();
                }
            }
            return Stream.Null;
        }

        private Stream openReadFileByUser()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "xml files|*.xml|All files|*.*";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.OpenFile();
                }
            }
            return Stream.Null;
        }
    }
}
