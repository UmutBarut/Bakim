using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakim.Entity.Dto
{
    public class AnnouncementDto
    {
        public int AnnouncementId { get; set; }
        public DateTime PublishDate { get; set; }
        public string PublisherName { get; set; }
        public List<string> Roles { get; set; }
        public bool IsEmergency { get; set; }
    }
}
