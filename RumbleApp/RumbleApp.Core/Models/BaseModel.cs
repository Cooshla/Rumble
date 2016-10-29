using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumbleApp.Core.Models
{
    public class BaseModel
    {
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string LastEditBy { get; set; }
        public string CreatedBy { get; set; }
    }
}
