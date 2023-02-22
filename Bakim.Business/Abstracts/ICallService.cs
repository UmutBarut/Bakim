

using Bakim.Core.Utilities.Results;
using Bakim.Entity;
using Bakim.Entity.Dto;

namespace Bakim.Business.Abstracts
{
    public interface ICallService
    {
        public IDataResult<IEnumerable<CallDto>> GetAll();
        public IDataResult<CallDto> CallDetails(int id);
        public IDataResult<List<Call>> GetActiveCalls();
        public IDataResult<List<Call>> GetCompletedCalls();
        public IDataResult<List<CallCountsPerMachineDto>> GetCountsByMachineId();
        public IResult AddCall(Call call);
        public IResult UpdateCall(Call call);
    }
}
