

using Bakim.Core.Entity;

namespace Bakim.Entity
{
    public class WorkTaskUser : IEntity
    {
        public int WorkTaskUserId { get; set; }
        public int? WorkTaskId { get; set; }
        public string? UserId { get; set; }
        public string? Description { get; set; }
        public bool InProcess { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public ApplicationUser? User { get; set; }
        public WorkTask? WorkTask { get; set; }
    }

}
