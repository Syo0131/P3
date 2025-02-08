using Aplication.Services;
using DataBase.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("MiniTV");


builder.Services.AddDbContext<ItlaTvContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<SerieServices>();
builder.Services.AddScoped<ProductoraServices>();
builder.Services.AddScoped<GeneroServices>();



// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=HomeView}/{id?}");

app.Run();
