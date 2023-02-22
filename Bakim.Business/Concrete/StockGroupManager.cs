using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bakim.Business.Abstracts;
using Bakim.Core.Utilities.Results;
using Bakim.Dataaccess.Abstracts;
using Bakim.Entity;

namespace Bakim.Business.Concreteck
{
    public class StockGroupManager : IStockGroupService
    {
        private readonly IStockGroupDal _stockGroupDal;

        public StockGroupManager(IStockGroupDal stockGroupDal)
        {
            _stockGroupDal = stockGroupDal;
        }


        public IResult Add(StockGroup stockGroup)
        {
            _stockGroupDal.InsertAsync(stockGroup);
            return new SuccessResult();
        }

          public IResult Update(StockGroup stockgroup)
        {
             _stockGroupDal.Update(stockgroup);
            return new SuccessResult();
        }


        public IResult Delete(StockGroup stockgroup)
        {
             _stockGroupDal.Delete(stockgroup);
            return new SuccessResult();
        }

        public IDataResult<List<StockGroup>> GetAll(Expression<Func<StockGroup, bool>> expression = null)
        {
            if(expression==null)
           {
            return new SuccessDataResult<List<StockGroup>>(_stockGroupDal.GetAll());
           }
            return new SuccessDataResult<List<StockGroup>>(_stockGroupDal.GetAll(expression));
        }

        public IDataResult<List<StockGroup>> StockGroupList(Expression<Func<StockGroup, bool>> expression = null)
        {
            if (expression == null)
            {

                return new SuccessDataResult<List<StockGroup>>(_stockGroupDal.GetAll());
            }
            return new SuccessDataResult<List<StockGroup>>(_stockGroupDal.GetAll(expression));
        }

      
    }
}