
using System.Linq.Expressions;
using Bakim.Core.Utilities.Results;
using Bakim.Entity;

namespace Bakim.Business.Abstracts
{
    public interface ISectionService
    {
        public IDataResult<List<Section>> GetAll(Expression<Func<Section,bool>> expression = null);
        public IDataResult<Section> GetById(Expression<Func<Section, bool>> expression);
        public IResult Add(Section section);
        public IResult Delete(Section section);
        public IResult Update(Section section);
    }
}
