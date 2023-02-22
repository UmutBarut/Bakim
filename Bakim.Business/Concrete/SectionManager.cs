

using Bakim.Business.Abstracts;
using Bakim.Core.Utilities.Results;
using Bakim.Dataaccess.Abstracts;
using Bakim.Entity;

namespace Bakim.Business.Concrete
{
    public class SectionManager : ISectionService
    {
        private readonly ISectionDal _sectionDal;

        public SectionManager(ISectionDal sectionDal)
        {
            _sectionDal = sectionDal;
        }

        public IResult Add(Section section)
        {
            _sectionDal.InsertAsync(section);
            return new SuccessResult();
        }

        public IResult Delete(Section section)
        {
            _sectionDal.Delete(section);
            return new SuccessResult();
        }

        public IDataResult<List<Section>> GetAll()
        {
            return new SuccessDataResult<List<Section>>(_sectionDal.GetAll());
        }

        public IDataResult<Section> GetById(int sectionId)
        {
            return new SuccessDataResult<Section>(_sectionDal.GetAll(c => c.SectionId == sectionId).First());
        }

        public IResult Update(Section section)
        {
            _sectionDal.Update(section);
            return new SuccessResult();
        }
    }
}
