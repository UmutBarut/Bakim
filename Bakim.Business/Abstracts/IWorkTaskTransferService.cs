

using Bakim.Core.Utilities.Results;
using Bakim.Entity;

namespace Bakim.Business.Abstracts
{
    public interface IWorkTaskTransferService
    {
        public IDataResult<List<WorkTaskTransfer>> GetAll(int workTaskId);
        public IDataResult<WorkTaskTransfer> GetSingle(int workTaskTransferId);
        public IResult Add(WorkTaskTransfer workTaskTransfer);
        public IResult Delete(WorkTaskTransfer workTaskTransfer);
        public IResult Update(WorkTaskTransfer workTaskTransfer);
    }
}
