using ImageResizer;
using JamnationApp.Models.Profiles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace JamnationApp.Api.Controllers
{
    public class ProfileController : BaseApiController
    {
        // GET: api/Profile
        public async Task<JsonResult<List<Profile>>> GetAllProfiles()
        {
            var profs = db.Profile.ToList();
            foreach(var prof in profs)
            {

                prof.Friend = db.Friends.Where(c => c.ProfileId == prof.ProfileId).ToList();
            }

            return Json(profs);

        }

        // GET: api/Profile/5
        public async Task<JsonResult<Profile>> GetProfile(int id)
        {
            var prof = db.Profile.Where(c => c.ProfileId == id).FirstOrDefault();
            prof.Friend = db.Friends.Where(c => c.ProfileId == id).ToList();
            return Json(prof);
        }


        // GET: api/Profile/5
        public async Task<JsonResult<List<Profile>>> GetProfilesOfFriends(int id)
        {

            var profs =db.Profile.Join(db.Friends,
                                contact => contact.ProfileId,
                                dealer => dealer.RequestId,
                                (contact, dealer) => contact).ToList();

            foreach (var prof in profs)
            {

                prof.Friend = db.Friends.Where(c => c.ProfileId == prof.ProfileId).ToList();
            }


            return Json(profs);
        }


        // POST: api/Profile
        public HttpResponseMessage PostProfile([FromBody]Profile value)
        {
            value.Created = DateTime.Now;
            value.Updated = DateTime.Now;
            value.CreatedBy = "1";
            value.LastEditBy= "1";
            value.IsActive = true;

            string fileName = string.Empty;
            try
            {
                if (value.ImageBlob != null)
                {
                    fileName = Guid.NewGuid().ToString() + ".jpg";


                    File.WriteAllBytes(System.Web.Hosting.HostingEnvironment.MapPath("~/profileImages/" + fileName), value.ImageBlob);
                    /*
                    Image img = null;
                    using (var ms = new MemoryStream(value.ImageBlob))
                    {
                        img = Image.FromStream(ms);
                    }

                    img.Save(System.Web.Hosting.HostingEnvironment.MapPath("~/profileImages/" + fileName));
                    */
                    value.ImageUrl = fileName;
                    value.ImageBlob = null;
                }
            }
            catch(Exception ex)
            {
                value.ImageUrl = ex.Message+":"+ex.StackTrace;
            }

            db.Profile.Add(value);
            var prof = db.SaveChanges();


            var usr = db.Users.Where(c => c.Id == value.UserId).FirstOrDefault();
            value.ProfileId = prof;
            usr.Profile = value;
            if(fileName!=string.Empty)
                usr.PhotoUrl = fileName;

            db.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // PUT: api/Profile/5
        public HttpResponseMessage PutProfile([FromBody]Profile value)
        {
            var s = db.Profile.Where(c => c.ProfileId == value.ProfileId).FirstOrDefault();
            
            s.Updated = DateTime.Now;
            s.LastEditBy = "1";

            s.FirstName = value.FirstName;
            s.LastName = value.LastName;
            s.Description = value.Description;
            s.Interests = value.Interests;
            s.Email = value.Email;
            s.Location = value.Location;
            s.Longitude = value.Longitude;
            s.Latitude = value.Latitude;
            s.PhoneNumber = value.PhoneNumber;
            s.PostCode = value.PostCode;
            s.Ranking = value.Ranking;
            s.ShowExactLocation = value.ShowExactLocation;
            s.SoundCloud = value.SoundCloud;

            string fileName = string.Empty;
            try
            {
                if (value.ImageBlob != null)
                {
                    if(File.Exists(System.Web.Hosting.HostingEnvironment.MapPath("~/profileImages/" + s.ImageUrl)))
                        File.Delete(System.Web.Hosting.HostingEnvironment.MapPath("~/profileImages/" + s.ImageUrl));

                    fileName = Guid.NewGuid().ToString() + ".jpg";
                    File.WriteAllBytes(System.Web.Hosting.HostingEnvironment.MapPath("~/profileImages/" + fileName), value.ImageBlob);
                   
                    s.ImageUrl = fileName;
                    s.ImageBlob = null;
                }
            }
            catch (Exception ex)
            {
                value.ImageUrl = ex.Message + ":" + ex.StackTrace;
            }
            
            db.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK);
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
