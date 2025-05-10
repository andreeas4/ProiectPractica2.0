using System.ComponentModel.DataAnnotations;

namespace ProiectPractica.Models
{
    public class Project
    {
        [Required]
        public string Name { get; set; }

        public string Domain { get; set; }

        public string ContractReason { get; set; }

        public DateTime SignDate { get; set; }

        public DateTime ContractCloseDate { get; set; }

        public string ContractValue { get; set; }

        public int LivrablesCount { get; set; }

        public StatusProiect Status { get; set; }

        public bool IsPublicClient { get; set; }

        public bool HasSubcontractors { get; set; }

        public int NumberOfContractors { get; set; }
    }
}
