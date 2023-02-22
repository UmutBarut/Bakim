using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Core.Entity;

namespace Bakim.Entity
{
    public class RoutineBakimMakine : IEntity
    {
        [Key]
       public int RoutineBakimId { get; set; }

        public string UserId { get; set; }

        public DateTime PlanlamaTarihi { get; set; }

        public DateTime BakimTarihi { get; set; }

        public string BakimAdi { get; set; }

        public string BakimAciklamasi { get; set; }
        public int MachineId { get; set; }
    }
}