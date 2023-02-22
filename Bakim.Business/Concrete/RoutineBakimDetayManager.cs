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
    public class RoutineBakimDetayManager : IRoutineBakimDetayService
    {
        private readonly IRoutinBakimDetayDal _routineBakimDetayDal;

        public RoutineBakimDetayManager(IRoutinBakimDetayDal routineBakimDetayDal)
        {
            _routineBakimDetayDal = routineBakimDetayDal;
        }

        public IDataResult<List<RoutineBakimDetay>> RoutineBakimDetay(int routineBakimId)
        {
            return new SuccessDataResult<List<RoutineBakimDetay>>(_routineBakimDetayDal.GetAll(c => c.RoutineBakimId == routineBakimId));
        }
    }
}