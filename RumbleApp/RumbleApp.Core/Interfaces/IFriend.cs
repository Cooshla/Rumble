using JamnationApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JamnationApp.Core.Interfaces
{
    public interface IFriend
    {
        Task<HttpResponseMessage> AddFriend(FriendRequests profile);
        Task UpdateFriend(FriendRequests profile);
        Task DeleteFriend(int id);
    }
}
