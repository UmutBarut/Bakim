using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Entity;

namespace Bakim.ViewModels
{
    public class VarlikViewModel
    {
        public List<Stock> Stoklar { get; set; }
        public List<Varlik> Varliklar { get; set; }

    }

    public class VarlikDetayViewModel
    {
        public VarlikGroup varlikGrubu { get; set; }
        public Varlik varlik { get; set; }
        public ProductionSection UretimBolumu { get; set; }
        public DetayGroup DetayGrubu { get; set; }

    }

    public class StokDetayViewModel
    {
        public StockGroup stokgrubu { get; set; }
        public Stock stok { get; set; }
        public ProductionSection uretimbolumu { get; set;}
        public StokKategori stokKategori { get; set; }
        public List<Stok_Firma> stokfirmalar { get; set; }
        public List<TedarikciFirma> firmalar { get; set; }
    }

    

   
}