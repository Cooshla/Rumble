using Newtonsoft.Json;
using RumbleApp.Core.Interfaces;
using RumbleApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RumbleApp.Core.Services
{
    public class UserService :IUserService
    {
        private IRestService Rest { get; set; }

        public UserService(IRestService _rest)
        {
            Rest = _rest;
        }

        public async Task<User> GetUserViewModel(string usr, string pass)
        {
            var user = await Rest.GetClient<User>(string.Format("api/user/getuser?usr={0}&pass={1}",usr,pass));
            return user;
        }

        public async Task<bool> UpdateUserViewModelAsync()
        {
            var json = JsonConvert.SerializeObject(App.ThisUser);
            var user = await Rest.PutClient<UserResponse>("api/user/updateuser", json);
            App.ThisUser = user.ReturnedUser ?? App.ThisUser;
            return user.success;
        }

        public bool ApplyNotificationGroups(string token)
        {
            bool changed = false;
            string platform = Device.OnPlatform<string>("iosuser", "droiduser", "winuser");

            if (App.ThisUser.NotificationTags == null || App.ThisUser.NotificationTags.Tags == null || App.ThisUser.NotificationTags.Tags.Count == 0)
            {
                App.ThisUser.NotificationTags = new NotificationTags
                {
                    Tags = new List<Tag> { new Tag { tag = "appuser" }, new Tag { tag = platform }, new Tag { tag = App.ThisUser.Email } },
                    Devices = new List<Models.DeviceInfo>()
                };
                changed = true;
            }

            var device = App.ThisUser.NotificationTags.Devices.FirstOrDefault(d => d.DeviceId == App.DeviceId);
            if (device == null)
            {
                App.ThisUser.NotificationTags.Devices.Add(new Models.DeviceInfo
                {
                    DeviceId = App.DeviceId,
                    DeviceType = platform == "iosuser" ? DeviceType.Apple : DeviceType.Android,
                    Token = token
                });
                changed = true;
            }
            else
            {
                device.Token = token;
                changed = true;
            }


            return changed;
        }
        
    }
}
