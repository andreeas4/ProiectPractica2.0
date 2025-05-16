using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace ProiectPractica.Entities
{
    public class ProiectEntity
    {
        public ProiectEntity()
        {
            ActeAditionale = new HashSet<ActAditionalEntity>();
            Taskuri = new HashSet<TaskProiectEntity>();
            Livrabile = new HashSet<LivrabilEntity>();
            Subcontractori = new HashSet<SubcontractorEntity>();
              
        }

        
        [Key]
        public int Cod { get; set; }
        

        
        [Required]
        [StringLength(100)]
        [Display(Name = "Nume client")]
        public string NumeClient { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Domeniul proiectului")]
        public string Domeniul { get; set; } = string.Empty;

        [StringLength(500)]
        public string ObiectulContractului { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data semnare contract")]
        public DateTime DataSemnareContract { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data încheiere contract")]
        public DateTime DataIncheiereContract { get; set; }

        [Required]
        public StatusProiectEntity Status { get; set; }

        [Required]
        [Display(Name = "Este amendat?")]
        public bool ExistaAmendamente { get; set; }

        [Display(Name = "Număr amendamente")]
        [Range(0, int.MaxValue, ErrorMessage = "Numărul de amendamente trebuie să fie pozitiv.")]
        public int NumarAmendamente { get; set; }

        
        

        [Required]
        [Display(Name = "Este client public?")]
        public bool EsteClientPublic { get; set; }

        [Required]
        [Display(Name = "Are subcontractor?")]
        public bool AreSubcontractor { get; set; }

        [Display(Name = "Număr subcontractori")]
        [Range(0, int.MaxValue, ErrorMessage = "Numărul de subcontractori trebuie să fie pozitiv.")]
        public int NumarSubcontractori { get; set; }  // Copiat exact cum e folosit

        [Range(0, int.MaxValue, ErrorMessage = "Numărul de livrabile trebuie să fie pozitiv.")]
        public int NrLivrabile { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [DataType(DataType.Currency)]
        public decimal ValoareContract { get; set; }
        
        // Relații
        public ICollection<ActAditionalEntity> ActeAditionale { get; set; }
        public ICollection<TaskProiectEntity> Taskuri { get; set; }
        public ICollection<LivrabilEntity> Livrabile { get; set; }

        public virtual ICollection<SubcontractorEntity> Subcontractori { get; set; } = new List<SubcontractorEntity>();

        public ICollection<ResponsabilProiectEntity> Responsabili { get; set; } = new HashSet<ResponsabilProiectEntity>();

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

