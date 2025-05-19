﻿using ProiectPractica.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class TaskProiectEntity
{
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
    public bool IsCompleted { get; set; } = false;  
    public ProiectEntity Proiect { get; set; } = null!;

    [Required] // Ensure this is present
    [ForeignKey(nameof(Responsabil))]
    public string ResponsabilId { get; set; } = null!;
    public AppUserEntity Responsabil { get; set; } = null!;
}