using AutoMapper;
using PandaDomain.Entities;
using PandaDomain.Models.Request;
using PandaDomain.Models.Response;

namespace PandaDomain.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            CreateMap<City, CityResponse>();
            CreateMap<AddCityRequest, City>();
            CreateMap<UpdateCityRequest, City>();
        }
    }
}
