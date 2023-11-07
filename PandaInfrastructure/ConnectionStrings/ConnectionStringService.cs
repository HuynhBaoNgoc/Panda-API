using Microsoft.Extensions.Options;
using PandaDomain.Models.Options;

namespace PandaInfrastructure.ConnectionStrings
{
    public class ConnectionStringService : IConnectionStringService
    {
        private const string ConnectionStringFormat =
            "server={0};port={1};database={2};user={3};password={4};ConvertZeroDateTime=True;Old Guids=true;{5}";
        private readonly IOptionsMonitor<DatabaseOptions> _options;

        public ConnectionStringService(IOptionsMonitor<DatabaseOptions> options)
        {
            _options = options;
        }

        public string Create()
        {
            var options = _options.CurrentValue;
            Console.WriteLine(string.Format(
                ConnectionStringFormat,
                options.Server,
                options.Port,
                options.Database,
                options.User,
                options.Password,
                options.Options));
            return string.Format(
                ConnectionStringFormat,
                options.Server,
                options.Port,
                options.Database,
                options.User,
                options.Password,
                options.Options);
        }
    }
}
