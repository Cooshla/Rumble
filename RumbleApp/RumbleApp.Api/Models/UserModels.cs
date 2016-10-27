using RumbleApp.Models.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RumbleApp.Api.Models
{
    public class AppUser
    {
        public Profile UserProfile { get; set; }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public UserStatus Status { get; set; }
        public int SubscriptionId { get; set; }
        public Location HomeLocation { get; set; }
        public string PhotoUrl { get; set; }
        public byte[] PhotoBinary { get; set; }
        public string DeviceId { get; set; }
        public virtual NotificationTags NotificationTags { get; set; }
    }

    public class UserResponse
    {
        public IEnumerable<string> errors;
        public bool success { get; set; }

        public AppUser ReturnedUser { get; set; }
    }
}