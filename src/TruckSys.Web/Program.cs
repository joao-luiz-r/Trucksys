using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TruckSys.Domain.Interfaces.Repository;
using TruckSys.Domain.Interfaces.Services;
using TruckSys.Domain.Services;
using TruckSys.Infra.Data;
using TruckSys.Infra.Repository;
var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TruckContext>(options => options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ITruckService, TruckService>();
builder.Services.AddScoped<ITruckRepository, TruckRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<TruckSys.Infra.Data.TruckContext>();
    context.Database.EnsureCreated();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Trucks}/{action=Index}/{id?}");

app.Run();
