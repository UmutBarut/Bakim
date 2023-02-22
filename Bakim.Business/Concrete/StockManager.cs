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
    public class StockManager : IStockService
    {
        private readonly IStockDal _stockDal;

        public StockManager(IStockDal stockDal)
        {
            _stockDal = stockDal;
        }

        public IResult Add(Stock stock)
        {
            _stockDal.InsertAsync(stock);
            return new SuccessResult();
        }

        public IResult Delete(Stock stock)
        {
            _stockDal.Delete(stock);
            return new SuccessResult();
        }

        public IResult Update(Stock stock)
        {
            _stockDal.Update(stock);
            return new SuccessResult();
        }

        public IDataResult<Stock> GetById(Expression<Func<Stock, bool>> expression = null)
        {
           
           
            return new SuccessDataResult<Stock>(_stockDal.GetAll(expression).FirstOrDefault());
        }

        public IDataResult<List<Stock>> StockList(Expression<Func<Stock, bool>> expression = null)
        {
            if (expression == null)
            {

                return new SuccessDataResult<List<Stock>>(_stockDal.GetAll());
            }
            return new SuccessDataResult<List<Stock>>(_stockDal.GetAll(expression));
        }
    }
}