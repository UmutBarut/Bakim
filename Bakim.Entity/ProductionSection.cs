

using Bakim.Core.Entity;

namespace Bakim.Entity
{
    public class ProductionSection : IEntity
    {
        public int ProductionSectionId { get; set; }
        public string ProductionSectionName { get; set; }
        public bool Pasif { get; set; }

    }
}
