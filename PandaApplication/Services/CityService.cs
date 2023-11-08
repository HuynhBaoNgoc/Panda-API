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
            try
            {
                return await _cityRepository.GetListCity();
            } catch
            {
                throw new NotImplementedException();
            }
        }
        public async Task<CityResponse> GetCityById(int id)
        {
            try
            {
                return await _cityRepository.GetCityById(id);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}
