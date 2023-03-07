using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bakim.Core.Utilities.Results;
using Bakim.Entity;

namespace Bakim.Business.Abstracts
{
    public interface IMarkaKalemService
    {
        public IDataResult<List<MarkaKalem>> GetAll(Expression<Func<MarkaKalem, bool>> expression = null);
        public IDataResult<MarkaKalem> GetById(Expression<Func<MarkaKalem, bool>> expression);
        public IResult Add(MarkaKalem markaKalem);
        public IResult Update(MarkaKalem markaKalem);
        public IResult Delete(MarkaKalem markaKalem);
    }
}