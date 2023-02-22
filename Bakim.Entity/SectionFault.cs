

using Bakim.Core.Entity;

namespace Bakim.Entity
{
    public class SectionFault : IEntity
    {
        public int SectionFaultId { get; set; }
        public string SectionFaultName { get; set; }
        public string? SectionFaultDescription { get; set; }

    }
}
