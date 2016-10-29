using RumbleApp.Core.Interfaces;
using RumbleApp.Core.Models.Account;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using RumbleApp.Core.Models;
using Newtonsoft.Json;

namespace RumbleApp.Core.Services
{
    public class AccountService : IAccountService
    {
        private IRestService Rest { get; set; }
        private IUserService User { get; set; }
        public AccountService(IRestService _rest, IUserService _user)
        {
            Rest = _rest;
            User = _user;
        }

        public async Task<bool> LoginAsync(string user, string pass)
        {
            AuthResponse response = new AuthResponse { expires_in = 0 };

            if (response.expires_in == 0)
            {
                try
                {
                    response = await Rest.PostClient<AuthResponse>("Token", String.Format("grant_type=password&username={0}&password={1}", user, pass));
                    if (!string.IsNullOrEmpty(response.access_token))
                    {
                        App.Token = response.access_token;
                        Application myApp = Application.Current;

                        // Sort Settings
                        Settings.Token = response.access_token;
                        Settings.Expires = response.expires;
                        Settings.UserName = user;
                        Settings.Password = pass;

                        App.ThisUser = await User.GetUserViewModel(user,pass);

                        // Fire messaging center to map page to show modal
                        MessagingCenter.Send<AccountService, bool>(this, Messages.LoginSuccessful, true);

                        return true;
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return false;
                }
            }


            return false;
        }

        public async Task<UserResponse> RegisterAsync(User user, Profile profile)
        {
            user.Profile = profile;
            return await Rest.PostClient<UserResponse>("api/user/adduser", JsonConvert.SerializeObject(user));

        }

       
    }
}
