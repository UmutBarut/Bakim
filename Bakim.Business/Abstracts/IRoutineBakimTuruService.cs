using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bakim.Core.Utilities.Results;
using Bakim.Entity;

namespace Bakim.Business.Abstracts
{
    public interface IRoutineBakimTuruService
    {
        public IResult Add(RoutineBakimTuru routinebakimturu);

        public IResult Delete(RoutineBakimTuru routinebakimTuru);

        public IDataResult<List<RoutineBakimTuru>> GetAll(Expression<Func<RoutineBakimTuru,bool>> expression = null);

    }
}