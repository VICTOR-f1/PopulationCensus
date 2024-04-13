using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PopulationСensus.Domain.Entities;
using PopulationСensus.Domain.Services;
using PopulationСensus.ViewModels;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace PopulationСensus.Controllers
{
    public class UserController : Controller
    {
        private const int adminRoleId = 2;
        private const int clientRoleId = 1;
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            User? user = await userService.GetUserAsync(loginViewModel.Email, loginViewModel.Password);
            if (user is not null)
            {
                await SignIn(user);
                return RedirectToAction("Index", "Census");
            }
            try
            {
                ModelState.AddModelError("reg_error", $"Неверное имя пользователя или пароль");
                return View(loginViewModel);
            }
            catch
            {
                ModelState.AddModelError("reg_error", $"Неверное имя пользователя или пароль");
                return View(loginViewModel);
            }
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login", "User");
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel registration)
        {
            
            if (!ModelState.IsValid)
            {
                return View(registration);
            }
            if (await userService.IsUserExistsAsync(registration.Email))
            {
                ViewBag.modelError = $"Почта {registration.Email} уже существует!";
                ModelState.AddModelError("user_exists", $"Почта {registration.Email} уже существует!");
                return View(registration);
            }
            try
            {
                await userService.RegistrationAsync(registration.Fullname, registration.Email, registration.Password, (DateTime)registration.DateOfBirth,registration.PhoneNumber,registration.State,registration.City,registration.Street, (short)registration.ApartmentNumber, (int)registration.ZipCode);
                return RedirectToAction("RegistrationSuccess", "User");
            }
            catch
            {
                ViewBag.modelError = "Не удалось зарегистрироваться, попробуйте попытку регистрации позже";
                ModelState.AddModelError("reg_error", $"Не удалось зарегистрироваться, попробуйте попытку регистрации позже");
                return View(registration);
            }
        }
        public IActionResult RegistrationSuccess()
        {
            return View();
        }
        private async Task SignIn(User user)
        {
            string role = user.RoleId switch
            {
                adminRoleId => "admin",
                clientRoleId => "client",
                _ => throw new ApplicationException("invalid user role")
            };

            List<Claim> claims = new List<Claim>
            {
            new Claim("fullname", user.FullName),
            new Claim("id", user.Id.ToString()),
            new Claim("role", role),
            new Claim("email", user.Email)
            };
            string authType = CookieAuthenticationDefaults.AuthenticationScheme;
            IIdentity identity = new ClaimsIdentity(claims, authType, "email", "role");
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal);
        }
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
     
    

    }
}
