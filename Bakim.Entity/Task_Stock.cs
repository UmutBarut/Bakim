using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Core.Entity;

namespace Bakim.Entity
{
    public class Task_Stock : IEntity
    {
        [Key]
        public int Task_StockId { get; set; }
        public int TaskId { get; set; }
        public int StockId { get; set; }
        public int StockAmount { get; set; }
        public DateTime? UploadDate { get; set; }
    }
}