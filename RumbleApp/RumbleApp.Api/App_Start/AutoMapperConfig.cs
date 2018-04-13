using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper.QueryableExtensions;
using JamnationApp.Api.Models;

namespace JamnationApp.Api.App_Start
{

    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {

            Mapper.Initialize((cfg) =>
            {

                cfg.CreateMap<AppUser, ApplicationUser>().ForMember(dest => dest.NotificationTags, opt => opt.Ignore());
                

                //.ForMember(d => d.NotificationTags.Tags, opt => opt.Ignore())
                //.ForMember(d => d.NotificationTags.Devices, opt => opt.Ignore());
                cfg.CreateMap<ApplicationUser, AppUser>();

                cfg.CreateMap<NotificationTags, NotificationTags>();
                cfg.CreateMap<JamnationApp.Models.Profiles.Profile, JamnationApp.Models.Profiles.Profile>();
                //cfg.CreateMap<AppUser, ApplicationUser>().ForMember(dest => dest.Id, opt => opt.Ignore());

                //cfg.CreateMap<Tag, Tag>().ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
                //cfg.CreateMap<AppUser, ApplicationUser>().ForMember(d => d.NotificationTags.Devices, opt => opt.Ignore());


                //cfg.CreateMap<NotificationTags, NotificationTags>()
                //  .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
            });
        }
        
    }
}


