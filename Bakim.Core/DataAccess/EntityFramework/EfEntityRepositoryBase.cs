using Bakim.Core.DataAccess;
using Bakim.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bakim.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedData = context.Entry(entity);
                deletedData.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }


        public void DeleteRange(List<TEntity> entities)
        {
            using (TContext context = new TContext())
            {
                foreach (var entity in entities)
                {
                    var deletedData = context.Entry(entity);
                    deletedData.State = EntityState.Deleted;
                }
                context.SaveChanges();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, bool tracking = true)
        {
            using (TContext context = new TContext())
            {
                if (filter == null)
                {
                    return context.Set<TEntity>().ToList();
                }
                return context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public async Task<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter, bool tracking = true)
        {
            using (TContext context = new TContext())
            {
                if (filter == null)
                {
                    return context.Set<TEntity>().SingleOrDefault();
                }
                return context.Set<TEntity>().Where(filter).SingleOrDefault();
            }
        }



        public void InsertAsync(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedData = context.Entry(entity);
                addedData.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void InsertRangeAsync(List<TEntity> entities)
        {
            using (TContext context = new TContext())
            {
                foreach (var entity in entities)
                {
                    var addedData = context.Entry(entity);
                    addedData.State = EntityState.Added;
                }
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedData = context.Entry(entity);
                updatedData.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
