
using System.Linq.Expressions;
using Bakim.Core.Utilities.Results;
using Bakim.Entity;

namespace Bakim.Business.Abstracts
{
    public interface IWorkTaskUserService
    {
        public IDataResult<List<WorkTaskUser>> GetTaskUsers(int workTaskId);
        public IDataResult<WorkTaskUser> GetTaskUser(Expression<Func<WorkTaskUser,bool>> expression);
        public IResult Add(WorkTaskUser workTaskUser);
        public IResult Delete(WorkTaskUser workTaskUser);
        public IResult Update(WorkTaskUser workTaskUser);
    }
}
