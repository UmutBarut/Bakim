
using Bakim.Business.Abstracts;
using Bakim.Core.Utilities.Results;
using Bakim.Dataaccess.Abstracts;
using Bakim.Entity;
using Bakim.Entity.Dto;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bakim.Business.Concrete
{
    public class AnnouncementManager : IAnnouncementService
    {
        private readonly IAnnouncementDal _announcementDal;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserAnnouncementService _userAnnouncementService;

        public AnnouncementManager(IAnnouncementDal announcementDal, UserManager<ApplicationUser> userManager, IUserAnnouncementService userAnnouncementService)
        {
            _announcementDal = announcementDal;
            _userManager = userManager;
            _userAnnouncementService = userAnnouncementService;
        }

        public async Task<IResult> Create(Announcement announcement)
        {
            _announcementDal.InsertAsync(announcement);
            var roles = announcement.Roles.Split(",");
            List<ApplicationUser> usersInRole = new List<ApplicationUser>();
            List<UserAnnouncement> userAnnouncements = new List<UserAnnouncement>();
            foreach (var role in roles)
            {
                usersInRole.AddRange(await _userManager.GetUsersInRoleAsync(role));
            }
            foreach (var user in usersInRole)
            {
                UserAnnouncement userAnnouncement = new UserAnnouncement()
                {
                    Announcement = announcement,
                    AnnouncementId = announcement.AnnouncementId,
                    ApplicationUser = user,
                    ApplicationUserId = user.Id,
                    HasSeen = false,
                };
                userAnnouncements.Add(userAnnouncement);
            }
            await _userAnnouncementService.AddRangeAsync(userAnnouncements);


            return new SuccessResult();
        }

        public IResult Delete(Announcement announcement)
        {
            _announcementDal.Delete(announcement);
            return new SuccessResult();
        }

        public IDataResult<List<AnnouncementDto>> GetAll()
        {
            var result = _announcementDal.GetAll();
            List<AnnouncementDto> dto = new List<AnnouncementDto>();
            foreach (var item in result)
            {
                AnnouncementDto announcementDto = new AnnouncementDto()
                {
                    AnnouncementId = item.AnnouncementId,
                    IsEmergency = item.IsEmergency,
                    PublishDate = item.PublishDate,
                    PublisherName = item.PublisherName,
                    Roles = item.Roles.Split(",").ToList()
                };
                dto.Add(announcementDto);
            }
            return new SuccessDataResult<List<AnnouncementDto>>(dto);
        }

        public IDataResult<List<Announcement>> GetAllByFilter(Expression<Func<Announcement, bool>> filter)
        {
            return new SuccessDataResult<List<Announcement>>(_announcementDal.GetAll(filter));
        }

        public async Task<IDataResult<Announcement>> GetByFilter(Expression<Func<Announcement, bool>> filter)
        {
            return new SuccessDataResult<Announcement>(await _announcementDal.GetByFilter(filter));
        }

        public IResult Update(Announcement announcement)
        {
            _announcementDal.Update(announcement);
            return new SuccessResult();
        }
    }
}
