
using System.Linq.Expressions;
using Bakim.Core.Utilities.Results;
using Bakim.Entity;

namespace Bakim.Business.Abstracts
{
    public interface ISectionFaultService
    {
        public IDataResult<List<SectionFault>> GetAll(Expression<Func<SectionFault, bool>> expression = null);
        public IDataResult<SectionFault> GetById(Expression<Func<SectionFault, bool >> expression);
        public IResult Add(SectionFault sectionFault);
        public IResult Delete(SectionFault sectionFault);
        public IResult Update(SectionFault sectionFault);
    }
}
