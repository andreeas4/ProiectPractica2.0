using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ProiectPractica.Entities
{
    public class AppUserEntity : IdentityUser
    {
        public AppUserEntity()
        {
            ProiecteRepartizate = new List<ResponsabilProiect>();
        }

        public AppUserEntity(string userName) : base(userName)
        {
        }

        public AppUserEntity(string? numeComplet, ICollection<ResponsabilProiect> proiecteRepartizate) : this(numeComplet)
        {
            ProiecteRepartizate = proiecteRepartizate;
        }

        public string? NumeComplet { get; set; } = string.Empty;

        public ICollection<ResponsabilProiect> ProiecteRepartizate { get; set; }
    }
}
