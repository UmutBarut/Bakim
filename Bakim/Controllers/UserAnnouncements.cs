using Bakim.Business.Abstracts;
using Bakim.Entity;
using Bakim.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bakim.Controllers
{
    [Authorize]
    public class UserAnnouncements : Controller
    {
        private readonly IUserAnnouncementService _userAnnouncementService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAnnouncementService _announcementService;
        public UserAnnouncements(IUserAnnouncementService userAnnouncementService, UserManager<ApplicationUser> userManager, IAnnouncementService announcementService)
        {
            _userAnnouncementService = userAnnouncementService;
            _userManager = userManager;
            _announcementService = announcementService;
        }

        public async Task<IActionResult> Index()
        {

            var model = await GetAnnouncements();
            return View(model);
        }

        public async Task<IActionResult> Update(int announcementId)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var userAnnouncement = _userAnnouncementService.GetAll(user.Id).Data.Where(u => u.AnnouncementId == announcementId).First();
            userAnnouncement.HasSeen = true;
            userAnnouncement.SeenDate = DateTime.Now;
            _userAnnouncementService.Update(userAnnouncement);
            return RedirectToAction("Index");
        }
        [NonAction]
        public async Task<List<AnnouncementViewModel>> GetAnnouncements()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var userAnnouncements = _userAnnouncementService.GetAll(user.Id);
            var announcementIds = new List<int>();
            foreach (var userAnnouncement in userAnnouncements.Data)
            {
                announcementIds.Add(userAnnouncement.AnnouncementId);
            }

            var announcements = new List<AnnouncementViewModel>();
            foreach (var id in announcementIds)
            {

                var item = await _announcementService.GetByFilter(a => a.AnnouncementId == id);
                AnnouncementViewModel viewModel = new AnnouncementViewModel()
                {
                    AnnouncementId = item.Data.AnnouncementId,
                    Body = item.Data.Body,
                    IsEmergency = item.Data.IsEmergency,
                    PublishDate = item.Data.PublishDate,
                    PublisherName = item.Data.PublisherName,
                    Roles = item.Data.Roles,
                    Title = item.Data.Title,
                    HasSeen = userAnnouncements.Data.Where(u => u.AnnouncementId == item.Data.AnnouncementId).First().HasSeen
                };
                announcements.Add(viewModel);
            }
            return announcements.OrderByDescending(u => u.PublishDate).ToList();
        }

    }
}
