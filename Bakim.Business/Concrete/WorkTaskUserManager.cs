using System.Linq.Expressions;
using Bakim.Business.Abstracts;
using Bakim.Core.Utilities.Results;
using Bakim.Dataaccess.Abstracts;
using Bakim.Entity;

namespace Bakim.Business.Concrete
{
    public class WorkTaskUserManager : IWorkTaskUserService
    {
        private readonly IWorkTaskUserDal _workTaskUserDal;

        public WorkTaskUserManager(IWorkTaskUserDal workTaskUserDal)
        {
            _workTaskUserDal = workTaskUserDal;
        }

        public IResult Add(WorkTaskUser workTaskUser)
        {
            _workTaskUserDal.InsertAsync(workTaskUser);
            return new SuccessResult();
        }

        public IResult Delete(WorkTaskUser workTaskUser)
        {
            _workTaskUserDal.Delete(workTaskUser);
            return new SuccessResult();
        }

        public IDataResult<WorkTaskUser> GetTaskUser(Expression<Func<WorkTaskUser, bool>> expression = null)
        {
            return new SuccessDataResult<WorkTaskUser>(_workTaskUserDal.GetAll(expression).FirstOrDefault());
        }

        public IDataResult<List<WorkTaskUser>> GetTaskUsers(int workTaskId)
        {
            return new SuccessDataResult<List<WorkTaskUser>>(_workTaskUserDal.GetAll(c => c.WorkTaskId == workTaskId));
        }

        public IResult Update(WorkTaskUser workTaskUser)
        {
            _workTaskUserDal.Update(workTaskUser);
            return new SuccessResult();
        }
    }
}
