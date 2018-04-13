using JamnationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JamnationApp.Api.Models
{
    public class NotificationTags : BaseModel
    {
        public int Id { get; set; }
        public virtual List<Tag> Tags { get; set; }

        public virtual List<Device> Devices { get; set; }

    }
    public enum DeviceType { Android, Apple, WindowsPhone, WindowsUniversal }
    public class Device : BaseModel
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DeviceType DeviceType { get; set; }
        public string DeviceId { get; set; }
    }

    public class Tag
    {
        public int Id { get; set; }
        public string tag { get; set; }
    }
}