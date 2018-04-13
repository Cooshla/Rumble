using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamnationApp.Models.Events
{
    public class Event: BaseModel
    {
        [Key]
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTime StartDate { get; set; }
        public int Places { get; set; }
        public bool AllowInAppPurchases { get; set; }
        public byte[] ImageBlob { get; set; }
        public string ImageUrl { get; set; }
        public int ProfileId { get; set; }
        public bool IsActive { get; set; }
    }
}
