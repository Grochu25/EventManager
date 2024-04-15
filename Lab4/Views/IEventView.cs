using Lab4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Views
{
    internal interface IEventView
    {
        string Title { get; set; }
        string Description { get; set; }
        DateTime Date { get; set; }
        string Type { get; set; }
        string Priority { get; set; }
        string Filters { get; }
        
        event EventHandler<EventArgs> AddNewEvent;
        event EventHandler<EventArgs> DeleteEvent;
        event EventHandler<EventArgs> SortEvents;
        event EventHandler<EventArgs> FilterEvents;
        event EventHandler<EventArgs> SaveToFile;
        event EventHandler<EventArgs> ReadFromFile;
        event EventHandler<EventArgs> ShowDetails;

        void SetEventListBindingSource(BindingSource bs);
        void SetComboBoxes(IEnumerable<string> types, IEnumerable<string> priorities);
    }
}
