using System.Linq.Expressions;
using Bakim.Core.Utilities.Results;
using Bakim.Entity;

namespace Bakim.Business.Abstracts
{
    public interface IDetayGroupService
    {
        public IDataResult<List<DetayGroup>> GetAll(Expression<Func<DetayGroup, bool>> expression = null);
        public IDataResult<List<DetayGroup>> GetById(int detayGroupId);
        public IResult Add(DetayGroup detayGroup);
        public IResult Update(DetayGroup detayGroup);
        public IResult Delete(DetayGroup detayGroup);
    }
}