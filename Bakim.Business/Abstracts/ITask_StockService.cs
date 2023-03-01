using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bakim.Core.Utilities.Results;
using Bakim.Entity;

namespace Bakim.Business.Abstracts
{
    public interface ITask_StockService
    {
        public IDataResult<List<Task_Stock>> GetAll(Expression<Func<Task_Stock, bool>> expression = null);
        public IDataResult<Task_Stock> GetById(Expression<Func<Task_Stock, bool>> expression);
        public IResult Add(Task_Stock task_Stock);
        public IResult Update(Task_Stock task_Stock);
        public IResult Delete(Task_Stock task_Stock);
    }
}