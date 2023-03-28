using Bakim.Core.Utilities.Results;
using Bakim.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace Bakim.Business.Abstracts
{
    public interface IStockService
    {
        public IDataResult<List<Stock>> StockList(Expression<Func<Stock, bool>> expression = null);
        public IDataResult<Stock> GetById(Expression<Func<Stock,bool>> expression);
        public IResult Add(Stock stock);
        public IResult Delete(Stock stock);
        public IResult Update(Stock stock);
    }
}