

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

    public class TaskViewModel
    {
        public List<atanankullanicilar>? atanankullanicilars { get; set; }
        public ApplicationUser User { get; set; }
        public WorkTask Task { get; set; }
        public List<ApplicationUser> AllUsers { get; set; }
        
        public List<WorkTask> WorkTasks { get; set; }
        public List<WorkTaskDto> Dtos { get; set; }
        public SectionDto SectionDto { get; set; }
        public SectionDtoViewModel SectionDtoViewModel { get; set; }
        public Section Section { get; set; }
        public SectionFault SectionFault { get; set; }
        public List<Varlik> varliks { get; set; }
        public Varlik varlik { get; set; }
        public List<Stock> stock { get; set; }

        
        public WorkTaskUser taskuser { get; set; }

        public List<Section> Sections { get; set; }
        public List<SectionFault> SectionFaults { get; set; }
        public List<WorkTaskUser> WorkTaskUsers { get; set; }
        public string Description { get; set; }

        public List<WorkTaskTransfer>? WorkTaskTransfers { get; set; }

        public List<ProductionSection> productionSections { get; set; }


         

    

        
    }
}
