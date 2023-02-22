using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bakim.Core.Utilities.Results;
using Bakim.Entity;

namespace Bakim.Business.Abstracts
{
    public interface IVarlikService
    {
        public IDataResult<List<Varlik>>GetAll(Expression<Func<Varlik,bool>> expression = null);
        public IDataResult<Varlik> GetById(Expression<Func<Varlik, bool>> expression);
        public IResult Add(Varlik varlik);
        public IResult Delete(Varlik varlik);
        public IResult Update(Varlik varlik);
       
    }
}