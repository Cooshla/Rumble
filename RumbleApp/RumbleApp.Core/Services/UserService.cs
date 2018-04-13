using Newtonsoft.Json;
using JamnationApp.Core.Interfaces;
using JamnationApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JamnationApp.Core.Services
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
            User u = new User();
            u.Email = "stephen.shaw85@gmail.com";
            u.FirstName = "Stephen";
            u.HomeLocation = new Location() { Longitude = 51.885663, Latitude = -8.631692, Altitude = 50, Id = 1 };
            u.LastName = "Shaw";
            u.ID = "123456";
            u.PhoneNumber = "087 1474378";
            u.PhotoUrl = "https://media.licdn.com/dms/image/C4D03AQH2HnPyEb-pDw/profile-displayphoto-shrink_200_200/0?e=1528448400&v=beta&t=idWX8R_ktEwfVHUT2v-VDjIHApar_11vGT0QDnAE8MY";
            u.Profile = new Profile()
            {
                Created = DateTime.Now,
                CreatedBy = "1",
                Description = "This is a description",
                Email = "stephen.shaw85@gmail.com",
                FirstName = "Stephen",
                LastName = "Shaw",
                ImageUrl = "https://media.licdn.com/dms/image/C4D03AQH2HnPyEb-pDw/profile-displayphoto-shrink_200_200/0?e=1528448400&v=beta&t=idWX8R_ktEwfVHUT2v-VDjIHApar_11vGT0QDnAE8MY",
                Interests = "Rock, Jazz, Funk",
                Location = "Cork",
                Longitude = 51.885663,
                Latitude = -8.631692,
                PhoneNumber = "087 1474378",
                PostCode = "",
                Ranking = "98",
                ShowExactLocation = true,
                ProfileId = 1,
                EventItems = new List<Event>(),
                IsActive = true
            };


            return u;
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
