using RumbleApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumbleApp.Core.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace RumbleApp.Core.Services
{
    public class ProfileService : IProfileService
    {
        private IRestService Rest { get; set; }

        public ProfileService(IRestService _rest)
        {
            Rest = _rest;
        }

        public async Task AddProfile(Profile profile)
        {

            var json = JsonConvert.SerializeObject(profile);
            var result = await Rest.PostClient<HttpResponseMessage>("api/profile", json);
            var user = await Rest.GetClient<User>("api/profile");
        }

        public async Task DeleteProfile(int id)
        {
            throw new NotImplementedException();
            //await Rest.GetClient<Profile>("api/profile/get");
        }

        public async Task<Profile> GetProfile(int id)
        {
            return await Rest.GetClient<Profile>("api/Profile/"+id);
        }

        public async Task UpdateProfile(Profile profile)
        {
            await Rest.PutClient<Profile>(string.Format("api/Profile/{0}",profile.ProfileId));
        }
    }
}
