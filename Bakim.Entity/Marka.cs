using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Core.Entity;

namespace Bakim.Entity
{
    public class Marka : IEntity
    {
        [Key]
        public int MarkaId { get; set; }
        public string MarkaAdi { get; set; }
        
    }
}