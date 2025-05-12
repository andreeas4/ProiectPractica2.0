using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProiectPractica.Entities
{
    public abstract class ActAditionalEntity
    {
        protected ActAditionalEntity()
        {
        }

        [Key]
        public int Id { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime DataAct { get; set; }

        [ForeignKey(nameof(Proiect))]
        public int Cod { get; set; }
        public Proiect Proiect { get; set; } = null!;


    }
}
