using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bakim.Core.Utilities.Results;
using Bakim.Entity;

namespace Bakim.Business.Abstracts
{
    public interface IRutinBakimService
    {
        public IDataResult<List<RutinBakim>> GetAll(Expression<Func<RutinBakim, bool>> expression = null);
        public IDataResult<RutinBakim> GetById(Expression<Func<RutinBakim,bool>> expression);
        public IResult Add(RutinBakim rutinBakim);
        public IResult Delete(RutinBakim rutinBakim);
        public IResult Update(RutinBakim rutinBakim);
    }
}