
using Bakim.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakim.Entity
{
    public class Corporation : IEntity
    {
        public int CorporationId { get; set; }
        public string CorporationName { get; set; }
        public bool Passive { get; set; } = false;
        public string CorporationAddress { get; set; }
        public string CorporationNumber { get; set; }
    }
}
