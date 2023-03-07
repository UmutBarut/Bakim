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
    public class MarkaGrupManager : IMarkaGrupService
    {
        private readonly IMarkaGrupDal _markaGrupDal;

        public MarkaGrupManager(IMarkaGrupDal markaGrupDal)
        {
            _markaGrupDal = markaGrupDal;
        }

        public IResult Add(MarkaGrup markaGrup)
        {
            _markaGrupDal.InsertAsync(markaGrup);
            return new SuccessResult();
        }

        public IResult Delete(MarkaGrup markaGrup)
        {
            _markaGrupDal.Delete(markaGrup);
            return new SuccessResult();
        }

        public IDataResult<List<MarkaGrup>> GetAll(Expression<Func<MarkaGrup, bool>> expression = null)
        {
            if (expression == null)
            {
                return new SuccessDataResult<List<MarkaGrup>>(_markaGrupDal.GetAll());
            }
            return new SuccessDataResult<List<MarkaGrup>>(_markaGrupDal.GetAll(expression));
        }
        public IDataResult<MarkaGrup> GetById(Expression<Func<MarkaGrup, bool>> expression = null)
        {
            return new SuccessDataResult<MarkaGrup>(_markaGrupDal.GetAll(expression).FirstOrDefault());
        }

        public IResult Update(MarkaGrup markaGrup)
        {
            _markaGrupDal.Update(markaGrup);
            return new SuccessResult();
        }
    }
}