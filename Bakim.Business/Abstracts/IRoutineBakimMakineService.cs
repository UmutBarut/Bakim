using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bakim.Core.Utilities.Results;
using Bakim.Entity;

namespace Bakim.Business.Abstracts
{
    public interface IRoutineBakimMakineService
    {
        public IDataResult<List<RoutineBakimMakine>> RoutineBakimMakine(Expression<Func<RoutineBakimMakine, bool>> expression = null);

        public IDataResult<List<RoutineBakimMakine>> GetAll(Expression<Func<RoutineBakimMakine,bool>> expression = null);
        
    }
}