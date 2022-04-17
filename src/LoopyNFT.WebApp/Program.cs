using ElCamino.AspNetCore.Identity.AzureTable.Model;
using LoopyNFT.WebApp.Areas.Identity;
using LoopyNFT.WebApp.Data;
using LoopyNFT.WebApp.Entities;
using LoopyNFT.WebApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddAzureTableStores<ApplicationDbContext>(new Func<IdentityConfiguration>(() =>
    {
        IdentityConfiguration idconfig = new IdentityConfiguration();
        idconfig.TablePrefix = builder.Configuration.GetSection("IdentityAzureTable:IdentityConfiguration:TablePrefix").Value;
        idconfig.StorageConnectionString = builder.Configuration.GetSection("IdentityAzureTable:IdentityConfiguration:StorageConnectionString").Value;
        idconfig.LocationMode = builder.Configuration.GetSection("IdentityAzureTable:IdentityConfiguration:LocationMode").Value;
        idconfig.IndexTableName = builder.Configuration.GetSection("IdentityAzureTable:IdentityConfiguration:IndexTableName").Value; // default: AspNetIndex
        idconfig.RoleTableName = builder.Configuration.GetSection("IdentityAzureTable:IdentityConfiguration:RoleTableName").Value;   // default: AspNetRoles
        idconfig.UserTableName = builder.Configuration.GetSection("IdentityAzureTable:IdentityConfiguration:UserTableName").Value;   // default: AspNetUsers
        return idconfig;
    }))
    .AddDefaultTokenProviders()
    .AddDefaultUI()
    .AddUserManager<UserManager<AppUser>>()
    .CreateAzureTablesIfNotExists<ApplicationDbContext>();
builder.Services.AddAuthentication(options =>
{

});
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<AppUser>>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;

    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 10000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddHttpClient<ICollectionService, CollectionService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetSection("services:collection:endpoint").Value);
});
builder.Services.AddHttpClient<IAccountService, AccountService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7045/user");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
