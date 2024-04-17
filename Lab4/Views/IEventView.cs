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
        
        event Action AddNewEvent;
        event Action<int> DeleteEvent;
        event Action<int> SortEvents;
        event Action<string, string, string> FilterEvents;
        event Action SaveToFile;
        event Action ReadFromFile;
        event Action<int> ShowDetails;

        void SetEventListBindingSource(BindingSource bs);
        void SetComboBoxes(IEnumerable<string> types, IEnumerable<string> priorities);
    }
}
