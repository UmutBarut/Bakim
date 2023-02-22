using Bakim.Business.Abstracts;
using Bakim.Core.Utilities.Results;
using Bakim.Dataaccess.Abstracts;
using Bakim.Entity;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace Bakim.Business.Concrete
{
    public class WorkTaskManager : IWorkTaskService
    {
        private readonly IWorkTaskDal _workTaskDal;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWorkTaskUserService _userService;
        public WorkTaskManager(IWorkTaskDal workTaskDal, UserManager<ApplicationUser> userManager, IWorkTaskUserService userService)
        {
            _workTaskDal = workTaskDal;
            _userManager = userManager;
            _userService = userService;
        }

        public IResult Add(WorkTask workTask)
        {
            _workTaskDal.InsertAsync(workTask);
            return new SuccessResult();
        }

        public IResult Delete(WorkTask workTask)
        {
            _workTaskDal.Delete(workTask);
            return new SuccessResult();
        }

        public IDataResult<WorkTask> GetSingle(Expression<Func<WorkTask, bool>> expression)
        {
            return new SuccessDataResult<WorkTask>(_workTaskDal.GetAll(expression).FirstOrDefault());
        }

        public IDataResult<List<WorkTask>> GetTasks(Expression<Func<WorkTask, bool>> expression = null)
        {

            if (expression == null)
            {
                return new SuccessDataResult<List<WorkTask>>(_workTaskDal.GetAll());
            }
            return new SuccessDataResult<List<WorkTask>>(_workTaskDal.GetAll(expression));
        }

        public IResult Update(WorkTask workTask)
        {
            _workTaskDal.Update(workTask);
            return new SuccessResult();
        }
    }
}
