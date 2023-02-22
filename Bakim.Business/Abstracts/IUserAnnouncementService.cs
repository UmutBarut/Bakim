

using Bakim.Core.Utilities.Results;
using Bakim.Entity;

namespace Bakim.Business.Abstracts
{
    public interface IUserAnnouncementService
    {
        public IDataResult<List<UserAnnouncement>> GetAll(string userId);
        public IDataResult<List<UserAnnouncement>> GetNotSeen(string userId);
        public IResult Update(UserAnnouncement userAnnouncement);
        public Task<IResult> AddRangeAsync(List<UserAnnouncement> userAnnouncement);
    }
}
