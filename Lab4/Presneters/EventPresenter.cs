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
        private bool filtered = false;
        private string[] _filters = { "","",""};

        public EventPresenter(Views.IEventView view)
        {
            _view = view;
            _eventFullList = new List<Models.Event>();
            _eventBindingSource = new BindingSource();

            setViewComboBoxes();
            setEventsAssociations();
            _view.SetEventListBindingSource(_eventBindingSource);
            _eventBindingSource.DataSource = _eventFullList;


            LoadDataFromDefaultFile();
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

        private void setEventsAssociations()
        {
            _view.AddNewEvent += AddEvent;
            _view.DeleteEvent += DeleteEvent;
            _view.SaveToFile += writeToFile;
            _view.ReadFromFile += readFromFile;
            _view.ShowDetails += detailsAbout;
            _view.SortEvents += sortEventList;
            _view.FilterEvents += filterEvents;
        }

        private void AddEvent()
        {
            Models.Event.EventType eventType = (Models.Event.EventType)Enum.Parse(typeof(Models.Event.EventType), _view.Type);
            Models.Event.EventPriority eventPriority = (Models.Event.EventPriority)Enum.Parse(typeof(Models.Event.EventPriority), _view.Priority);
            Models.Event eve = new Models.Event(_view.Title, _view.Description, _view.Date, eventType, eventPriority);

            _eventFullList.Add(eve);
            filterEvents(_filters[0], _filters[1], _filters[2]);
            refreshList();

            resetViewForm();
        }

        private void resetViewForm()
        {
            _view.Title = "";
            _view.Description = "";
            _view.Date = DateTime.Now;
            _view.Type = "";
            _view.Priority = "";
        }

        private void DeleteEvent(int elementNumber)
        {
            List<Models.Event> baseList;
            if (filtered)
                baseList = _eventFilteredList;
            else
                baseList = _eventFullList;

            _eventFullList.Remove(baseList.ElementAt(elementNumber));
            filterEvents(_filters[0], _filters[1], _filters[2]);
            refreshList();
        }

        private void detailsAbout(int rowNumber)
        {
            string message = _eventFullList.ElementAt(rowNumber).ToString();
            MessageBox.Show(message, "Wydarzenie", MessageBoxButtons.OK);
        }

        private void sortEventList(int senderColumn)
        {
            List<Models.Event> baseList;
            if (filtered)
                baseList = _eventFilteredList;
            else
                baseList = _eventFullList;

            switch (senderColumn)
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

        private void filterEvents(string types, string prioriteis, string dates)
        {
            _filters = new string[]{ types, prioriteis, dates};
            _eventFilteredList = new List<Event>(_eventFullList);

            foreach(Event ev in _eventFullList)
            {
                if (_filters[0].Length > 0 && !_filters[0].Split(",").Contains(ev.Type.ToString()))
                    _eventFilteredList.Remove(ev);
                else if (_filters[1].Length > 0 && !_filters[1].Split(",").Contains(ev.Priority.ToString()))
                    _eventFilteredList.Remove(ev);
                else if (_filters[2].Length > 0)
                {
                    string[] dates_split = _filters[2].Split(",");
                    if (ev.Date < DateTime.Parse(dates_split[0]).Date || ev.Date > DateTime.Parse(dates_split[1]).Date)
                        _eventFilteredList.Remove(ev);
                }
            }

            if (_eventFilteredList.Count == _eventFullList.Count)
                filtered = false;
            else
                filtered = true;

            refreshList();
        }

        private void LoadDataFromDefaultFile() 
        {
            if(File.Exists("default.xml"))
            {
                _eventFullList = (List<Models.Event>)FileSaverReader.ReadFile<Models.Event>("default.xml");
                refreshList();
            }
        }

        private void readFromFile()
        {
            _eventFullList = (List<Models.Event>) FileSaverReader.ReadFile<Models.Event>(null);
            refreshList();
        }

        private void writeToFile()
        {
            FileSaverReader.WriteFile<Models.Event>(_eventFullList);
        }
    }
}
