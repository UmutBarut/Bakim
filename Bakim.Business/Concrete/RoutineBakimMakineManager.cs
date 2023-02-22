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
    public class RoutineBakimMakineManager : IRoutineBakimMakineService
    {
        private readonly IRoutineBakimMakineDal _routineBakimMakineDal;


        public RoutineBakimMakineManager(IRoutineBakimMakineDal routineBakimMakineDal)
        {
            _routineBakimMakineDal = routineBakimMakineDal;
        }

        public IDataResult<List<RoutineBakimMakine>> GetAll(Expression<Func<RoutineBakimMakine, bool>> expression = null)
        {
            if(expression == null){
                return new SuccessDataResult<List<RoutineBakimMakine>>(_routineBakimMakineDal.GetAll());
            }
                return new SuccessDataResult<List<RoutineBakimMakine>>(_routineBakimMakineDal.GetAll(expression));

        }

        public IDataResult<List<RoutineBakimMakine>> RoutineBakimMakine(Expression<Func<RoutineBakimMakine, bool>> expression = null)
        {
            throw new NotImplementedException();
        }
    }
}