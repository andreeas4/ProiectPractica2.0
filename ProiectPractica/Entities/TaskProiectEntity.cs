using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectPractica.Entities
{
    public class TaskProiectEntity
    {
        public TaskProiectEntity()
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
        public string Status { get; set; } = "Open";
        public bool EsteNotificare { get; set; }

        [ForeignKey(nameof(Proiect))]
        public int Cod { get; set; }
        public ProiectEntity Proiect { get; set; } = null!;

        [ForeignKey(nameof(Responsabil))]
        public string ResponsabilId { get; set; } = null!;
        public AppUserEntity Responsabil { get; set; } = null!;


    }
}
