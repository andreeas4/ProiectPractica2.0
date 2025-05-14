using System.ComponentModel.DataAnnotations;

namespace ProiectPractica.Models
{
    public class Proiect
    {
        [Required(ErrorMessage = "Numele clientului este obligatoriu.")]
        public string NumeClient { get; set; } = string.Empty;

        [Required(ErrorMessage = "Domeniul proiectului este obligatoriu.")]
        public string Domeniul { get; set; } = string.Empty;

        [Required(ErrorMessage = "Obiectul contractului este obligatoriu.")]
        public string ObiectulContractului { get; set; } = string.Empty;

        [Required(ErrorMessage = "Data de semnare este obligatorie.")]
        public DateTime DataSemnareContract { get; set; }

        [Required(ErrorMessage = "Data de încheiere este obligatorie.")]
        public DateTime DataIncheiereContract { get; set; }

        [Required(ErrorMessage = "Valoarea contractului este obligatorie.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Valoarea trebuie să fie pozitivă.")]
        public decimal ValoareContract { get; set; }

        public int NrLivrabile { get; set; }

        public StatusProiect Status { get; set; }

        public bool EsteClientPublic { get; set; }
        public bool AreSubcontractor { get; set; }
        public int? NumarSubcontractori { get; set; }

        [Required(ErrorMessage = "Responsabilul contractului este obligatoriu.")]
        public ResponsabilProiect Responsabil { get; set; }
    }
}
