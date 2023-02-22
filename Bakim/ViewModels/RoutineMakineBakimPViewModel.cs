using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Entity;

namespace Bakim.ViewModels
{
    public class RoutineMakineBakimPViewModel : RoutineBakim
    {

        public List<RoutineBakimTuru> RoutineBakimTuruListele { get; set;}
        public List<ProductionSection>  ProductionSectionListele {get;set;}

    }
}