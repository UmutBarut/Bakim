using System.Linq.Expressions;
using Bakim.Business.Abstracts;
using Bakim.Core.Utilities.Results;
using Bakim.Dataaccess.Abstracts;
using Bakim.Entity;

namespace Bakim.Business.Concrete
{
    public class ProductionSectionManager : IProductionSectionService
    {
        private readonly IProductionSectionDal _productionSectionDal;

        public ProductionSectionManager(IProductionSectionDal productionSectionDal)
        {
            _productionSectionDal = productionSectionDal;
        }

        public IResult Add(ProductionSection productionSection)
        {
            _productionSectionDal.InsertAsync(productionSection);
            return new SuccessResult();
        }

        public IDataResult<ProductionSection> GetMachineGroup(int sectionId)
        {
            return new SuccessDataResult<ProductionSection>(_productionSectionDal.GetAll(g => g.ProductionSectionId == sectionId).First());
        }

        public IDataResult<List<ProductionSection>> GetMachineGroups(Expression<Func<ProductionSection, bool>> expression = null)
        {
            if (expression == null)
            {
                return new SuccessDataResult<List<ProductionSection>>(_productionSectionDal.GetAll());
            }
            return new SuccessDataResult<List<ProductionSection>>(_productionSectionDal.GetAll(expression));
        }

        public IResult Update(ProductionSection productionSection)
        {
            _productionSectionDal.Update(productionSection);
            return new SuccessResult();
        }

        public IResult Delete(ProductionSection productionSection)
        {
            _productionSectionDal.Delete(productionSection);
            return new SuccessResult();
        }
    }
}
