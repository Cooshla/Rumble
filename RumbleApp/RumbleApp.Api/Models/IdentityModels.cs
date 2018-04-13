using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using JamnationApp.Models.Profiles;
using System.Data.Entity;
using JamnationApp.Models.Events;
using JamnationApp.Models.Users;
using JamnationApp.Models.Subscriptions;
using System.Collections.Generic;

namespace JamnationApp.Api.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual Location HomeLocation { get; set; }
        public virtual ApplicationRole ActiveRole { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Approved { get; set; }

        public string PhotoUrl { get; set; }
        public virtual Subscriptions Subscriptions { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual NotificationTags NotificationTags { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Profile> Profile { get; set; }
        public DbSet<Event> Event{ get; set; }
        public DbSet<Subscriptions> Subscriptions { get; set; }

        public DbSet<NotificationTags> NotificationGroups { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}