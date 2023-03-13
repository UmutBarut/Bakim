using Bakim.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Bakim.Entity
{
    public class Stock : IEntity
    {
        [Key]
        public int StockId { get; set; }
        public string? StockCode { get; set; }
        public string StockName { get; set; }
        public string? Olcu { get; set; }
        public double Price { get; set; }
        public string? ImagePath { get; set; }
        public int MinStock { get; set; }
        public int MaxStock { get; set; }
        public string? Barcode { get; set; }
        public int StokKategoriId { get; set; }
        public int StockGroupId { get; set; }
        public int StockAmount { get; set; }
        public int CorporationId { get; set; }
        public bool Pasif { get; set; }
        public DateTime? UploadDate { get; set; }
        public StokKategori stokKategori { get; set; }
        public StockGroup stokGrubu { get; set; }
        
    }
}