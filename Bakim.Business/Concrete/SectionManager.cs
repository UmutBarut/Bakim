

using System.Linq.Expressions;
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

        public IDataResult<List<Section>> GetAll(Expression<Func<Section, bool>> expression = null)
        {
            if(expression == null)
            {
                return new SuccessDataResult<List<Section>>(_sectionDal.GetAll());    
            }

            return new SuccessDataResult<List<Section>>(_sectionDal.GetAll(expression));
        }

        public IDataResult<Section> GetById(Expression<Func<Section, bool>> expression = null)
        {
            return new SuccessDataResult<Section>(_sectionDal.GetAll(expression).FirstOrDefault());
        }

        public IResult Update(Section section)
        {
            _sectionDal.Update(section);
            return new SuccessResult();
        }
    }
}
