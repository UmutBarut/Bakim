using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Core.Entity;

namespace Bakim.Entity
{   
    public class VarlikGroup : IEntity
    {
        [Key]
        public int VarlikGroupId { get; set; }
        public string VarlikGroupName { get; set; }
        public bool Pasif { get; set; }
        public DetayGroup detayGrubu { get; set; }

        

    }
}