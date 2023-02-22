
using Bakim.Business.Abstracts;
using Bakim.Core.Utilities.Results;
using Bakim.Dataaccess.Abstracts;
using Bakim.Entity;

namespace Bakim.Business.Concrete
{
    public class CorporationManager : ICorporationService
    {
        private readonly ICorporationDal _corporationDal;

        public CorporationManager(ICorporationDal corporationDal)
        {
            _corporationDal = corporationDal;
        }

        public IDataResult<Corporation> GetById(int id)
        {
            return new SuccessDataResult<Corporation>(_corporationDal.GetAll(c => c.CorporationId == id).First());
        }
    }
}
