using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using PopulationСensus.Data;
using PopulationСensus.Domain.Entities;
using PopulationСensus.Domain.Services;
using PopulationСensus.Infrastructure;
//Создание объекта builder с помощью статического метода
//CreateBuilder класса WebApplication. Этот метод используется
//для создания нового экземпляра WebApplicationBuilder, который
//используется для настройки и построения веб-приложения.
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
//Добавление службы контроллеров и представлений
//в коллекцию служб Services. Это позволяет использовать
//контроллеры и представления в приложении ASP.NET Core.
builder.Services.AddControllersWithViews();
//Построение веб-приложения с использованием настроек,
//определенных в объекте builder. Возвращает экземпляр
//WebApplication, который представляет запущенное приложение.
//аутентификации на основе Cookies
builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt =>
    {
        opt.ExpireTimeSpan = TimeSpan.FromHours(1);
        opt.Cookie.Name = "library_session";
        opt.Cookie.HttpOnly = true;
        opt.Cookie.SameSite = SameSiteMode.Strict;
        opt.LoginPath = "/User/Login";
    });

builder.Services.AddDbContext<ELibraryContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("local")));
//Scoped: для каждого запроса создается свой объект сервиса.
//То есть если в течение одного запроса есть несколько обращений
//к одному сервису, то при всех этих обращениях будет использоваться один и тот же объект сервиса.
builder.Services.AddScoped<IRepository<User>, EFRepository<User>>();
builder.Services.AddScoped<IRepository<Role>, EFRepository<Role>>();
builder.Services.AddScoped<IUserService, UserService>();
var app = builder.Build();
//для обработки статических файлов в каталоге wwwroot,
app.UseStaticFiles();
// для подключения маршрутизации,
app.UseRouting();
//аутификанция и авторизация
app.UseAuthentication();
app.UseAuthorization();
//для указания маршрута, по которому нужно выбирать контроллер и его метод (действие).
app.MapControllerRoute("default", "{Controller=Census}/{Action=Index}");

app.Run();