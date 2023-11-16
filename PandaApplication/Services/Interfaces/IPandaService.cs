using PandaDomain.Models.Response;

namespace PandaApplication.Services.Interfaces
{
    public interface IPandaService
    {
        Task<List<PandaResponse>> GetListPanda();
        //Task<PandaResponse> GetPandaById(int id);
        //Task<List<PandaResponse>> AddPanda(AddPandaRequest pandaRequest);
        //Task<PandaResponse> UpdatePanda(UpdatePandaRequest pandaRequest);
        //Task<List<PandaResponse>> Delete(int id);
        Task<List<FoodResponse>> GetListFavoriteFood(int pandaId);
    }
}
