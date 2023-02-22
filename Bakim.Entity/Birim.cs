using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Core.Entity;

namespace Bakim.Entity
{
    public class Birim : IEntity
    {
        [Key]
        public int BirimId { get; set; }
        public string BirimAdi { get; set; }
        public bool Pasif { get; set; }
    }
}