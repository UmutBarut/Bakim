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
    public class MarkaKalemManager : IMarkaKalemService
    {
        private readonly IMarkaKalemDal _markaKalemDal;

        public MarkaKalemManager(IMarkaKalemDal markaKalemDal)
        {
            _markaKalemDal = markaKalemDal;
        }

        public IResult Add(MarkaKalem markaKalem)
        {
           _markaKalemDal.InsertAsync(markaKalem);
           return new SuccessResult();
        }

        public IResult Delete(MarkaKalem markaKalem)
        {
            _markaKalemDal.Delete(markaKalem);
           return new SuccessResult();
        }

         public IDataResult<List<MarkaKalem>> GetAll(Expression<Func<MarkaKalem, bool>> expression = null)
        {
            if (expression == null)
            {
                return new SuccessDataResult<List<MarkaKalem>>(_markaKalemDal.GetAll());
            }
            return new SuccessDataResult<List<MarkaKalem>>(_markaKalemDal.GetAll(expression));
        }

         public IDataResult<MarkaKalem> GetById(Expression<Func<MarkaKalem, bool>> expression = null)
        {
            return new SuccessDataResult<MarkaKalem>(_markaKalemDal.GetAll(expression).FirstOrDefault());
        }

        public IResult Update(MarkaKalem markaKalem)
        {
            _markaKalemDal.Update(markaKalem);
           return new SuccessResult();
        }
    }
}