
using Bakim.Core.Entity;
using System.Text.Json.Serialization;

namespace Bakim.Entity
{

    [Serializable]
    public class Call : IEntity
    {

        public int CallId { get; set; }
        public int MakineId { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ComplationDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsEmergency { get; set; }
        public string? Description { get; set; }

        public Machine Machine { get; set; }
        public ApplicationUser User { get; set; }
    }


}
