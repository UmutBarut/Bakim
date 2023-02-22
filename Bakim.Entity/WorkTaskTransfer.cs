

using Bakim.Core.Entity;

namespace Bakim.Entity
{
    public class WorkTaskTransfer : IEntity
    {
        public int WorkTaskTransferId { get; set; }
        public int? WorkTaskId { get; set; }
        public string TransferredUserId { get; set; }
        public DateTime TransferredDate { get; set; }

        public WorkTask? WorkTask { get; set; }
        public ApplicationUser TransferredUser { get; set; }
    }


}
