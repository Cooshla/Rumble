using RumbleApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumbleApp.Core.Interfaces
{
    public interface IAccountService
    {
        Task<bool> LoginAsync(string user, string pass);

        Task<UserResponse> RegisterAsync(User user, Profile profile);
        
    }
}
