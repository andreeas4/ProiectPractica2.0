using System.ComponentModel.DataAnnotations;

namespace ProiectPractica.Models
{
    public class TaskProiect
    {
        

        [Required(ErrorMessage = "Descrierea task-ului este obligatorie.")]
        [StringLength(200, ErrorMessage = "Descrierea poate avea maxim 200 de caractere.")]
        public string Descriere { get; set; } = string.Empty;


        [Required(ErrorMessage = "Deadline-ul este obligatoriu.")]
        [DataType(DataType.Date)]
        public DateTime Deadline { get; set; }

        

        [StringLength(100, ErrorMessage = "Numele responsabilului poate avea maxim 100 de caractere.")]
        public string? Responsabil { get; set; }

        [Display(Name = "Trimite notificare")]
        public bool EsteNotificare { get; set; } = false;

        
        public int? CodProiect { get; set; }

        
        public string? NumeProiect { get; set; } = string.Empty;
    }
}
