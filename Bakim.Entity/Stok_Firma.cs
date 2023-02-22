using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Core.Entity;

namespace Bakim.Entity
{
    public class Stok_Firma : IEntity
    {
        [Key]
        public int StokFirmaId { get; set; }
        public int StockId { get; set; }
        public int FirmaId { get; set; }
    }
}