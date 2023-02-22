
using Bakim.Core.Utilities.Results;
using Bakim.Entity;

namespace Bakim.Business.Abstracts
{
    public interface ISectionService
    {
        public IDataResult<List<Section>> GetAll();
        public IDataResult<Section> GetById(int sectionId);
        public IResult Add(Section section);
        public IResult Delete(Section section);
        public IResult Update(Section section);
    }
}
