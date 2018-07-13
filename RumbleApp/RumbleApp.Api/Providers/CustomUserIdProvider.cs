using JamnationApp.Api.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RumbleApp.Api.Providers
{
    public class CustomUserIdProvider : IUserIdProvider
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        public string GetUserId(IRequest request)
        {
            // your logic to fetch a user identifier goes here.

            // for example:
            var userId = db.Users.Where(c=>c.Id== request.User.Identity.Name).Select(c=>c.Id).FirstOrDefault();
            return userId.ToString();
        }
    }
}