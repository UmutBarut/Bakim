
using Bakim.Business.Abstracts;
using Bakim.Entity;
using Bakim.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bakim.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IFileService _fileService;
        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationUser user;
        

        public AccountController(UserManager<ApplicationUser> userManager, IFileService fileService)
        {
            _userManager = userManager;
            _fileService = fileService;
            
        }

        public async Task<IActionResult> Index()
        {
            user = await GetApplicationUser();
            ViewData["Title"] = user.UserName + " - Hesap Yönetimi";
            return View(user);
        }
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            
            user = await GetApplicationUser();
            await _fileService.Add(file, user);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> SifreDegistir()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SifreDegistir(UserChangePasswordViewModel p)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            if (_userManager.CheckPasswordAsync(user, p.OldPassword).Result)
            {
                var result = await _userManager.ChangePasswordAsync(user, p.OldPassword, p.NewPassword);
                if (result.Succeeded)
                {
                    return RedirectToAction("index", "hesap");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        [NonAction]
        private async Task<ApplicationUser> GetApplicationUser()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }
    }

}
