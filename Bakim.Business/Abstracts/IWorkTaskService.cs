
using Bakim.Core.Utilities.Results;
using Bakim.Entity;
using System.Linq.Expressions;

namespace Bakim.Business.Abstracts
{
    public interface IWorkTaskService
    {
        public IDataResult<List<WorkTask>> GetTasks(Expression<Func<WorkTask, bool>> expression = null);
        public IDataResult<WorkTask> GetSingle(Expression<Func<WorkTask, bool>> expression);
        public IResult Add(WorkTask workTask);
        public IResult Delete(WorkTask workTask);
        public IResult Update(WorkTask workTask);
    }
}
