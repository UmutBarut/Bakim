
using Bakim.Business.Abstracts;
using Bakim.Core.Utilities.Results;
using Bakim.Dataaccess.Abstracts;
using Bakim.Entity;

namespace Bakim.Business.Concrete
{
    public class WorkTaskTransferManager : IWorkTaskTransferService
    {
        private readonly IWorkTaskTransferDal _workTaskTransferDal;

        public WorkTaskTransferManager(IWorkTaskTransferDal workTaskTransferDal)
        {
            _workTaskTransferDal = workTaskTransferDal;
        }

        public IResult Add(WorkTaskTransfer workTaskTransfer)
        {
            _workTaskTransferDal.InsertAsync(workTaskTransfer);
            return new SuccessResult();
        }

        public IResult Delete(WorkTaskTransfer workTaskTransfer)
        {
            _workTaskTransferDal.Delete(workTaskTransfer);
            return new SuccessResult();
        }

        public IDataResult<List<WorkTaskTransfer>> GetAll(int workTaskId)
        {
            return new SuccessDataResult<List<WorkTaskTransfer>>(_workTaskTransferDal.GetAll(c => c.WorkTaskId == workTaskId));
        }

        public IDataResult<WorkTaskTransfer> GetSingle(int workTaskTransferId)
        {
            return new SuccessDataResult<WorkTaskTransfer>(_workTaskTransferDal.GetAll(c => c.WorkTaskTransferId == workTaskTransferId).First());
        }

        public IResult Update(WorkTaskTransfer workTaskTransfer)
        {
            _workTaskTransferDal.Update(workTaskTransfer);
            return new SuccessResult();
        }
    }
}
