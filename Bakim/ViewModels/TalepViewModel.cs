using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Entity;

namespace Bakim.ViewModels
{
    public class TalepViewModel
    {
        public List<Stock> stoklar { get; set; }
        public List<Varlik> varliklar { get; set; }
        public List<TedarikciFirma> firmalar { get; set; }
        public List<Birim> birimler { get; set; }
        public int Filter { get; set; }
        
        
    }

    
    public class TalepInfoWithUser 
    {
        public Talep talep {get;set;}
        public ApplicationUser user {get;set;}
    }
}