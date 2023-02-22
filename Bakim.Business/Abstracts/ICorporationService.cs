
using Bakim.Core.Utilities.Results;
using Bakim.Entity;

namespace Bakim.Business.Abstracts
{
    public interface ICorporationService
    {
        public IDataResult<Corporation> GetById(int id);
    }
}
