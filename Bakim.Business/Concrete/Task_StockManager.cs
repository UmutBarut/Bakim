using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bakim.Business.Abstracts;
using Bakim.Core.Utilities.Results;
using Bakim.Dataaccess.Abstracts;
using Bakim.Entity;

namespace Bakim.Business.Concrete
{
    public class Task_StockManager : ITask_StockService
    {
        private readonly ITask_StockDal _task_StockDal;

        public Task_StockManager(ITask_StockDal task_StockDal)
        {
            _task_StockDal = task_StockDal;
        }

        public IResult Add(Task_Stock task_Stock)
        {
            _task_StockDal.InsertAsync(task_Stock);
            return new SuccessResult();
        }

        public IResult Delete(Task_Stock task_Stock)
        {
            _task_StockDal.Delete(task_Stock);
            return new SuccessResult();
        }

        public IDataResult<List<Task_Stock>> GetAll(Expression<Func<Task_Stock, bool>> expression = null)
        {
            if (expression == null)
            {
                return new SuccessDataResult<List<Task_Stock>>(_task_StockDal.GetAll());
            }
            return new SuccessDataResult<List<Task_Stock>>(_task_StockDal.GetAll(expression));
        }

         public IDataResult<Task_Stock> GetById(Expression<Func<Task_Stock, bool>> expression = null)
        {
            return new SuccessDataResult<Task_Stock>(_task_StockDal.GetAll(expression).FirstOrDefault());
        }

        public IResult Update(Task_Stock task_Stock)
        {
            _task_StockDal.Update(task_Stock);
            return new SuccessResult();
        }
    }
}