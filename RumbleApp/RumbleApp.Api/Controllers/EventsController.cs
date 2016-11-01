using RumbleApp.Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace RumbleApp.Api.Controllers
{
    public class EventsController : BaseApiController
    {
        // GET: api/Events
        public async Task<JsonResult<List<Event>>> GetAllEvents()
        {
            return Json(db.Event.ToList());
        }

        // GET: api/Events/5
        public async Task<JsonResult<Event>> GetEvent(int id)
        {
            var evts =  db.Event.Where(c => c.EventId == id).FirstOrDefault();

            return Json(evts);
        }
       

        [HttpGet]
        [Route("api/events/geteventforuser")]
        public async Task<JsonResult<List<Event>>> GetEventForUser(int id)
        {
            var evts = db.Event.Where(c => c.ProfileId == id).ToList();
            return Json(evts);
        }

        // POST: api/Events
        public HttpResponseMessage PostEvent([FromBody]Event value)
        {
            value.Created = DateTime.Now;
            value.Updated = DateTime.Now;
            value.CreatedBy = "1";
            value.LastEditBy = "1";
            value.IsActive = true;

            db.Event.Add(value);

            db.SaveChanges();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // PUT: api/Events/5
        public void PutEvent(int id, [FromBody]Event value)
        {
            var s = db.Event.Where(c => c.EventId == id).FirstOrDefault();

            s.Updated = DateTime.Now;
            s.LastEditBy = "1";
            
            s.Name = value.Name;
            s.Description = value.Description;
            s.Location = value.Location;
            s.Longitude = value.Longitude;
            s.Latitude = value.Latitude;
            s.StartDate = value.StartDate;
            s.Places = value.Places;
            s.AllowInAppPurchases = value.AllowInAppPurchases;
            
            db.SaveChanges();
        }

        // DELETE: api/Events/5
        public void DeleteEvent(int id)
        {

            var s = db.Event.Where(c => c.EventId == id).FirstOrDefault();
            s.IsActive = false;
            db.SaveChanges();
        }
    }
}


