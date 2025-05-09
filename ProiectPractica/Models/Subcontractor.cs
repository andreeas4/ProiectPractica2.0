
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProiectPractica.Models;

namespace ProiectPractica.Models
{
    public class Subcontractor
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Nume { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string Domeniu { get; set; } = string.Empty;

        public string? Email { get; set; } // <- nu este obligatoriu
        public string? Telefon { get; set; } // <- nu este obligatoriu

       
    }
}



