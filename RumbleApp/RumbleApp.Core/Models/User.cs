using RumbleApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumbleApp.Core.Models
{
    public class User : BaseViewModel
    {
     
        public Profile Profile { get; set; }

        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public UserStatus Status { get; set; }
        public int SubscriptionId { get; set; }
        public Location HomeLocation { get; set; }
        private byte[] _photoBinary;
        public byte[] PhotoBinary
        {
            get
            {
                return _photoBinary;
            }
            set
            {
                SetObservableProperty(ref _photoBinary, value);
            }
        }
        private string _photoUrl;
        public string PhotoUrl
        {
            get
            {
                return _photoUrl;
            }
            set
            {
                SetObservableProperty(ref _photoUrl, value);
            }
        }
        public string DeviceId { get; set; }
        public NotificationTags NotificationTags { get; set; }
    }

   

    public class UserStatus
    {
        public DateTime LastUpdated { get; set; }
        public Status ActiveStatus { get; set; }
    }

    public enum Status
    {
        Active,
        Offline
    }

    public class UserResponse
    {
        public IEnumerable<string> errors
        {
            get; set;
        }
        public bool success { get; set; }
        public User ReturnedUser { get; set; }
    }

    public class NotificationTags
    {
        public int Id { get; set; }
        public List<Tag> Tags { get; set; }

        public List<DeviceInfo> Devices { get; set; }
    }
    public class Tag
    {
        public int Id { get; set; }
        public string tag { get; set; }
    }

    public enum DeviceType { Android, Apple, WindowsPhone, WindowsUniversal }
    public class DeviceInfo
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DeviceType DeviceType { get; set; }
        public string DeviceId { get; set; }
    }

}
