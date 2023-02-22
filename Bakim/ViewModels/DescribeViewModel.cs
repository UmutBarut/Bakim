using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Entity;

namespace Bakim.ViewModels
{
    public class DescribeViewModel
    {
        public List<DetayGroup> DetayGrubu { get; set; }
        public List<VarlikGroup> VarlikGrubu { get; set; }
        public List<ProductionSection> UretimBolumu { get; set; }
        public List<DetayGroup> VarlikKategori { get; set; }

        
    }

    public class EditVarlikViewModel
    {
        public Varlik varlik { get; set; }
        public List<ProductionSection> Uretimbolumu { get; set; }
        public List<VarlikGroup> VarlikGruplari { get; set; }
        public VarlikGroup varlikGrubu { get; set; }
        public DetayGroup varlikkategorisi { get; set; }
        public List<DetayGroup> varlikKategorileri { get; set; }

    }

    public class EditStockViewModel
    {
        public Stock stok { get; set; }
        public List<StockGroup> stokGruplari { get; set; } 
        public StokKategori stokKategori { get; set; }
        public List<Stok_Firma> stokfirma { get; set; }
        public List<TedarikciFirma> firmalar { get; set; }
    }
}