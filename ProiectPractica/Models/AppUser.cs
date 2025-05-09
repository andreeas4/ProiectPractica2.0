using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ProiectPractica.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            ProiecteRepartizate = new List<ResponsabilProiect>();
        }

        public AppUser(string userName) : base(userName)
        {
        }

        public AppUser(string? numeComplet, ICollection<ResponsabilProiect> proiecteRepartizate) : this(numeComplet)
        {
            ProiecteRepartizate = proiecteRepartizate;
        }

        public string? NumeComplet { get; set; } = string.Empty;

        public ICollection<ResponsabilProiect> ProiecteRepartizate { get; set; }
    }
}
