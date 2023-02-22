

using Bakim.Core.DataAccess;
using Bakim.Entity;
using Bakim.Entity.Dto;

namespace Bakim.Dataaccess.Abstracts
{
    public interface ICallDal : IEntityRepository<Call>
    {
        public List<CallCountsPerMachineDto> GetCountsByMachineId();
        public CallDto GetCallDetailsById(int id);

        public List<CallDto> GetAllCalls();
    }
}
