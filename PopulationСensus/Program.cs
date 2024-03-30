using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Population�ensus.Data;
using Population�ensus.Domain.Entities;
using Population�ensus.Domain.Services;
using Population�ensus.Infrastructure;
//�������� ������� builder � ������� ������������ ������
//CreateBuilder ������ WebApplication. ���� ����� ������������
//��� �������� ������ ���������� WebApplicationBuilder, �������
//������������ ��� ��������� � ���������� ���-����������.
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
//���������� ������ ������������ � �������������
//� ��������� ����� Services. ��� ��������� ������������
//����������� � ������������� � ���������� ASP.NET Core.
builder.Services.AddControllersWithViews();
//���������� ���-���������� � �������������� ��������,
//������������ � ������� builder. ���������� ���������
//WebApplication, ������� ������������ ���������� ����������.
//�������������� �� ������ Cookies
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
//Scoped: ��� ������� ������� ��������� ���� ������ �������.
//�� ���� ���� � ������� ������ ������� ���� ��������� ���������
//� ������ �������, �� ��� ���� ���� ���������� ����� �������������� ���� � ��� �� ������ �������.
builder.Services.AddScoped<IRepository<User>, EFRepository<User>>();
builder.Services.AddScoped<IRepository<Role>, EFRepository<Role>>();
builder.Services.AddScoped<IUserService, UserService>();
var app = builder.Build();
//��� ��������� ����������� ������ � �������� wwwroot,
app.UseStaticFiles();
// ��� ����������� �������������,
app.UseRouting();
//������������ � �����������
app.UseAuthentication();
app.UseAuthorization();
//��� �������� ��������, �� �������� ����� �������� ���������� � ��� ����� (��������).
app.MapControllerRoute("default", "{Controller=Census}/{Action=Index}");

app.Run();