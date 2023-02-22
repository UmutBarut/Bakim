using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bakim.Core.Utilities.Results;
using Bakim.Entity;

namespace Bakim.Business.Abstracts
{
    public interface IBirimService
    {
        public IDataResult<List<Birim>> GetAll(Expression<Func<Birim, bool>> expression = null);
        public IDataResult<Birim> GetById(Expression<Func<Birim,bool>> expression);
        public IResult Add(Birim birim);
        public IResult Delete(Birim birim);
        public IResult Update(Birim birim);
    }
}