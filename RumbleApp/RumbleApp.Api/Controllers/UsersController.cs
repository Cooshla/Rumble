using RumbleApp.Api.Helpers;
using RumbleApp.Api.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;


namespace RumbleApp.Api.Controllers
{

    [Authorize]
    public class UserController : BaseApiController
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<JsonResult<UserResponse>> Add([FromBody]AppUser user)
        {

            var u = new ApplicationUser
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.Email,
                Email = user.Email,
                NotificationTags = new NotificationTags { Tags = new List<Tag> { new Tag { tag = "appuser" }, new Tag { tag = user.Email } } }
            };
            var result = await UserManager.CreateAsync(u, user.Password);
            return Json(new UserResponse { success = result.Succeeded, errors = result.Errors });
        }

        [HttpPut]
        public async Task<JsonResult<UserResponse>> Update([FromBody]AppUser user)
        {
            var errors = new List<string>();
            var existing = db.Users.SingleOrDefault(u => u.UserName == RequestContext.Principal.Identity.Name);

            //update the user
            if (existing == null)
            {
                return Json(new UserResponse { success = false, errors = new[] { "User doesn't exist" } });
            }

            
            AutoMapper.Mapper.Map(user, existing);
            try
            {
                if (user.NotificationTags?.Devices != null && user.NotificationTags.Devices.Count > 0)
                {
                    foreach (var device in user.NotificationTags.Devices)
                    {
                        var currentDevice = existing.NotificationTags.Devices.FirstOrDefault(dv => dv.Id == device.Id);
                        if (device.Id == 0 || currentDevice == null)
                        {
                            if (existing.NotificationTags.Devices == null)
                            {
                                existing.NotificationTags.Devices = new List<Device>();
                            }
                            device.CreatedBy = RequestContext.Principal.Identity.Name;
                            existing.NotificationTags.Devices.Add(device);
                        }
                        else
                        {
                            device.LastEditBy = RequestContext.Principal.Identity.Name;
                            currentDevice.Token = device.Token;
                        }
                    }
                }

                if (user.NotificationTags?.Tags != null && user.NotificationTags.Tags.Count > 0)
                {
                    foreach (var tag in user.NotificationTags.Tags)
                    {
                        if (tag.Id == 0)
                        {
                            if (existing.NotificationTags.Tags == null)
                            {
                                existing.NotificationTags.Tags = new List<Tag>();
                            }
                            existing.NotificationTags.Tags.Add(tag);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
            }

            //update the image
            try
            {
                if (user.PhotoBinary != null)
                {
                    if (existing.PhotoUrl != null)
                    {
                        string file = existing.PhotoUrl.Substring(existing.PhotoUrl.IndexOf("/images", 0) + 1).Replace("/", @"\");
                        Debug.Print(HttpContext.Current.Server.MapPath("~/"));
                        Debug.Print(file);
                        var localPath = Path.Combine(HttpContext.Current.Server.MapPath("~/"), file);
                        File.Delete(localPath);
                    }
                    existing.PhotoUrl = ImageHelper.SaveImageAsGuid(user.PhotoBinary, "profiles");
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
            }

            var result = await db.SaveChangesAsync();

            var json = await Get();
            return Json(new UserResponse { success = result > 0, errors = errors, ReturnedUser = json.Content });
        }

    

        [HttpGet]
        public async Task<JsonResult<AppUser>> Get()
        {
            var user = db.Users.SingleOrDefault(u => u.UserName == RequestContext.Principal.Identity.Name);
            AppUser appuser = new AppUser();
            AutoMapper.Mapper.Map(user, appuser);

            return Json(appuser);
        }


        /*
        [HttpPost]
        public async Task<JsonResult<UserResponse>> DriverMode(string action)
        {

            var user = await UserManager.FindByEmailAsync(RequestContext.Principal.Identity.Name);
            switch (action)
            {
                case "enter":
                    user.ActiveRole = await RoleManager.FindByNameAsync("Driver");
                    break;
                case "exit":
                    user.ActiveRole = await RoleManager.FindByNameAsync("Customer");
                    break;
            }

            var result = await UserManager.UpdateAsync(user);
            return Json(new UserResponse { success = result.Succeeded, errors = result.Errors });
        }
        */

    }
}