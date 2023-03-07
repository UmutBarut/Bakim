using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bakim.Core.Utilities.Results;
using Bakim.Entity;

namespace Bakim.Business.Abstracts
{
    public interface IMarkaGrupService
    {
         public IDataResult<List<MarkaGrup>> GetAll(Expression<Func<MarkaGrup, bool>> expression = null);
        public IDataResult<MarkaGrup> GetById(Expression<Func<MarkaGrup, bool>> expression);
        public IResult Add(MarkaGrup markaGrup);
        public IResult Update(MarkaGrup markaGrup);
        public IResult Delete(MarkaGrup markaGrup);
    }
}