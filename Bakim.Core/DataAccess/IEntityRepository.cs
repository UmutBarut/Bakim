using Bakim.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bakim.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        void InsertAsync(T entity);
        void InsertRangeAsync(List<T> entities);
        void Delete(T entity);
        void DeleteRange(List<T> entities);
        void Update(T entity);
        List<T> GetAll(Expression<Func<T, bool>> filter = null, bool tracking = true);
        Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool tracking = true);

    }
}
