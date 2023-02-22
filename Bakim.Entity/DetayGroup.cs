using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Core.Entity;

namespace Bakim.Entity
{
    public class DetayGroup : IEntity
    {
        [Key]
        public int DetayGroupId { get; set; }
        public string DetayGroupName { get; set; }
        public int VarlikGroupId { get; set; }
        public bool Pasif { get; set; }
        
       
    }
}