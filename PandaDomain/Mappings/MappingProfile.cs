using AutoMapper;
using PandaDomain.Entities;
using PandaDomain.Models.Response;

namespace PandaDomain.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            CreateMap<City, CityResponse>();
        }
    }
}
