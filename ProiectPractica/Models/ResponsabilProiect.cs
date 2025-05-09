using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectPractica.Models
{
    public class ResponsabilProiect
    {
        public ResponsabilProiect()
        {
        }

        

        [Key]
        public int Id { get; set; }

        [Required]
        public string AppUserId { get; set; } = string.Empty;
        public AppUser AppUser { get; set; } = null!;

        [ForeignKey(nameof(Proiect))]
        public int Cod { get; set; }
        public Proiect Proiect { get; set; } = null!;

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
