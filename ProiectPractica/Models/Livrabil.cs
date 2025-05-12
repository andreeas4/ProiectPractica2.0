using System;
using System.ComponentModel.DataAnnotations;

namespace ProiectPractica.Models
{
    public class Livrabil
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Numele livrabilului este obligatoriu")]
        public string Nume { get; set; } = string.Empty;

        public string? Descriere { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataEstimata { get; set; }

        
        public string? NumeProiect { get; set; } // Opțional, pentru afișare în UI
    }
}