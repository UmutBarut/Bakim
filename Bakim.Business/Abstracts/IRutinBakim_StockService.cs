using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bakim.Core.Utilities.Results;
using Bakim.Entity;

namespace Bakim.Business.Abstracts
{
    public interface IRutinBakim_StockService
    {
        public IDataResult<List<RutinBakim_Stock>> GetAll(Expression<Func<RutinBakim_Stock, bool>> expression = null);
        public IDataResult<RutinBakim_Stock> GetById(Expression<Func<RutinBakim_Stock,bool>> expression);
        public IResult Add(RutinBakim_Stock rutinBakim_Stock);
        public IResult Delete(RutinBakim_Stock rutinBakim_Stock);
        public IResult Update(RutinBakim_Stock rutinBakim_Stock);
    }
}