using JamnationApp.Models.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamnationApp.Models.Profiles
{
    public class Profile: BaseModel
    {
        [Key]
        public int ProfileId { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string Ranking { get; set; }
        public string Location { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string PostCode { get; set; }
        public bool ShowExactLocation { get; set; }
        public string Interests { get; set; }
        public List<Event> EventItems { get; set; }
        public byte[] ImageBlob { get; set; }
        public string ImageUrl { get; set; }

        public bool IsActive { get; set; }
        public string SoundCloud { get; set; }
        public virtual List<FriendRequests> Friend { get; set; }
    }

    public class FriendRequests : BaseModel
    {
        [Key]
        public int FriendId { get; set; }
        public int RequestId { get; set; }
        public int ProfileId { get; set; }
        public bool Accepted { get; set; }
    }

}
