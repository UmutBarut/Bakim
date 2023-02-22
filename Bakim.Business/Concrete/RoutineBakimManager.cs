using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Business.Abstracts;
using Bakim.Core.Utilities.Results;
using Bakim.Dataaccess.Abstracts;
using Bakim.Entity;

namespace Bakim.Business.Concrete
{
    public class RoutineBakimManager : IRoutineBakimService
    {
        private readonly IRoutinBakimDal _routineBakimDal;

        public RoutineBakimManager(IRoutinBakimDal routineBakimDal)
        {
            _routineBakimDal = routineBakimDal;
        }

        public IResult Add(RoutineBakim routineBakim)
        {
            _routineBakimDal.InsertAsync(routineBakim);
            return new SuccessResult();
        }

        public IDataResult<List<RoutineBakim>> RoutineBakimList()
        {
            return new SuccessDataResult<List<RoutineBakim>>(_routineBakimDal.GetAll());
        }
    }
}