
using System.Linq.Expressions;
using Bakim.Business.Abstracts;
using Bakim.Core.Utilities.Results;
using Bakim.Dataaccess.Abstracts;
using Bakim.Entity;

namespace Bakim.Business.Concrete
{
    public class SectionFaultManager : ISectionFaultService
    {

        private readonly ISectionFaultDal _sectionFaultDal;
        private readonly ISectionService _sectionService;

        public SectionFaultManager(ISectionFaultDal sectionFaultDal, ISectionService sectionService)
        {
            _sectionFaultDal = sectionFaultDal;
            _sectionService = sectionService;
        }

        public IResult Add(SectionFault sectionFault)
        {
            _sectionFaultDal.InsertAsync(sectionFault);
            return new SuccessResult();
        }

        public IResult Delete(SectionFault sectionFault)
        {
            _sectionFaultDal.Delete(sectionFault);
            return new SuccessResult();
        }

        public IDataResult<List<SectionFault>> GetAll(Expression<Func<SectionFault, bool>> expression = null)
        {
            if (expression == null)
            {
                return new SuccessDataResult<List<SectionFault>>(_sectionFaultDal.GetAll());
            }
            return new SuccessDataResult<List<SectionFault>>(_sectionFaultDal.GetAll(expression));
        }

        public IDataResult<SectionFault> GetById(Expression<Func<SectionFault, bool>> expression)
        {
            return new SuccessDataResult<SectionFault>(_sectionFaultDal.GetAll(expression).FirstOrDefault());
        }

        public IResult Update(SectionFault sectionFault)
        {
            _sectionFaultDal.Update(sectionFault);
            return new SuccessResult();
        }
    }
}
