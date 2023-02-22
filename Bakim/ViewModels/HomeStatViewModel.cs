

using Bakim.Entity;

namespace Bakim.ViewModels
{
    public class HomeStatViewModel
    {
        public int NotCompletedCount { get; set; }
        public int SpecialNotCompletedCount { get; set; }
        public int NotSeenAnnouncementCount { get; set; }
        public ApplicationUser User { get; set; }
        public int TotalRecord { get; set; }
        public List<WorkTask> WorkTasks { get; set; }

    }
}
