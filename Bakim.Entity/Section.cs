

using Bakim.Core.Entity;

namespace Bakim.Entity
{
    public class Section : IEntity
    {
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public int ProductionSectionId { get; set; }
        public DateTime UploadDate { get; set; }
        public bool Pasif { get; set; }
    }
}
