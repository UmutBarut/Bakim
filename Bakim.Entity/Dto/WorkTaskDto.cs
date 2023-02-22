using Bakim.Entity;

namespace Bakim.Entity.Dto
{
    public class WorkTaskDto
    {
        public WorkTask WorkTask { get; set; }
        public List<WorkTaskTransfer>? WorkTaskTransfers { get; set; }
        public List<WorkTaskUser> WorkTaskUsers { get; set; }
        public SectionDto SectionDto { get; set; }
    }
}
