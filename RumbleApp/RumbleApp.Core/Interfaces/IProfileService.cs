using JamnationApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamnationApp.Core.Interfaces
{
    public interface IProfileService
    {
        Task<Profile> GetProfile(int id);
        Task<List<Profile>> GetAllProfiles();
        Task AddProfile(Profile profile);
        Task UpdateProfile(Profile profile);
        Task DeleteProfile(int id);
    }
}
