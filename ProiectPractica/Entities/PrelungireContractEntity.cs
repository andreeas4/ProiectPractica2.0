using System.ComponentModel.DataAnnotations;

namespace ProiectPractica.Entities
{
    public class PrelungireContractEntity : ActAditionalEntity
    {
        public PrelungireContractEntity()
        {
        }

        [Required]
        public DateTime NouaDataIncheiere { get; set; }

        public string? Observatii { get; set; }
    }
}
