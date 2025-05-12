using System.ComponentModel.DataAnnotations;

namespace ProiectPractica.Entities
{
    public class ModificareValoareEntity : ActAditionalEntity
    {
        public ModificareValoareEntity()
        {
        }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal ValoareNoua { get; set; }

        public string? Motiv { get; set; }
    }
}
