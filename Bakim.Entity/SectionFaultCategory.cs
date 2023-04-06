using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Core.Entity;

namespace Bakim.Entity
{
    public class SectionFaultCategory : IEntity
    {
        [Key]
        public int FaultCategoryId { get; set; }
        public string FaultCategoryName { get; set; }
        public DateTime UploadDate { get; set; }
        public bool Pasif { get; set; }
    }
}