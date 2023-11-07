using PandaApplication.Interfaces.Repositories;
using PandaApplication.Services.Interfaces;
using PandaDomain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaApplication.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository) 
        {
            _cityRepository = cityRepository;
        }
        public async Task<List<CityResponse>> GetListCity()
        {
            return await _cityRepository.GetListCity();
        }
    }
}
