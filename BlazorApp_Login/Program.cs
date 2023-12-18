using System;
using BlazorApp_Login.Data;
using BlazorApp_Login.Interface;
using BlazorApp_Login.Repositories;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddDbContext<AddDbContext>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("Connection")
));
builder.Services.AddScoped(p => new HttpClient { BaseAddress = new Uri("https://locakhost:7145") });
var app = builder.Build();

// Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
static void ConfigureServices(IServiceCollection services)
{
    services.AddRazorPages();
    services.AddServerSideBlazor();
    services.AddSingleton<IUserRepository, UserRepository>();


}