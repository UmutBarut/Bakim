using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bakim.Entity
{
    public class Kalip
    {
        public int KalipId { get; set; }
        public string KalipName { get; set; }
        public string Aciklama { get; set; }
        public string Marka { get; set; }
        public string UstKafa { get; set; }
        public string Govde { get; set; }
        public string AltKafa { get; set; }
        public string TasTutucu { get; set; }
        public string OrtaSapka { get; set; }
        public int Boy { get; set; }
        public int Cap { get; set; }
        public int PleytCapi { get; set; }
        public double AltKonusCapi { get; set; }
        public double UstKonusCapi { get; set; }
        public bool Pasif { get; set; }
    }
}