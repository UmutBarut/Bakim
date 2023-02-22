using Bakim.Core.Utilities.Results;
using Bakim.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Bakim.Business.Abstracts
{
    public interface IRoutineBakimService
    {
        public IDataResult<List<RoutineBakim>> RoutineBakimList();
        public IResult Add(RoutineBakim routineBakim);
    }
}