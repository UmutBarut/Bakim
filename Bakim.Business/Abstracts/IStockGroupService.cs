using Bakim.Core.Utilities.Results;
using Bakim.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace Bakim.Business.Abstracts
{

    public interface IStockGroupService
    {
        public IResult Add(StockGroup stockgroup);
        public IResult Delete(StockGroup stockgroup);
        public IResult Update(StockGroup stockgroup);

        public IDataResult<List<StockGroup>> StockGroupList(Expression<Func<StockGroup, bool>> expression = null);

        public IDataResult<List<StockGroup>> GetAll(Expression<Func<StockGroup,bool>> expression = null);
    }
}