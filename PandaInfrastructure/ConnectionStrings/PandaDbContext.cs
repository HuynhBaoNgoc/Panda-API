using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PandaDomain.Entities;

namespace PandaInfrastructure.ConnectionStrings
{
    public class PandaDbContext : DbContext
    {
        private readonly IConnectionStringService _connectionStringService;
        public PandaDbContext(DbContextOptions<PandaDbContext> options) : base(options) { }
        public PandaDbContext(
            DbContextOptions<PandaDbContext> options, IConnectionStringService connectionStringService) : base(options)
        {
            _connectionStringService = connectionStringService;
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Panda> Pandas { get; set; }

        

        //protected readonly IConfiguration Configuration;

        //public PandaDbContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _connectionStringService.Create();
            if (!optionsBuilder.IsConfigured)
            {
                //var connectionString = Configuration.GetConnectionString("Default");
                optionsBuilder.UseMySQL("server=localhost;user=root;password=root;database=pandadb;port=3306;",
                    options => options.MigrationsAssembly("pandainfrastructure"));
                //optionsBuilder.UseMySQL(connectionString,
                //    options => options.MigrationsAssembly("PandaInfrastructure"));
            }
        }

        public string GetConnectionString()
        {
            return _connectionStringService.Create();
        }
    }
}
