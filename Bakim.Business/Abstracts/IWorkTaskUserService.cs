
using Bakim.Core.Utilities.Results;
using Bakim.Entity;

namespace Bakim.Business.Abstracts
{
    public interface IWorkTaskUserService
    {
        public IDataResult<List<WorkTaskUser>> GetTaskUsers(int workTaskId);
        public IDataResult<WorkTaskUser> GetTaskUser(string userId);
        public IResult Add(WorkTaskUser workTaskUser);
        public IResult Delete(WorkTaskUser workTaskUser);
        public IResult Update(WorkTaskUser workTaskUser);
    }
}
