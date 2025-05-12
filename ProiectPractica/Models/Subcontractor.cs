using System.ComponentModel.DataAnnotations;

namespace ProiectPractica.Models
{
    public class Subcontractor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Numele subcontractorului este obligatoriu.")]
        [StringLength(100, ErrorMessage = "Numele poate avea maxim 100 de caractere.")]
        public string Nume { get; set; } = string.Empty;

        [Required(ErrorMessage = "Domeniul este obligatoriu.")]
        [StringLength(100, ErrorMessage = "Domeniul poate avea maxim 100 de caractere.")]
        public string Domeniu { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Adresa de email nu este validă.")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "Numărul de telefon nu este valid.")]
        public string? Telefon { get; set; }
    }
}
