using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Core.Entity;

namespace Bakim.Entity
{
    public class Talep : IEntity
    {
        [Key]
        public int TalepId { get; set; }
        public string TalepAdi { get; set; }
        public string? CreatorId { get; set; }
        public int StockId { get; set; }   
        public int VarlikId { get; set; }
        public int? Miktar { get; set; }
        public int? Olcu { get; set; }
        public int? BirimId { get; set; }
        public string? Aciklama { get; set; }
        public int? FirmaId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool IsApproved { get; set; }
        public DateTime? ApproveDate { get; set; }
        public bool IsFinished { get; set; }
        public DateTime? FinishDate { get; set; }
        
        
    }
}