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
    }
}
