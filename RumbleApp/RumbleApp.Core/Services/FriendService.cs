using JamnationApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamnationApp.Core.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace JamnationApp.Core.Services
{
    public class FriendService : IFriend
    {
        private IRestService Rest { get; set; }

        public FriendService(IRestService _rest)
        {
            Rest = _rest;
        }

        public async Task<HttpResponseMessage> AddFriend(FriendRequests profile)
        {
            var json = JsonConvert.SerializeObject(profile);
            return await Rest.PostClient<HttpResponseMessage>("api/friends/PostFriend", json);
            
        }

        public async Task DeleteFriend(int id)
        {
            await Rest.PostClient<int>("api/friends/deleteFriend", id.ToString());
        }
        
        public async Task UpdateFriend(FriendRequests profile)
        {
            var json = JsonConvert.SerializeObject(profile);
            await Rest.PutClient<Profile>("api/friends/putFriend", json);
        }
    }
}
