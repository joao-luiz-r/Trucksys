using Microsoft.EntityFrameworkCore;
using TruckSys.Domain.Interfaces.Repository;
using TruckSys.Domain.Interfaces.Services;
using TruckSys.Domain.Services;
using TruckSys.Infra.Data;
using TruckSys.Infra.Repository;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TruckContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ITruckService, TruckService>();
builder.Services.AddScoped<ITruckRepository, TruckRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
