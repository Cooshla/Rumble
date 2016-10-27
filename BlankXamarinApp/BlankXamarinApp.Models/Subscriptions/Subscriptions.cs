using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankXamarinApp.Models.Subscriptions
{
    public class Subscriptions
    {
        [Key]
        public int SubscriptionId { get; set; }
        public string Name { get; set; }
    }
}
