
using Bakim.Core.Utilities.Results;
using Bakim.Entity;

namespace Bakim.Business.Abstracts
{
    public interface ISectionFaultService
    {
        public IDataResult<List<SectionFault>> GetAll(int? sectionId = null);
        public IDataResult<SectionFault> GetById(int sectionFaultId);
        public IResult Add(SectionFault sectionFault);
        public IResult Delete(SectionFault sectionFault);
        public IResult Update(SectionFault sectionFault);
    }
}
