using Bakim.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bakim.Components
{
    public class Aside : ViewComponent
    {
        
        private readonly UserManager<ApplicationUser> _userManager;

        public Aside(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return View("_Aside",user);
        }
    }
}