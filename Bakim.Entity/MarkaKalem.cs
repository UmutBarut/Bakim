using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Core.Entity;

namespace Bakim.Entity
{
    public class MarkaKalem : IEntity
    {
        [Key]
        public int KalemId { get; set; }
        public string KalemAdi { get; set; }
        public int MarkaGrupId { get; set; }
        public int MarkaId { get; set; }
        public int VarlikId { get; set; }
    }
}