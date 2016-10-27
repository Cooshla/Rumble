using RumbleApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumbleApp.Core.Interfaces
{
    public interface IUserService
    {
         Task<User> GetUserViewModel();
         Task<bool> UpdateUserViewModelAsync();
         bool ApplyNotificationGroups(string token);
    }
}
