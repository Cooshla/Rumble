using RumbleApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumbleApp.Core.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace RumbleApp.Core.Services
{
    public class EventService : IEventService
    {
        private IRestService Rest { get; set; }

        public EventService(IRestService _rest)
        {
            Rest = _rest;
        }
        public async Task AddEvent(Event evnt)
        {
            var json = JsonConvert.SerializeObject(evnt);
            var result = await Rest.PostClient<HttpResponseMessage>("api/events/postevent", json);

        }

        public void DeleteEvent(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Event>> GetAllEvents()
        {

            return await Rest.GetClient<List<Event>>("api/Events/getallevents");
        }

        public async Task<List<Event>> GetAllEventsAttendedByUser(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Event> GetEvent(int id)
        {
            return await Rest.GetClient<Event>(String.Format("api/Events/getevent?id={0}",id));
        }

        public void UpdateEvent(Event Event)
        {
            throw new NotImplementedException();
        }

        
        public async Task<List<Event>> GetAllEventsForUser(string id)
        {
            return await Rest.GetClient<List<Event>>(String.Format("api/Events/GetEventForUser?{0}", id));

        }
    }
}
