using Microsoft.EntityFrameworkCore;
using TruckSys.Infra.Data;
using Microsoft.Extensions.DependencyInjection;
using TruckSys.Domain.Interfaces.Repository;
using TruckSys.Domain.Interfaces.Services;
using TruckSys.Domain.Services;
using TruckSys.Infra.Repository;
using NuGet.Protocol.Core.Types;
using TruckSys.Entities;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TruckContext>(options => options.UseSqlServer(connectionString));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddMvcCore();

builder.Services.AddScoped<ITruckService, TruckService>();
builder.Services.AddScoped<ITruckRepository, TruckRepository>();


var app = builder.Build();

//Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Trucks}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<TruckSys.Infra.Data.TruckContext>();
    context.Database.EnsureCreated();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
