using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankXamarinApp.Models
{
    public class BaseModel
    {
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        
        public int LastEditBy { get; set; }
        public int CreatedBy { get; set; }
    }
}
