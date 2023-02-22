

using Bakim.Core.Entity;

namespace Bakim.Entity
{
    public class UserAnnouncement : IEntity
    {
        public int UserAnnouncementId { get; set; }
        public int AnnouncementId { get; set; }
        public string ApplicationUserId { get; set; }
        public bool HasSeen { get; set; }
        public DateTime SeenDate { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Announcement Announcement { get; set; }
    }
}
