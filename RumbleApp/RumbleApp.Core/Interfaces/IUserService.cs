using JamnationApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamnationApp.Core.Interfaces
{
    public interface IUserService
    {

        Task<User> GetUserViewModel(string user, string pass);
         Task<bool> UpdateUserViewModelAsync();
         bool ApplyNotificationGroups(string token);
    }
}
