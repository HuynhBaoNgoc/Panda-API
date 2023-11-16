using PandaDomain.Models.Request;
using PandaDomain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaApplication.Interfaces.Repositories
{
    public interface IFoodRepository
    {
        Task<List<FoodResponse>> GetListFood();
        //Task<FoodResponse> GetFoodById(int id);
        //Task<List<FoodResponse>> AddFood(AddFoodRequest foodRequest);
        //Task<FoodResponse> UpdateFood(UpdateFoodRequest foodRequest);
        //Task<List<FoodResponse>> Delete(int id);
    }
}
