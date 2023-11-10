using PandaDomain.Mappings;
using PandaInfrastructure;
using PandaInfrastructure.ConnectionStrings;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Host.ConfigureServices((context, services) =>
{
    var configuration = context.Configuration;
    services.AddInfrastructure(configuration);
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMappingProfile();
builder.Services.AddSwaggerGen();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Error()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Services.AddDbContext<PandaDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
