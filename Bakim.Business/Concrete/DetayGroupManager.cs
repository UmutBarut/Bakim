using System.Linq.Expressions;
using Bakim.Business.Abstracts;
using Bakim.Core.Utilities.Results;
using Bakim.Dataaccess.Abstracts;
using Bakim.Entity;

namespace Bakim.Business.Concrete
{
    public class DetayGroupManager : IDetayGroupService
    {
        private readonly IDetayGroupDal _detayGroupDal;

        public DetayGroupManager(IDetayGroupDal detayGroupDal)
        {
            _detayGroupDal = detayGroupDal;
        }

        public IResult Add(DetayGroup detayGroup)
        {
           _detayGroupDal.InsertAsync(detayGroup);
           return new SuccessResult();
        }

        public IResult Delete(DetayGroup detayGroup)
        {
            _detayGroupDal.Delete(detayGroup);
           return new SuccessResult();
        }

        public IDataResult<List<DetayGroup>> GetAll(Expression<Func<DetayGroup, bool>> expression = null)
        {
            if(expression == null)
            {
                return new SuccessDataResult<List<DetayGroup>>(_detayGroupDal.GetAll());
            }
            else
            {
                return new SuccessDataResult<List<DetayGroup>>(_detayGroupDal.GetAll(expression));
            }
        }

        public IDataResult<List<DetayGroup>> GetById(int detayGroupId)
        {
            return new SuccessDataResult<List<DetayGroup>>(_detayGroupDal.GetAll(m=> m.VarlikGroupId == detayGroupId));
        }

        public IResult Update(DetayGroup detayGroup)
        {
            _detayGroupDal.Update(detayGroup);
           return new SuccessResult();
        }
    }
}