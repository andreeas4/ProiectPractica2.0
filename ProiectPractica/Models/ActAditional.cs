using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProiectPractica.Models
{
    public abstract class ActAditional
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Data Actului este obligatorie")]
        [DataType(DataType.Date)]
        public DateTime DataAct { get; set; }

        [Required(ErrorMessage = "Codul proiectului este obligatoriu")]
        public int CodProiect { get; set; }

        public string? NumeProiect { get; set; } // Opțional, pentru afișare în UI
    }
}
