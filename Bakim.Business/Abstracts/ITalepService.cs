using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bakim.Core.Utilities.Results;
using Bakim.Entity;

namespace Bakim.Business.Abstracts
{
    public interface ITalepService
    {
        public IDataResult<List<Talep>> GetAll(Expression<Func<Talep, bool>> expression = null);
        public IDataResult<Talep> GetById(Expression<Func<Talep, bool>> expression);
        public IResult Add(Talep talep);
        public IResult Update(Talep talep);
        public IResult Delete(Talep talep);
    }
}