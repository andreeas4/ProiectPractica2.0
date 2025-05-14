using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectPractica.Entities
{
    public class ResponsabilProiectEntity
    {
        public ResponsabilProiectEntity()
        {
        }

        

        [Key]
        public int Id { get; set; }

        [Required]
        public string AppUserId { get; set; } = string.Empty;
        public string NumeUtilizator { get; set; } = string.Empty;
        public AppUserEntity AppUser { get; set; } = null!;

        [ForeignKey(nameof(Proiect))]
        public int Cod { get; set; }
        public ProiectEntity Proiect { get; set; } = null!;

        public DateTime DataAtribuire { get; set; } = DateTime.Now;

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
