using RumbleApp.Models.Profiles;
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
    public class ProfileController : BaseApiController
    {
        // GET: api/Profile
        public async Task<JsonResult<List<Profile>>> GetAllProfiles()
        {
            return Json(db.Profile.ToList());

        }

        // GET: api/Profile/5
        public async Task<JsonResult<Profile>> GetProfile(int id)
        {
            return Json(db.Profile.Where(c => c.ProfileId == id).FirstOrDefault());
        }

        // POST: api/Profile
        public HttpResponseMessage PostProfile([FromBody]Profile value)
        {
            value.Created = DateTime.Now;
            value.Updated = DateTime.Now;
            value.CreatedBy = "1";
            value.LastEditBy= "1";
            value.IsActive = true;

            db.Profile.Add(value);
            db.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // PUT: api/Profile/5
        public void PutProfile(int id, [FromBody]Profile value)
        {
            var s = db.Profile.Where(c => c.ProfileId == id).FirstOrDefault();
            
            s.Updated = DateTime.Now;
            s.LastEditBy = "1";

            s.FirstName = value.FirstName;
            s.LastName = value.LastName;
            s.Description = value.Description;
            s.Email = value.Email;
            s.Location = value.Location;
            s.Longitude = value.Longitude;
            s.Latitude = value.Latitude;
            s.PhoneNumber = value.PhoneNumber;
            s.PostCode = value.PostCode;
            s.Ranking = value.Ranking;
            s.ShowExactLocation = value.ShowExactLocation;
            
            db.SaveChanges();
        }

        // DELETE: api/Profile/5
        public void DeleteProfile(int id)
        {
            var s = db.Profile.Where(c => c.ProfileId == id).FirstOrDefault();
            s.IsActive = false;
            db.SaveChanges();
        }
    }
}
