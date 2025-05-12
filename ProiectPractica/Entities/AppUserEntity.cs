using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ProiectPractica.Entities
{
    public class AppUserEntity : IdentityUser
    {
        public AppUserEntity()
        {
            ProiecteRepartizate = new List<ResponsabilProiectEntity>();
        }

        public AppUserEntity(string userName) : base(userName)
        {
        }

        public AppUserEntity(string? numeComplet, ICollection<ResponsabilProiectEntity> proiecteRepartizate) : this(numeComplet)
        {
            ProiecteRepartizate = proiecteRepartizate;
        }

        public string? NumeComplet { get; set; } = string.Empty;

        public ICollection<ResponsabilProiectEntity> ProiecteRepartizate { get; set; }
    }
}
