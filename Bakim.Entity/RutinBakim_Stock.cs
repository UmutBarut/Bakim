using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Core.Entity;

namespace Bakim.Entity
{
    public class RutinBakim_Stock : IEntity
    { 
        [Key]
        public int RutinBakim_StockId { get; set; }
        public int RutinBakimId { get; set; }
        public int StockId { get; set; }
    }
}