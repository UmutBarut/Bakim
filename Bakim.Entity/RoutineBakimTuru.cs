using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Core.Entity;

namespace Bakim.Entity
{
    public class RoutineBakimTuru : IEntity
    {
        public int RoutineBakimTuruId { get; set; }
        public string RoutineBakimTurAdi { get; set; }
        public string Color { get; set; }
    }
}