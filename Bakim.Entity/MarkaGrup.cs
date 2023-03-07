using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Core.Entity;

namespace Bakim.Entity
{
    public class MarkaGrup : IEntity
    {
        [Key]
        public int MarkaGrupId { get; set; }
        public string MarkaGrupAdi { get; set; }
        public int MarkaId { get; set; }
        public int VarlikId { get; set; }
    }
}