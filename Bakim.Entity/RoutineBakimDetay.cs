

using Bakim.Core.Entity;

namespace Bakim.Entity
{
    public class RoutineBakimDetay : IEntity
    {
        public int RoutineBakimDetayId { get; set; }
        public int RoutineBakimId { get; set; }
        public int SectionId { get; set; }
        public int? MachineId { get; set; }
        public RoutineBakim RoutineBakim { get; set; }
        public Section Section { get; set; }
    }

}