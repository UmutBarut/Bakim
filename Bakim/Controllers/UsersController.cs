using Bakim.Entity;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Bakim.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public object GetUsers(DataSourceLoadOptions LoadOptions)
        {
            var result = _userManager.Users.ToList();
            return DataSourceLoader.Load(result, LoadOptions);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string key)
        {
            var newUser = await _userManager.FindByIdAsync(key);
            var appUser = await _userManager.GetUserAsync(HttpContext.User);
            if (newUser != null && newUser != appUser && !newUser.IsAdmin)
            {
                var result = await _userManager.DeleteAsync(newUser);
                return Ok();
            }
            else
            {
                return BadRequest("Kendi kullanıcınızı veya bir admini silemezsiniz. Lütfen bize başvurun.");
            }

        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(string key, string values)
        {
            var newUser = await _userManager.FindByIdAsync(key);
            JsonConvert.PopulateObject(values, newUser);
            if (newUser.IsAdmin)
            {
                var roleResult = await _userManager.AddToRoleAsync(newUser, "Admin");
            }
            else
            {
                var roleResult = await _userManager.RemoveFromRoleAsync(newUser, "Admin");
            }
            var result = await _userManager.UpdateAsync(newUser);
            if (result.Succeeded)
            {
                return Ok("Kullanıcı güncellendi.");
            }
            else
            {
                return BadRequest("Kullanıcı güncellenirken hata oluştu.");
            }
        }

        public IActionResult KullaniciListele()
        {
            return View();
        }

        public IActionResult KullaniciEkle()
        {
            return View();
        }

         public IActionResult KullaniciCikar()
        {
            return View();
        }
    }
}
