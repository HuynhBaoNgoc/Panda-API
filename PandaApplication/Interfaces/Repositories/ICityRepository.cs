using PandaDomain.Models.Request;
using PandaDomain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaApplication.Interfaces.Repositories
{
    public interface ICityRepository
    {
        Task<List<CityResponse>> GetListCity();
        Task<CityResponse> GetCityById(int id);
        Task<List<CityResponse>> AddCity(AddCityRequest cityRequest);
        Task<List<CityResponse>> UpdateCity(UpdateCityRequest cityRequest);
        Task<List<CityResponse>> Delete(int id);
    }
}
