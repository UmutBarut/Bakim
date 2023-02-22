
using Bakim.Core.Utilities.Results;
using Bakim.Entity;
using Bakim.Entity.Dto;
using System.Linq.Expressions;

namespace Bakim.Business.Abstracts
{
    public interface IAnnouncementService
    {
        public IDataResult<List<AnnouncementDto>> GetAll();
        public IDataResult<List<Announcement>> GetAllByFilter(Expression<Func<Announcement, bool>> filter);
        public Task<IDataResult<Announcement>> GetByFilter(Expression<Func<Announcement, bool>> filter);
        public Task<IResult> Create(Announcement announcement);
        public IResult Update(Announcement announcement);
        public IResult Delete(Announcement announcement);
    }
}
