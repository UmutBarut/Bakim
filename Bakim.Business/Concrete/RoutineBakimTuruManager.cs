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
    public class RoutineBakimTuruManager : IRoutineBakimTuruService
    {
        private readonly IRoutineBakimTuruDal _routineBakimTuruDal;

        public RoutineBakimTuruManager(IRoutineBakimTuruDal routineBakimTuruDal)
        {
            _routineBakimTuruDal = routineBakimTuruDal;
        }

        public IResult Add(RoutineBakimTuru routinebakimturu)
        {
            _routineBakimTuruDal.InsertAsync(routinebakimturu);
            return new SuccessResult();
        }

        public IResult Delete(RoutineBakimTuru routineBakimTuru)
        {
            _routineBakimTuruDal.Delete(routineBakimTuru);
            return new SuccessResult();
        }

        public IDataResult<List<RoutineBakimTuru>> CalendarList(Expression<Func<RoutineBakimTuru, bool>> expression = null)
        {
            if (expression == null)
            {

            }
            return new SuccessDataResult<List<RoutineBakimTuru>>(_routineBakimTuruDal.GetAll(expression));

        }

        public IDataResult<List<RoutineBakimTuru>> GetAll(Expression<Func<RoutineBakimTuru, bool>> expression = null)
        {
            if (expression == null)
            {
                return new SuccessDataResult<List<RoutineBakimTuru>>(_routineBakimTuruDal.GetAll());

            }
            return new SuccessDataResult<List<RoutineBakimTuru>>(_routineBakimTuruDal.GetAll(expression));
        }
    }
}