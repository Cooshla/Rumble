using RumbleApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumbleApp.Core.Models;

namespace RumbleApp.Core.Services
{
    public class EventService : IEventService
    {
        public void AddEvent()
        {
            throw new NotImplementedException();
        }

        public void DeleteEvent(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Event>> GetAllEventsForUser(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Event> GetEvent(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateEvent(Event Event)
        {
            throw new NotImplementedException();
        }
    }
}
