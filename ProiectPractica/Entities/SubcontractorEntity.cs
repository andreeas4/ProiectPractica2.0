
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectPractica.Entities
{
    public class SubcontractorEntity
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



