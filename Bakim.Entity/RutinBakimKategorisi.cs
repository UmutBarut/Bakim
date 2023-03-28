using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Core.Entity;

namespace Bakim.Entity
{
    public class RutinBakimKategorisi : IEntity
    {
        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }
        public int CorporationId { get; set; }
        public bool Pasif { get; set; }
        public DateTime? UploadDate { get; set; }
    }
}