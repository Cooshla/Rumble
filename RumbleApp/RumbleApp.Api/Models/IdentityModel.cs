using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JamnationApp.Api.Models
{
    public class IdentityModel
    {

    }
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string name) : base(name) { }
        public string Description { get; set; }
    }
    public class UserStatus
    {
        public System.DateTime LastUpdated { get; set; }
        public Status ActiveStatus { get; set; }
    }

    public enum Status
    {
        Active,
        Offline
    }


}