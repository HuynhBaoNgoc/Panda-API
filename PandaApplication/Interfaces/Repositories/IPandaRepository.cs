using PandaDomain.Models.Request;
using PandaDomain.Models.Response;

namespace PandaApplication.Interfaces.Repositories
{
    public interface IPandaRepository
    {
        Task<List<PandaResponse>> GetListPanda();
        //Task<PandaResponse> GetPandaById(int id);
        //Task<List<PandaResponse>> AddPanda(AddPandaRequest pandaRequest);
        //Task<PandaResponse> UpdatePanda(UpdatePandaRequest pandaRequest);
        //Task<List<PandaResponse>> Delete(int id);
        Task<List<FoodResponse>> GetListFavoriteFood(int pandaId);
    }
}
