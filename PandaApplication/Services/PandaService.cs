using PandaApplication.Interfaces.Repositories;
using PandaApplication.Services.Interfaces;
using PandaDomain.Models.Response;
using Serilog;

namespace PandaApplication.Services
{
    public class PandaService : IPandaService
    {
        private readonly IPandaRepository _pandaRepository;

        public PandaService(IPandaRepository pandaRepository)
        {
            _pandaRepository = pandaRepository;
        }

        public async Task<List<FoodResponse>> GetListFavoriteFood(int pandaId)
        {
            try
            {
                return await _pandaRepository.GetListFavoriteFood(pandaId);
            }
            catch (Exception ex)
            {
                Log.Error($"[PandaService] - [GetListFavoriteFood] {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<PandaResponse>> GetListPanda()
        {
            try
            {
                return await _pandaRepository.GetListPanda();
            }
            catch (Exception ex)
            {
                Log.Error($"[PandaService] - [GetListPanda] {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
