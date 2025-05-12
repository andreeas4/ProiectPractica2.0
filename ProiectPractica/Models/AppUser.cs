using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ProiectPractica.Models
{
    public class AppUser
    {
        public string? Id { get; set; } // ID-ul utilizatorului (IdentityUser ID)

        public string? UserName { get; set; } = string.Empty;

        public string? NumeComplet { get; set; } = string.Empty;

        public List<ResponsabilProiect> ProiecteRepartizate { get; set; }

        public AppUser()
        {
            ProiecteRepartizate = new List<ResponsabilProiect>();
        }

        public AppUser(string userName) : this()
        {
            UserName = userName;
        }

        public AppUser(string? numeComplet, List<ResponsabilProiect> proiecteRepartizate) : this()
        {
            NumeComplet = numeComplet;
            ProiecteRepartizate = proiecteRepartizate;
        }
    }
}
