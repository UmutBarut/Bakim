using Bakim.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Bakim.Entity
{
    public class StockGroup : IEntity
    {
        public int StockGroupId { get; set; }

        public string StockGroupName { get; set; }

        public int CorporationId { get; set; }
        public bool Pasif { get; set; }
    }
}