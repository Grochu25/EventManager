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
        private List<Models.Event> _eventList;
        private System.Xml.Serialization.XmlSerializer _serializer;

        public EventPresenter(Views.IEventView view)
        {
            _view = view;
            _eventList = new List<Models.Event>();
            _eventBindingSource = new BindingSource();
            _serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<Models.Event>));

            setViewComboBoxes();
            setEventsAssociations();
            _view.SetEventListBindingSource(_eventBindingSource);
            _eventBindingSource.DataSource = _eventList;

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
            _eventBindingSource.DataSource = new List<Models.Event>(_eventList);
        }

        private void AddEvent(object sender, EventArgs e)
        {
            Models.Event.EventType eventType = (Models.Event.EventType)Enum.Parse(typeof(Models.Event.EventType), _view.Type);
            Models.Event.EventPriority eventPriority = (Models.Event.EventPriority)Enum.Parse(typeof(Models.Event.EventPriority), _view.Priority);
            Models.Event eve = new Models.Event(_view.Title, _view.Description, _view.Date, eventType, eventPriority);

            _eventList.Add(eve);
            refreshList();

            resetViewForm();
        }

        private void DeleteEvent(object senderRow, EventArgs e)
        {
            int elementNumber = Int32.Parse(senderRow.ToString());
            _eventList.RemoveAt(elementNumber);
            refreshList();
        }

        private void detailsAbout(object senderRow, EventArgs e)
        {
            if (senderRow != null)
            {
                string message = _eventList.ElementAt(Int32.Parse(senderRow.ToString())).ToString();
                MessageBox.Show(message, "Wydarzenie", MessageBoxButtons.OK);
            }
        }

        private void sortEventList(object senderColumn, EventArgs e)
        {
            int? columnNumber = Int32.Parse(senderColumn.ToString());
            switch (columnNumber)
            {
                case 0:
                    _eventList.Sort((e1, e2) => e1.Title.CompareTo(e2.Title));
                    break;
                case 1:
                    _eventList.Sort((e1, e2) => e1.Date.CompareTo(e2.Date));
                    break;
                case 2:
                    _eventList.Sort((e1, e2) => e1.Type.CompareTo(e2.Type));
                    break;
                case 3:
                    _eventList.Sort((e1, e2) => e1.Priority.CompareTo(e2.Priority));
                    break;
            }

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

            _eventList = (List<Models.Event>)_serializer.Deserialize(reader);

            reader.Close();
            refreshList();
        }

        private void writeToXMLFile(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter(openWriteFileByUser());

            _serializer.Serialize(writer, _eventList);

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
