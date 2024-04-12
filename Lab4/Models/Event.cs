using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Models
{
    internal class Event : IComparable<Event>
    {
        public enum EventType { PRACA, RODZINA, ROZRYWKA, ZDROWIE, SPORT }
        public enum EventPriority { WYSOKI, SREDNI, NISKI}


        public string Title { get; set; }
        public string Descryption { get; set; }
        public DateTime Date { get; set; }
        public EventType Type { get; set; }
        public EventPriority Priority { get; set; }

        public Event(string title, string descryption, DateTime date, EventType type, EventPriority priority)
        {
            Title = title;
            Descryption = descryption;
            Date = date;
            Type = type;
            Priority = priority;
        }

        public int CompareTo(Event? other)
        {
            if (other == null) return -1;
            if (other == this) return 0;
            if (!(other is Event)) return 1;
            return this.Title.CompareTo(other.Title);
        }
    }
}
