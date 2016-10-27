using BlankXamarinApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankXamarinApp.Core.Interfaces
{
    public interface IEventService
    {
        Event GetEvent(int id);
        IEnumerable<Event> GetAllEventsForUser(int id);
        void AddEvent();
        void UpdateEvent(Event Event);
        void DeleteEvent(int id);
    }
}
