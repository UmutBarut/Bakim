using Bakim.Core.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bakim.Entity
{

    [Serializable]
    public class ApplicationUser : IdentityUser, IEntity
    {
        public string? ImagePath { get; set; }
        public int CorporationId { get; set; }
        public bool IsAdmin { get; set; }


    }
}
