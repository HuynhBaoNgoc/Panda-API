using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PandaApplication.Interfaces.Repositories;
using PandaDomain.Entities;
using PandaDomain.Models.Request;
using PandaDomain.Models.Response;
using PandaInfrastructure.ConnectionStrings;
using Serilog;

namespace PandaInfrastructure.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly PandaDbContext _pandaDbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<CityRepository> _logger;

        public CityRepository(PandaDbContext pandaDbContext, IMapper mapper, ILogger<CityRepository> logger)
        {
            _pandaDbContext = pandaDbContext;
            _mapper = mapper;
            _logger = logger;
        }

        //public async Task<List<CityResponse>> GetListCity()
        //{ 
        //    using (var connection = new MySqlConnection() { ConnectionString = _pandaDbContext.GetConnectionString() })
        //    {
        //        var sql = $@"SELECT * FROM pandadb.city;";

        //        var queryParameters = new DynamicParameters();
        //        var response = (await connection.QueryAsync<CityResponse>(sql, queryParameters, commandType: CommandType.Text)).ToList();
        //        return response;
        //    };
        //}

        public async Task<List<CityResponse>> GetListCity()
        {
            try
            {
                var cities = await _pandaDbContext.Cities.ToListAsync();
                var result = _mapper.Map<List<CityResponse>>(cities);
                return result;
            }
            catch (Exception ex)
            {
                Log.Error($"[CityRepo] - [GetListCity] {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<CityResponse> GetCityById(int id)
        {
            try
            {
                var city = await _pandaDbContext.Cities.FindAsync(id);
                if (city == null)
                {
                    Log.Information("Id not found");
                    return new CityResponse();
                }
                var result = _mapper.Map<CityResponse>(city);
                return result;
            }
            catch (Exception ex)
            {
                Log.Error($"[CityRepo] - [GetCityById] {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<CityResponse>> AddCity(AddCityRequest cityRequest)
        {
            try
            {
                var city = _mapper.Map<City>(cityRequest);
                _pandaDbContext.Add(city);
                //_pandaDbContext.Cities.Add(new City()
                //{
                //    CityName = cityRequest.CityName
                //});
                await _pandaDbContext.SaveChangesAsync();
                var cities = await _pandaDbContext.Cities.ToListAsync();
                var result = _mapper.Map<List<CityResponse>>(cities);
                return result;
            }
            catch (Exception ex)
            {
                Log.Error($"[CityRepo] - [AddCity] {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<CityResponse> UpdateCity(UpdateCityRequest cityRequest)
        {
            try
            {
                //var city = await _pandaDbContext.Cities.FindAsync(cityRequest.CityId);
                //if (city == null)
                //    throw new NotImplementedException();
                var newInfo = _mapper.Map<City>(cityRequest);
                _pandaDbContext.Set<City>().Update(newInfo);
                await _pandaDbContext.SaveChangesAsync();
                var city = await _pandaDbContext.Cities.FindAsync(cityRequest.CityId);
                var result = _mapper.Map<CityResponse>(city);
                return result;
            }
            catch (Exception ex)
            {
                Log.Error($"[CityRepo] - [UpdateCity] {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<CityResponse>> Delete(int id)
        {
            try
            {
                var city = await _pandaDbContext.Cities.FindAsync(id);
                if (city == null)
                {
                    Log.Information("Id not found");
                    return new List<CityResponse>();
                }
              
                _pandaDbContext.Set<City>().Remove(city);
                await _pandaDbContext.SaveChangesAsync();
                var cities = await _pandaDbContext.Cities.ToListAsync();
                var result = _mapper.Map<List<CityResponse>>(cities);
                return result;
            }
            catch (Exception ex)
            {
                Log.Error($"[CityRepo] - [Delete] {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
