
using Bakim.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakim.Entity
{
    public class WorkTask : IEntity
    {
        [Key]
        public int TaskId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string TaskTitle { get; set; }
        public string? TaskDescription { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string CreatorId { get; set; }
        public bool InProcess { get; set; }
        public DateTime? ProcessStartedDate { get; set; }
        public string? ReceiverId { get; set; }
        public string? StarterId { get; set; }
        public int SectionId { get; set; }
        public int SectionFaultId { get; set; }
        public bool Acil { get; set; }
        public string? ImagePath { get; set; }
        public int? VarlikId { get; set; }

        public SectionFault SectionFault { get; set; }
        public Section Section { get; set; }
        public ApplicationUser Starter { get; set; }
        public ApplicationUser Creator { get; set; }
        public ApplicationUser? Receiver { get; set; }

    }
}
