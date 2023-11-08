using AutoMapper;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using PandaApplication.Interfaces.Repositories;
using PandaApplication.Interfaces.Repositories.Generic;
using PandaDomain.Entities;
using PandaDomain.Models.Request;
using PandaDomain.Models.Response;
using PandaInfrastructure.ConnectionStrings;
using PandaInfrastructure.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PandaInfrastructure.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly PandaDbContext _pandaDbContext;
        private readonly IMapper _mapper;

        public CityRepository(PandaDbContext pandaDbContext, IMapper mapper)
        {
            _pandaDbContext = pandaDbContext;
            _mapper = mapper;
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
            } catch
            {
                throw new NotImplementedException();
            }
            
        }

        public async Task<CityResponse> GetCityById(int id)
        {
            try
            {
                var city = await _pandaDbContext.Cities.FindAsync(id);
                if (city == null)
                    throw new NotImplementedException();
                var result = _mapper.Map<CityResponse>(city);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            throw new NotImplementedException();
        }

        public Task<List<CityResponse>> AddCity(CityResponse city)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CityResponse>> UpdateCity(UpdateCityRequest cityRequest)
        {
            try
            {
                var city = _mapper.Map<City>(cityRequest);
                _pandaDbContext.Cities.Add(city);
                await _pandaDbContext.SaveChangesAsync();
                var cities = await _pandaDbContext.Cities.ToListAsync();
                var result = _mapper.Map<List<CityResponse>>(cities);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            throw new NotImplementedException();
        }

        public Task<List<CityResponse>> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
