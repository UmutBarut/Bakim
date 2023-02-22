
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

        public IDataResult<List<SectionFault>> GetAll(int? sectionId = null)
        {
            if (sectionId == null)
            {
                return new SuccessDataResult<List<SectionFault>>(_sectionFaultDal.GetAll());
            }
            return new SuccessDataResult<List<SectionFault>>(_sectionFaultDal.GetAll());
        }

        public IDataResult<SectionFault> GetById(int sectionFaultId)
        {
            return new SuccessDataResult<SectionFault>(_sectionFaultDal.GetAll(c => c.SectionFaultId == sectionFaultId).FirstOrDefault());
        }

        public IResult Update(SectionFault sectionFault)
        {
            _sectionFaultDal.Update(sectionFault);
            return new SuccessResult();
        }
    }
}
