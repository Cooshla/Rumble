using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumbleApp.Core.Models
{
    public class User : BaseModel
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int SubscriptionId { get; set; }
        public int ProfileId { get; set; }

        public Profile UserProfile { get; set; }
    }
}
