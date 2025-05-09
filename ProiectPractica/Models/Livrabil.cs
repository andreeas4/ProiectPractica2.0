using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectPractica.Models
{
    public class Livrabil
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nume { get; set; } = string.Empty;

        public string? Descriere { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataEstimata { get; set; }

        public bool EstePredat { get; set; }

        [ForeignKey(nameof(Proiect))]
        public int Cod { get; set; }
        public Proiect Proiect { get; set; } = null!;
    }
}
