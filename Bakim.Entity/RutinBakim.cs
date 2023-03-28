using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Core.Entity;

namespace Bakim.Entity
{
    public class RutinBakim : IEntity
    {
        public int RutinBakimId { get; set; }
        public string RutinBakimAdi { get; set; }
        public string Aciklama { get; set; }
        public int UserId { get; set; }
        public DateTime? UploadDate { get; set; }
        public DateTime PlanlanmaTarihi { get; set; }
        public DateTime BakimTarihi { get; set; }
        public DateTime BakimAraligi { get; set; }
        public int CorporationId { get; set; }
        public bool Pasif { get; set; }
        public int GrupId { get; set; }
        public int KategoriId { get; set; }
    }
}