using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bakim.Core.Utilities.Results;
using Bakim.Entity;

namespace Bakim.Business.Abstracts
{
    public interface IMarkaService
    {
        public IDataResult<List<Marka>> GetAll(Expression<Func<Marka, bool>> expression = null);
        public IDataResult<Marka> GetById(Expression<Func<Marka, bool>> expression);
        public IResult Add(Marka marka);
        public IResult Update(Marka marka);
        public IResult Delete(Marka marka);
    }
}