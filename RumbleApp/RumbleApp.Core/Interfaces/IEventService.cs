using RumbleApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumbleApp.Core.Interfaces
{
    public interface IEventService
    {
        Task<Event> GetEvent(int id);
        Task<List<Event>> GetAllEvents();
        Task<List<Event>> GetAllEventsForUser(int id);
        Task<List<Event>> GetAllEventsAttendedByUser(string id);
        Task AddEvent(Event evnt);
        void UpdateEvent(Event Event);
        void DeleteEvent(int id);
    }
}
