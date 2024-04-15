using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Models
{
    internal interface IEventRepository
    {
        IEnumerable<Event> getAllEvents();
        IEnumerable<Event> getEventsWithFilter(string[] types, string[] priorities, string[] dates);
    }
}
