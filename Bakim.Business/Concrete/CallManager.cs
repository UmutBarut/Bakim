using Bakim.Business.Abstracts;
using Bakim.Core.Utilities.Results;
using Bakim.Dataaccess.Abstracts;
using Bakim.Entity;
using Bakim.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakim.Business.Concrete
{
    public class CallManager : ICallService
    {
        private readonly ICallDal _callDal;

        public CallManager(ICallDal callDal)
        {
            _callDal = callDal;
        }

        public IResult AddCall(Call call)
        {
            _callDal.InsertAsync(call);
            return new SuccessResult();
        }

        public IDataResult<CallDto> CallDetails(int id)
        {
            return new SuccessDataResult<CallDto>(_callDal.GetCallDetailsById(id));
        }

        public IDataResult<List<Call>> GetActiveCalls()
        {
            return new SuccessDataResult<List<Call>>(_callDal.GetAll(c => c.IsActive == true));
        }

        public IDataResult<IEnumerable<CallDto>> GetAll()
        {
            var result = _callDal.GetAllCalls();
            return new SuccessDataResult<IEnumerable<CallDto>>(result);
        }

        public IDataResult<List<Call>> GetCompletedCalls()
        {
            return new SuccessDataResult<List<Call>>(_callDal.GetAll(c => c.IsActive == false));
        }

        public IDataResult<List<CallCountsPerMachineDto>> GetCountsByMachineId()
        {
            var result = _callDal.GetCountsByMachineId();
            return new SuccessDataResult<List<CallCountsPerMachineDto>>(result);
        }

        public IResult UpdateCall(Call call)
        {
            _callDal.Update(call);
            return new SuccessResult();
        }
    }
}
