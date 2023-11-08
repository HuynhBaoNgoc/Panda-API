using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.EntityFrameworkCore;
using PandaDomain.Mappings;
using PandaInfrastructure;
using PandaInfrastructure.ConnectionStrings;

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

//var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<PandaDbContext>();

var app = builder.Build();

//using (var serviceScope = app.Services.CreateScope())
//{
//    var context = serviceScope.ServiceProvider.GetRequiredService<PandaDbContext>();
//    context.Database.EnsureCreated();
//}

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
