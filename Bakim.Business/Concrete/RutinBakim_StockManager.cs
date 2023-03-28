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
    public class RutinBakim_StockManager : IRutinBakim_StockService
    {
        private readonly IRutinBakim_StockDal _rutinBakim_StockDal;

        public RutinBakim_StockManager(IRutinBakim_StockDal rutinBakim_StockDal)
        {
            _rutinBakim_StockDal = rutinBakim_StockDal;
        }

        public IResult Add(RutinBakim_Stock rutinBakim_Stock)
        {
            _rutinBakim_StockDal.InsertAsync(rutinBakim_Stock);
            return new SuccessResult();
        }

        public IResult Delete(RutinBakim_Stock rutinBakim_Stock)
        {
            _rutinBakim_StockDal.Delete(rutinBakim_Stock);
            return new SuccessResult();
        }

        public IDataResult<List<RutinBakim_Stock>> GetAll(Expression<Func<RutinBakim_Stock, bool>> expression = null)
        {
            if(expression == null)
            {
                return new SuccessDataResult<List<RutinBakim_Stock>>(_rutinBakim_StockDal.GetAll());
            }
            return new SuccessDataResult<List<RutinBakim_Stock>>(_rutinBakim_StockDal.GetAll(expression));
        }

        public IDataResult<RutinBakim_Stock> GetById(Expression<Func<RutinBakim_Stock, bool>> expression)
        {
            return new SuccessDataResult<RutinBakim_Stock>(_rutinBakim_StockDal.GetAll(expression).FirstOrDefault());
        }

        public IResult Update(RutinBakim_Stock rutinBakim_Stock)
        {
            _rutinBakim_StockDal.Update(rutinBakim_Stock);
            return new SuccessResult();
        }
    }
}