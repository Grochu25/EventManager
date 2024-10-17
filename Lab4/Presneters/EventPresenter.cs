using Lab4.Models;
using Lab4.Views;
using System.Diagnostics.Tracing;

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
            _eventFilteredList = new List<Models.Event>();
            _eventBindingSource = new BindingSource();

            passEnumsToView();
            setEventsAssociations();
            _view.SetEventListBindingSource(_eventBindingSource);
            _eventBindingSource.DataSource = _eventFullList;


            LoadDataFromDefaultFileIfExist();
        }

        private void passEnumsToView()
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

            _view.SetTypesAndPriorites(types, priori);
        }

        private List<Models.Event> getCurrentList()
        {
            List<Models.Event> baseList;
            if (filtered)
                baseList = _eventFilteredList;
            else
                baseList = _eventFullList;
            return baseList;
        }

        private void refreshList()
        {
            _eventBindingSource.DataSource = new List<Models.Event>(getCurrentList());
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
            _view.exitEvent += writeToFileOnExit;
        }

        private void AddEvent()
        {
            Models.Event eve = createEvent();
            _eventFullList.Add(eve);
            filterEvents(_filters[0], _filters[1], _filters[2]);
            refreshList();

            resetViewForm();
        }

        private Models.Event createEvent()
        {
            Models.Event.EventType eventType = (Models.Event.EventType)Enum.Parse(typeof(Models.Event.EventType), _view.Type);
            Models.Event.EventPriority eventPriority = (Models.Event.EventPriority)Enum.Parse(typeof(Models.Event.EventPriority), _view.Priority);
            return new Models.Event(_view.Title, _view.Description, _view.Date, eventType, eventPriority);
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
            _eventFullList.Remove(getCurrentList().ElementAt(elementNumber));
            filterEvents(_filters[0], _filters[1], _filters[2]);
            refreshList();
        }

        private void detailsAbout(int elementNumber)
        {
            string message = getCurrentList().ElementAt(elementNumber).ToString();
            MessageBox.Show(message, "Wydarzenie", MessageBoxButtons.OK);
        }

        private void sortEventList(int senderColumn)
        {
            switch (senderColumn)
            {
                case 0:
                    getCurrentList().Sort((e1, e2) => e1.Title.CompareTo(e2.Title));
                    break;
                case 1:
                    getCurrentList().Sort((e1, e2) => e1.Date.CompareTo(e2.Date));
                    break;
                case 2:
                    getCurrentList().Sort((e1, e2) => e1.Type.CompareTo(e2.Type));
                    break;
                case 3:
                    getCurrentList().Sort((e1, e2) => e1.Priority.CompareTo(e2.Priority));
                    break;
            }

            refreshList();
        }

        private void filterEvents(string types, string prioriteis, string dates)
        {
            _filters = new string[]{ types, prioriteis, dates};
            _eventFilteredList = new List<Event>(_eventFullList);

            deleteElementsByFilters();

            setFilteredFlag();

            refreshList();
        }

        private void deleteElementsByFilters()
        {
            foreach (Event ev in _eventFullList)
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
        }

        private void setFilteredFlag()
        {
            if (_eventFilteredList.Count == _eventFullList.Count)
                filtered = false;
            else
                filtered = true;
        }

        private void LoadDataFromDefaultFileIfExist() 
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

        private void writeToFileOnExit()
        {
            FileSaverReader.WriteFileToDefault<Models.Event>(_eventFullList);
        }
    }
}
