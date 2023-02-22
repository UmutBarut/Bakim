using Bakim.Entity;

namespace Bakim.Entity.Dto
{
    public class WorkTaskViewDto
    {
        public WorkTask WorkTask { get; set; }
        public List<WorkTaskUser> Handlers { get; set; }
    }
}
