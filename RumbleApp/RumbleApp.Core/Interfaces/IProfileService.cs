using RumbleApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumbleApp.Core.Interfaces
{
    public interface IProfileService
    {
        Task<Profile> GetProfile(int id);
        Task<List<Profile>> GetAllProfiles(int id);
        Task AddProfile(Profile profile);
        Task UpdateProfile(Profile profile);
        Task DeleteProfile(int id);
    }
}
