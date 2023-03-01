

using Bakim.Entity;
using Bakim.Entity.Dto;
using Bakim.Entity.Views;

namespace Bakim.ViewModels
{
    public class WorkTaskViewModel
    {
        public List<WorkTask> WorkTasks { get; set; }
        public List<WorkTaskDto> Dtos { get; set; }
        public ApplicationUser User { get; set; }
        public List<ApplicationUser> AllUsers { get; set; }
        public WorkTask Task { get; set; }
        public EndTaskViewModel EndTaskViewModel { get; set; }
        public SectionDto SectionDto { get; set; }
        public SectionDtoViewModel SectionDtoViewModel { get; set; }

        public Section Section { get; set; }
        public SectionFault SectionFault { get; set; }
    }

    public class DenemeViewModel
    {
        public List<atanankullanicilar>? atanankullanicilars { get; set; }
        public ApplicationUser User { get; set; }
        public WorkTask Task { get; set; }
        public List<ApplicationUser> AllUsers { get; set; }
        
        public List<WorkTask> WorkTasks { get; set; }
        public List<WorkTaskDto> Dtos { get; set; }
        public EndTaskViewModel EndTaskViewModel { get; set; }
        public SectionDto SectionDto { get; set; }
        public SectionDtoViewModel SectionDtoViewModel { get; set; }
        public Section Section { get; set; }
        public SectionFault SectionFault { get; set; }
        public List<Varlik> varliks { get; set; }
        public List<Stock> stock { get; set; }

        public List<Section> Sections { get; set; }
        public List<SectionFault> SectionFaults { get; set; }

      
        public string Description { get; set; }


         

    

        
    }
}
