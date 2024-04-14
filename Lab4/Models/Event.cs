using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Models
{
    public class Event : IComparable<Event>
    {
        public enum EventType { PRACA, RODZINA, ROZRYWKA, ZDROWIE, SPORT }
        public enum EventPriority { WYSOKI, SREDNI, NISKI}


        public string Title { get; set; }
        [Browsable(false)]
        public string Descryption { get; set; }
        public DateTime Date { get; set; }
        public EventType Type { get; set; }
        public EventPriority Priority { get; set; }

        public Event() { }

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

        public string ToString()
        {
            return $"Wydarzenie: {Title}\nData: {Date}\nKategoria: {Type}\nPriorytet: {Priority}\n\nOPIS:\n{Descryption}";
        }
    }
}
