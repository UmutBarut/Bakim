

using System.Linq.Expressions;
using Bakim.Core.Utilities.Results;
using Bakim.Entity;

namespace Bakim.Business.Abstracts
{
    public interface IProductionSectionService
    {
        public IDataResult<List<ProductionSection>> GetAll(Expression<Func<ProductionSection, bool>> expression = null);
        public IDataResult<ProductionSection> GetById(Expression<Func<ProductionSection, bool>> expression);
        public IResult Add(ProductionSection productionSection);
        public IResult Update(ProductionSection productionSection);
        
    }
}
