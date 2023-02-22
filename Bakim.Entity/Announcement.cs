
using Bakim.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakim.Entity
{
    public class Announcement : IEntity
    {
        public int AnnouncementId { get; set; }
        public DateTime PublishDate { get; set; }
        public string PublisherName { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Roles { get; set; }
        public bool IsEmergency { get; set; }

    }
}
