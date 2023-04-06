using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Entity;

namespace Bakim.ViewModels
{
    public class RutinBakimViewModel
    {
        public List<RutinBakimKategorisi> Kategoriler { get; set; }
        public List<RutinBakim> Bakimlar { get; set; }
    }
}