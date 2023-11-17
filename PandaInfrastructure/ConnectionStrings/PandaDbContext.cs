using Microsoft.EntityFrameworkCore;
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
        public DbSet<Food> Foods { get; set; }
        public DbSet<PandaFavoriteFood> PandaFavoriteFoods { get; set; }
        public DbSet<User> User { get; set; }


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
                //optionsBuilder.UseMySQL("server=localhost;user=root;password=root;database=pandadb;port=3306;",
                //    options => options.MigrationsAssembly("PandaInfrastructure"));
                optionsBuilder.UseMySQL(connectionString,
                    options => options.MigrationsAssembly("PandaInfrastructure"));
            }
        }

        public string GetConnectionString()
        {
            Console.WriteLine(_connectionStringService.Create());
            return _connectionStringService.Create();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PandaFavoriteFood>(e =>
            {
                e.HasKey(k => new { k.PandaId, k.FoodId });
            });

            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();
        }
    }
}
