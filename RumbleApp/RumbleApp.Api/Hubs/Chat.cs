using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JamnationApp.Api.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR.Owin;

namespace RumbleApp.Api.Hubs
{
    public class Chat : Hub
    {

        public ApplicationDbContext db = new ApplicationDbContext();
        public void SendMessage(string username, string message)
        {
            Clients.All.MessageReceived(username, message);
        }

        public void Send(string fromemail, string toemail, string message)
        {
            var from = db.Users.Where(c => c.Email == fromemail).FirstOrDefault();
            var to = db.Users.Where(c => c.Email == toemail).FirstOrDefault();

            // send message to specific user 
            Clients.User(to.UserName).MessageReceived(from.FirstName, message);

            db.ChatHistory.Add(new JamnationApp.Models.Profiles.ChatHistory()
            {
                FromId = from.Profile.ProfileId,
                ToId = to.Profile.ProfileId,
                Message = message,
                DateSent = DateTime.Now
            });
            db.SaveChanges();
        }
    }
}