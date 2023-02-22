using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Entity;

namespace Bakim.ViewModels
{
    public class StockViewModel
    {
        public StokKategori stokKategori { get; set; }
        public ApplicationUser User { get; set; }
        public Stock stock { get; set; }
        public List<TedarikciFirma> tedarikciFirmalar { get; set; }
        public List<StockGroup> stockGrubu { get; set; }
        public List<Stok_Firma> stokfirma { get; set; }

    }

    public class StokListe
    {
        public Stock stock { get; set; }

        public List<TedarikciFirma> tedarikciFirmalar { get; set; }
    }

}