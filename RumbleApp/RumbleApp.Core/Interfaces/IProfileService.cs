using JamnationApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JamnationApp.Core.Interfaces
{
    public interface IProfileService
    {
        Task<Profile> GetProfile(int id);
        Task<List<Profile>> GetAllProfiles();
        Task<List<Profile>> GetAllProfilesOfFriends(int ProfileId);
        Task<HttpResponseMessage> AddProfile(Profile profile);
        Task UpdateProfile(Profile profile);
        Task DeleteProfile(int id);
    }
}
