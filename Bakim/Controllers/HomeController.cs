using Bakim.Business.Abstracts;
using Bakim.Entity;
using Bakim.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bakim.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

         private readonly IWorkTaskService _workTaskService;

        public HomeController(IWorkTaskService workTaskService,UserManager<ApplicationUser> userManager)
        {
            _workTaskService = workTaskService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            HomeStatViewModel viewModel = new HomeStatViewModel()
            {
                NotCompletedCount = _workTaskService.GetTasks(t => t.IsCompleted == false).Data.Count(),
                WorkTasks = _workTaskService.GetTasks(t=>t.ReceiverId == user.Id).Data
                // SpecialNotCompletedCount = _workTaskService.GetTasks(t => t.IsCompleted == false && t.ReceiverId == user.Id).Data.Count(),
                // NotSeenAnnouncementCount = _userAnnouncementService.GetNotSeen(user.Id).Data.Count(),
                // User = user,
                // TotalRecord = _workTaskService.GetTasks(t=>t.CreatedDate.Day == DateTime.Now.Day).Data.Count()
            };
            return View(viewModel);

        }

    }
}





