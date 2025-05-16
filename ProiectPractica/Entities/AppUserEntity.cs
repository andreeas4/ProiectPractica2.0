using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ProiectPractica.Entities
{
    public class AppUserEntity : IdentityUser
    {
        public AppUserEntity()
        {
            ProiecteRepartizate = new HashSet<ResponsabilProiectEntity>();
            SelectedProjects = new HashSet<UserSelectedProject>();
        }

        public AppUserEntity(string userName) : base(userName)
        {
            ProiecteRepartizate = new HashSet<ResponsabilProiectEntity>();
            SelectedProjects = new HashSet<UserSelectedProject>();
        }

        public string? NumeComplet { get; set; } = string.Empty;

        public ICollection<UserSelectedProject> SelectedProjects { get; set; }
        public ICollection<ResponsabilProiectEntity> ProiecteRepartizate { get; set; }
    }
}