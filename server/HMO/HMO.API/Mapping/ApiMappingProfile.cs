using AutoMapper;
using HMO.API.Models;
using HMO.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HMO.API.Mapping
{
    public class ApiMappingProfile:Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<PersonalModel, PersonalDetails>();
            CreateMap<CoronaModel, CoronaDetails>();           
        }
    }
}
