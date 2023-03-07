using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Core.Entity;

namespace Bakim.Entity
{
    public class Varlik : IEntity
    {
        [Key]
        public int VarlikId { get; set; }
        public string VarlikName { get; set; }
        public string VarlikCode { get; set; }     
        public string? ImagePath { get; set; }
        public int VarlikGroupId { get; set; }
        public int DetayGroupId { get; set; }
        public int CorporationId { get; set; }
        public int ProductionSectionId { get; set; }
        public bool InUse { get; set; }
        public bool Pasif { get; set; }
        public DateTime? UploadDate { get; set; }
        public DetayGroup DetayGroup { get; set; }
        public VarlikGroup VarlikGroup { get; set; }

    }
}