

using Bakim.Entity;

namespace Bakim.ViewModels
{
    public class SidebarViewModel
    {
        public ApplicationUser User { get; set; }
        public List<WorkTask> WorkTasks { get; set; }
        public List<UserAnnouncement> UserAnnouncements { get; set; }
    }
}
