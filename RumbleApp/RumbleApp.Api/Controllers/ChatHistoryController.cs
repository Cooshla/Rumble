using System;
using System.Collections.Generic;
using System.Linq;
using ImageResizer;
using JamnationApp.Models.Profiles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;


namespace JamnationApp.Api.Controllers
{
    public class ChatHistoryController : BaseApiController
    {
       
        // GET: api/Profile/5
        public async Task<JsonResult<List<ChatHistory>>> GetAllChatHistoryProfiles(int id)
        {
            var prof = db.Profile.Where(c => c.ProfileId == id).FirstOrDefault();
            // get ids of all 
            List<ChatHistory> ret = new List<ChatHistory>();
            ret.AddRange(db.ChatHistory.Where(c => c.FromId == id).ToList());
            ret.AddRange(db.ChatHistory.Where(c => c.ToId == id).ToList());

            return Json(ret);
        }

    }
}
