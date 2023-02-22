using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Core.Entity;

namespace Bakim.Entity
{
    public class TedarikciFirma : IEntity
    {
        [Key]
        public int FirmaId { get; set; }
        public string FirmaAdi { get; set; }
        public bool Pasif { get; set; }
    }
}