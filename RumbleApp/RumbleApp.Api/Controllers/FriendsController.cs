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
    public class FriendsController: BaseApiController
    {
        // POST: api/Profile
        public HttpResponseMessage PostFriendRequest([FromBody]FriendRequests value)
        {
            value.Created = DateTime.Now;
            value.Updated = DateTime.Now;
            db.Friends.Add(value);
            db.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }


        // POST: api/Profile
        public HttpResponseMessage PutFriendRequest([FromBody]FriendRequests value)
        {
            
            value.Updated = DateTime.Now;
            var s = db.Friends.Where(c => c.FriendId == value.FriendId).FirstOrDefault();
            s.Accepted = value.Accepted;
            db.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // DELETE: api/Profile/5
        public void DeleteFriendRequest(int id)
        {
            var s = db.Friends.Where(c => c.FriendId == id).FirstOrDefault();
            db.Friends.Remove(s);
            db.SaveChanges();
        }

    }
}
