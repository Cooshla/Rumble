using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamnationApp.Models.Users
{
    public class User : BaseModel
    {
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int SubscriptionId { get; set; }
        public int ProfileId { get; set; }
    }
}
