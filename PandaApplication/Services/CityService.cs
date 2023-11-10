using PandaApplication.Interfaces.Repositories;
using PandaApplication.Services.Interfaces;
using PandaDomain.Models.Request;
using PandaDomain.Models.Response;
using Serilog;

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
            }
            catch (Exception ex)
            {
                Log.Error($"[CityRepo] - [GetListCity] {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<CityResponse> GetCityById(int id)
        {
            try
            {
                return await _cityRepository.GetCityById(id);
            }
            catch (Exception ex)
            {
                Log.Error($"[CityRepo] - [GetCityById] {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<CityResponse>> AddCity(AddCityRequest cityRequest)
        {
            try
            {
                return await _cityRepository.AddCity(cityRequest);
            }
            catch (Exception ex)
            {
                Log.Error($"[CityRepo] - [AddCity] {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<CityResponse> UpdateCity(UpdateCityRequest cityRequest)
        {
            try
            {
                return await _cityRepository.UpdateCity(cityRequest); // = empty
            }
            catch (Exception ex)
            {
                Log.Error($"[CityRepo] - [UpdateCity] {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<CityResponse>> Delete(int id)
        {
            try
            {
                return await _cityRepository.Delete(id);
            }
            catch (Exception ex)
            {
                Log.Error($"[CityRepo] - [Delete] {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
