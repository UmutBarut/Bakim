using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bakim.Entity.Views
{
    public class atanankullanicilar
    {
        public int TaskId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string TaskTitle { get; set; }
        public string? TaskDescription { get; set; }
        public bool IsActive { get; set; }
        public bool IsCompleted { get; set; }
        public bool InProcess { get; set; }
        public string? ReceiverId { get; set; }
        public string? StarterId { get; set; }
        public string Durum { get; set; }
    }
}