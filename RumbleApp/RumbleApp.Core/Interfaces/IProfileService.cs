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
        Profile GetProfile(int id);
        void AddProfile();
        void UpdateProfile(Profile profile);
        void DeleteProfile(int id);
    }
}
