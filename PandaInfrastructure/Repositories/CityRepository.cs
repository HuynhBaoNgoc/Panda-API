using Dapper;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using PandaApplication.Interfaces.Repositories;
using PandaApplication.Interfaces.Repositories.Generic;
using PandaDomain.Entities;
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

        public CityRepository(PandaDbContext pandaDbContext)
        {
            _pandaDbContext = pandaDbContext;
        }
        public async Task<List<CityResponse>> GetListCity()
        { 
            using (var connection = new MySqlConnection() { ConnectionString = _pandaDbContext.GetConnectionString() })
            {
                var sql = $@"SELECT * FROM pandadb.city;";

                var queryParameters = new DynamicParameters();
                var response = (await connection.QueryAsync<CityResponse>(sql, queryParameters, commandType: CommandType.Text)).ToList();
                return response;
            };
        }
    }
}
