using System.ComponentModel.DataAnnotations;

namespace ProiectPractica.Models
{
    public class ModificareValoare : ActAditional
    {
        [Required(ErrorMessage = "Valoarea nouă este obligatorie.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Valoarea trebuie să fie pozitivă și diferită de zero.")]
        [Display(Name = "Valoare nouă")]
        public decimal ValoareNoua { get; set; }

        [StringLength(250, ErrorMessage = "Motivul nu poate depăși 250 caractere.")]
        public string? Motiv { get; set; } = string.Empty;
    }
}
