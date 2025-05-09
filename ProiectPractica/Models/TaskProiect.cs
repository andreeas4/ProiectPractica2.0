using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProiectPractica.Models;

namespace ProiectPractica.Models
{
    public class TaskProiect
    {
        public TaskProiect()
        {
        }

        [Key]
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Descriere { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime DataStart { get; set; }

        [DataType(DataType.Date)]
        public DateTime Deadline { get; set; }

        [Required, StringLength(50)]
        public string Status { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Responsabil { get; set; }

        public bool EsteNotificare { get; set; }

        [ForeignKey(nameof(Proiect))]
        public int Cod { get; set; }
        public Proiect Proiect { get; set; } = null!;

        

        
    }
}
