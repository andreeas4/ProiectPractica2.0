﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectPractica.Entities
{
    public class LivrabilEntity
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
        public ProiectEntity Proiect { get; set; } = null!;
    }
}
