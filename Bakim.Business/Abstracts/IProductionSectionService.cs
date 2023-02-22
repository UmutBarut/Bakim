

using System.Linq.Expressions;
using Bakim.Core.Utilities.Results;
using Bakim.Entity;

namespace Bakim.Business.Abstracts
{
    public interface IProductionSectionService
    {
        public IDataResult<List<ProductionSection>> GetMachineGroups(Expression<Func<ProductionSection, bool>> expression = null);
        public IDataResult<ProductionSection> GetMachineGroup(int sectionId);
        public IResult Add(ProductionSection productionSection);
        public IResult Update(ProductionSection productionSection);
        
    }
}
