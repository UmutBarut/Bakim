using Bakim.Entity;
using Bakim.ViewModels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Bakim.Controllers
{
    
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signinManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signinManager = signinManager;
        }
        public async Task<IActionResult> Logout()
        {
            HttpContext.Response.Cookies.Delete("User");
            ViewData["Title"] = "Çıkış yapılıyor...";
            await _signinManager.SignOutAsync();
            return RedirectToAction("Login", "Auth");
        }


        [HttpGet]
        public async Task<IActionResult> Login()
        {

            ViewData["Title"] = "Panele Giriş";
            var user = HttpContext.Request.Cookies["User"];
            if (!string.IsNullOrEmpty(user))
            {
                UserSignInViewModel userToLogin = new UserSignInViewModel();
                JsonConvert.PopulateObject(user, userToLogin);
                if (userToLogin != null)
                {
                    var result = await _signinManager.PasswordSignInAsync(userToLogin.UserName, userToLogin.Password, false, true);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Login(UserSignInViewModel p)
        {
            ViewData["LoginResult"] = "";
            ViewData["Title"] = "Giriş Yapılıyor";
            if (ModelState.IsValid)
            {
                var result = await _signinManager.PasswordSignInAsync(p.UserName, p.Password, false, true);
                if (result.Succeeded)
                {
                    if (p.RememberMe)
                    {
                        HttpContext.Response.Cookies.Append("User", JsonConvert.SerializeObject(p));
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["LoginResult"] = "Kullanıcı adı veya parola hatalı.";
                    return View(p);
                }

            }
            else
            {
                return View(p);
            }


        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Register()
        {
            ViewData["Title"] = "Kullanıcı Kayıt";

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Register(UserSignUpViewModel p)
        {

            ViewData["Title"] = "Kayıt ediliyor..";
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = p.Mail,
                    UserName = p.Username,
                };
                var result = await _userManager.CreateAsync(user, p.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("KullaniciListele", "Users");

                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);

                    }
                }
            }
            return View(p);
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }


    }
}
