using PandaDomain.Models.Request;
using PandaDomain.Models.Response;

namespace PandaApplication.Interfaces.Repositories
{
    public interface ICityRepository
    {
        Task<List<CityResponse>> GetListCity();
        Task<CityResponse> GetCityById(int id);
        Task<List<CityResponse>> AddCity(AddCityRequest cityRequest);
        Task<CityResponse> UpdateCity(UpdateCityRequest cityRequest);
        Task<List<CityResponse>> Delete(int id);
    }
}
