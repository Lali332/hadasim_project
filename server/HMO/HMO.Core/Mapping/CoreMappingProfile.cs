using AutoMapper;
using HMO.Core.Dtos;
using HMO.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO.Core.Mapping
{
    public class CoreMappingProfile:Profile
    {
        public CoreMappingProfile() 
        {
            CreateMap<PersonalDetails, PersonalDetailsDto>().ForMember(dest => dest.FileUrl, opt => opt.MapFrom((src, dest, destPersonalDetails, context) =>
            {
                if (src.FileData is null)
                {
                    return null;
                }
                var url = context.Items["Url"];
                var fullUrl = url + "" + src.Id + "/Image";
                return fullUrl;
            })); ;
        }
    }
}
