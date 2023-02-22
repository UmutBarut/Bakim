using Bakim.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Bakim.Entity
{
    public class RoutineBakim : IEntity
    {
        public int RoutineBakimId { get; set; }

        public string UserId { get; set; }

        public DateTime PlanlamaTarihi { get; set; }

        public DateTime BakimTarihi { get; set; }

        public string BakimAdi { get; set; }

        public string BakimAciklamasi { get; set; }
        public int RoutineBakimTuruId { get; set; }

    }

}