using PandaDomain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaApplication.Services.Interfaces
{
    public interface ICityService
    {
        Task<List<CityResponse>> GetListCity();
        Task<CityResponse> GetCityById(int id);
    }
}