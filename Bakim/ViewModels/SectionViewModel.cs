

using Bakim.Entity;

namespace Bakim.ViewModels
{
    public class SectionViewModel
    {
        public List<Section> Sections { get; set; }
        public List<SectionFault> SectionFaults { get; set; }
        public bool Success { get; set; }
        public Section Section { get; set; }
        public SectionFault SectionFault { get; set; }
    }
}
