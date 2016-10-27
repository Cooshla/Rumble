using BlankXamarinApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankXamarinApp.Core.Interfaces
{
    public interface IAccountService
    {
        Task<bool> LoginAsync(string user, string pass);

        Task<bool> RegisterAsync(User user, Profile profile);

        Task<User> GetUser(string user, string pass);
    }
}
