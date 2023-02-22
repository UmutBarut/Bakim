
using Bakim.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakim.Entity
{
    [Serializable]
    public class Machine : IEntity
    {
        [Key]
        public int MachineId { get; set; }
        public string MachineCode { get; set; }
        public string MachineName { get; set; }
        public int DetayGroupId { get; set; }
        public int ProductionSectionId { get; set; }
        public int CorporationId { get; set; }
        public bool InUse { get; set; }
        public string? ImagePath { get; set; }
        public ProductionSection ProductionSection { get; set; }
        public Corporation Corporation { get; set; }
        public DetayGroup DetayGroup { get; set; }
    }
}
