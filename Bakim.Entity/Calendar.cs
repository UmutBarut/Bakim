using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Core.Entity;
using Newtonsoft.Json;

namespace Bakim.Entity
{
    public class Calendar : IEntity
    {
        [JsonProperty(PropertyName = "RoutineBakimTuruId")]
        public int RoutineBakimTuruId{ get; set;}

        [JsonProperty(PropertyName = "AppointmentId")]
        public int CalendarId { get; set; }
        [JsonProperty(PropertyName = "Text")]
        public string? Text { get; set; }
        [JsonProperty(PropertyName = "Description")]
        public string? Description { get; set; }
        [JsonProperty(PropertyName = "StartDate")]
        public string? StartDate { get; set; }
        [JsonProperty(PropertyName = "EndDate")]
        public string? EndDate { get; set; }
        [JsonProperty(PropertyName = "AllDay")]
        public bool AllDay { get; set; }
        [JsonProperty(PropertyName = "RecurrenceRule")]
        public string? RecurrenceRule { get; set; }
        [JsonProperty(PropertyName = "RecurrenceException")]
        public string? RecurrenceException { get; set; }
    }
}