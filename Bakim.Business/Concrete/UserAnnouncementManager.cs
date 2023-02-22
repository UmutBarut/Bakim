
using Bakim.Business.Abstracts;
using Bakim.Core.Utilities.Results;
using Bakim.Dataaccess.Abstracts;
using Bakim.Entity;

namespace Bakim.Business.Concrete
{
    public class UserAnnouncementManager : IUserAnnouncementService
    {
        private readonly IUserAnnouncementDal _userAnnouncementDal;

        public UserAnnouncementManager(IUserAnnouncementDal userAnnouncementDal)
        {
            _userAnnouncementDal = userAnnouncementDal;
        }

        public async Task<IResult> AddRangeAsync(List<UserAnnouncement> userAnnouncements)
        {
            foreach (var userAnnouncement in userAnnouncements)
            {

                _userAnnouncementDal.InsertAsync(userAnnouncement);
            }
            return new SuccessResult();
        }

        public IDataResult<List<UserAnnouncement>> GetAll(string userId)
        {
            var result = _userAnnouncementDal.GetAll(c => c.ApplicationUserId == userId).ToList();
            return new SuccessDataResult<List<UserAnnouncement>>(result);
        }

        public IDataResult<List<UserAnnouncement>> GetNotSeen(string userId)
        {
            var result = _userAnnouncementDal.GetAll(c => c.ApplicationUserId == userId && c.HasSeen == false).ToList();
            return new SuccessDataResult<List<UserAnnouncement>>(result);

        }

        public IResult Update(UserAnnouncement userAnnouncement)
        {
            _userAnnouncementDal.Update(userAnnouncement);
            return new SuccessResult();
        }
    }
}
