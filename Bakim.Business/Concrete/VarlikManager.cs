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
    public class VarlikManager : IVarlikService
    {
        private readonly IVarlikDal _varlikDal;

        public VarlikManager(IVarlikDal varlikDal)
        {
            _varlikDal = varlikDal;
        }

        public IResult Add(Varlik varlik)
        {
           _varlikDal.InsertAsync(varlik);
           return new SuccessResult();
        }

        public IResult Delete(Varlik varlik)
        {
            _varlikDal.Delete(varlik);
           return new SuccessResult();
        }

        public IDataResult<List<Varlik>>GetAll(Expression<Func<Varlik, bool>> expression = null)
        {
            if(expression==null)
           {
            return new SuccessDataResult<List<Varlik>>(_varlikDal.GetAll());
           }
            return new SuccessDataResult<List<Varlik>>(_varlikDal.GetAll(expression));

        }
        public IDataResult<Varlik> GetById(Expression<Func<Varlik, bool>> expression)
        {
            return new SuccessDataResult<Varlik>(_varlikDal.GetAll(expression).FirstOrDefault());
        }

        public IResult Update(Varlik varlik)
        {
            _varlikDal.Update(varlik);
           return new SuccessResult();
        }
    }
}