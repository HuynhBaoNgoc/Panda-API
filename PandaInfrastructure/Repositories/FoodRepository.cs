using PandaApplication.Interfaces.Repositories;
using PandaDomain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaInfrastructure.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        public Task<List<FoodResponse>> GetListFood()
        {
            throw new NotImplementedException();
        }
    }
}
