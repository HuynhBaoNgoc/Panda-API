using AutoMapper;
using Dapper;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using PandaApplication.Interfaces.Repositories;
using PandaDomain.Models.Response;
using PandaInfrastructure.ConnectionStrings;
using Serilog;
using System.Data;

namespace PandaInfrastructure.Repositories
{
    public class PandaRepository : IPandaRepository
    {
        private readonly PandaDbContext _pandaDbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<CityRepository> _logger;

        public PandaRepository(PandaDbContext pandaDbContext, IMapper mapper, ILogger<CityRepository> logger)
        {
            _pandaDbContext = pandaDbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<FoodResponse>> GetListFavoriteFood(int pandaId)
        {
            try
            {
                using (var connection = new MySqlConnection() { ConnectionString = _pandaDbContext.GetConnectionString() })
                {
                    var sql = $@"CALL PandaFavoriteFoods({pandaId});";

                    var queryParameters = new DynamicParameters();
                    var response = (await connection.QueryAsync<FoodResponse>(sql, queryParameters, commandType: CommandType.Text)).ToList();
                    return response;
                };
            }
            catch (Exception ex)
            {
                Log.Error($"[PandaRepo] - [GetListFavoriteFood] {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<PandaResponse>> GetListPanda()
        {
            try
            {
                using (var connection = new MySqlConnection() { ConnectionString = _pandaDbContext.GetConnectionString() })
                {
                    var sql = $@"SELECT PandaId, PandaName FROM panda;";

                    var queryParameters = new DynamicParameters();
                    var response = (await connection.QueryAsync<PandaResponse>(sql, queryParameters, commandType: CommandType.Text)).ToList();
                    return response;
                };
            }
            catch (Exception ex)
            {
                Log.Error($"[PandaRepo] - [GetListPanda] {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
        
        #region Others
        //public async Task<PandaResponse> GetPandaById(int id)
        //{
        //    try
        //    {
        //        using (var connection = new MySqlConnection() { ConnectionString = _pandaDbContext.GetConnectionString() })
        //        {
        //            var sql = $@"SELECT * FROM pandadb.panda WHERE PandaId = {id};";

        //            var queryParameters = new DynamicParameters();
        //            var response = (await connection.QueryFirstOrDefaultAsync<PandaResponse>(sql, queryParameters, commandType: CommandType.Text));
        //            return response;
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error($"[PandaRepo] - [GetPandaById] {ex.Message}");
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public async Task<List<PandaResponse>> AddPanda(AddPandaRequest pandaRequest)
        //{
        //    try
        //    {
        //        using (var connection = new MySqlConnection() { ConnectionString = _pandaDbContext.GetConnectionString() })
        //        {
        //            var sql = $@"INSERT INTO `pandadb`.`panda` (`PandaName`, 
        //                                                        `CityId`, 
        //                                                        `CreatedDate`, 
        //                                                        `IsDeleted`, 
        //                                                        `UpdatedDate`) 
        //                                          VALUES (pandaName, 
        //                                                        '6',
        //                                                        {Dat}, 
        //                                                        '0', 
        //                                                        '2023-11-10 17:00:34.434642');";

        //            var queryParameters = new DynamicParameters();
        //            var response = (await connection.QueryFirstOrDefaultAsync<PandaResponse>(sql, queryParameters, commandType: CommandType.Text));
        //            return response;
        //        };
        //        var city = _mapper.Map<Panda>(pandaRequest);
        //        _pandaDbContext.Add(city);
        //        //_pandaDbContext.Cities.Add(new City()
        //        //{
        //        //    CityName = cityRequest.CityName
        //        //});
        //        await _pandaDbContext.SaveChangesAsync();
        //        var cities = await _pandaDbContext.Cities.ToListAsync();
        //        var result = _mapper.Map<List<PandaResponse>>(cities);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error($"[PandaRepo] - [AddCity] {ex.Message}");
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public async Task<PandaResponse> UpdatePanda(UpdatePandaRequest pandaRequest)
        //{
        //    try
        //    {
        //        //var city = await _pandaDbContext.Cities.FindAsync(cityRequest.CityId);
        //        //if (city == null)
        //        //    throw new NotImplementedException();
        //        var newInfo = _mapper.Map<City>(cityRequest);
        //        _pandaDbContext.Set<City>().Update(newInfo);
        //        await _pandaDbContext.SaveChangesAsync();
        //        var city = await _pandaDbContext.Cities.FindAsync(cityRequest.CityId);
        //        var result = _mapper.Map<CityResponse>(city);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error($"[PandaRepo] - [UpdateCity] {ex.Message}");
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public async Task<List<PandaResponse>> Delete(int id)
        //{
        //    try
        //    {
        //        var city = await _pandaDbContext.Cities.FindAsync(id);
        //        if (city == null)
        //        {
        //            Log.Information("Id not found");
        //            return new List<CityResponse>();
        //        }

        //        _pandaDbContext.Set<City>().Remove(city);
        //        await _pandaDbContext.SaveChangesAsync();
        //        var cities = await _pandaDbContext.Cities.ToListAsync();
        //        var result = _mapper.Map<List<CityResponse>>(cities);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error($"[PandaRepo] - [Delete] {ex.Message}");
        //        throw new Exception(ex.Message);
        //    }
        //}
        #endregion
    }
}
