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
    public class ProfileService : IProfileService
    {
        private IRestService Rest { get; set; }

        public ProfileService(IRestService _rest)
        {
            Rest = _rest;
        }

        public async Task<HttpResponseMessage> AddProfile(Profile profile)
        {
            var json = JsonConvert.SerializeObject(profile);
            return await Rest.PostClient<HttpResponseMessage>("api/profile/PostProfile", json);
            
        }

        public async Task DeleteProfile(int id)
        {
            throw new NotImplementedException();
            //await Rest.GetClient<Profile>("api/profile/get");
        }

        public async Task<Profile> GetProfile(int id)
        {
            return await Rest.GetClient<Profile>("api/Profile/getprofile?id=" + id);
        }
        public async Task<List<Profile>> GetAllProfiles()
        {
            return await Rest.GetClient<List<Profile>>("api/Profile/GetAllProfiles");
        }

        

        public async Task UpdateProfile(Profile profile)
        {
            var json = JsonConvert.SerializeObject(profile);
            await Rest.PutClient<Profile>("api/Profile/putprofile", json);
        }

        public async Task<List<Profile>> GetAllProfilesOfFriends(int ProfileId)
        {
            return await Rest.GetClient<List<Profile>>("api/Profile/GetAllProfiles",ProfileId.ToString());
        }
        
    }
}
