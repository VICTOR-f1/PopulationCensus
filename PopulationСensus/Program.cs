using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PopulationÑensus.Data;
using PopulationÑensus.Domain.Entities;
using PopulationÑensus.Domain.Services;
using PopulationÑensus.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
//÷òîáû ìîæíî îòïðàâëÿòü DateTime â PostgreSQL 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
optionsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("local"));
builder.Services.AddControllersWithViews();
builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt =>
    {
        opt.ExpireTimeSpan = TimeSpan.FromHours(1);
        opt.Cookie.Name = "library_session";
        opt.Cookie.HttpOnly = true;
        opt.Cookie.SameSite = SameSiteMode.Strict;
        opt.LoginPath = "/User/Login";
        opt.AccessDeniedPath = "/User/AccessDenied";
    });

builder.Services.AddDbContext<ÑensusContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("local")));
builder.Services.AddScoped<IRepository<User>, EFRepository<User>>();
builder.Services.AddScoped<IRepository<Role>, EFRepository<Role>>();
builder.Services.AddScoped<IRepository<Address>, EFRepository<Address>>();
builder.Services.AddScoped<IRepository<UserAnswer>, EFRepository<UserAnswer>>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserReader, UserReader>();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute("default", "{Controller=Census}/{Action=Index}");
app.Run();
