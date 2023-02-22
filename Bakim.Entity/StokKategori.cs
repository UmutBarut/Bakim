using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Core.Entity;

namespace Bakim.Entity
{
    public class StokKategori : IEntity
    {
        public int StokKategoriId { get; set; }
        public string StokKategoriName { get; set; }
        public int StockGroupId { get; set; }
        public bool Pasif { get; set; }
    }
}