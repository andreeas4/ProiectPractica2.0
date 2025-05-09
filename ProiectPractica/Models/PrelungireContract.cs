using System.ComponentModel.DataAnnotations;

namespace ProiectPractica.Models
{
    public class PrelungireContract : ActAditional
    {
        public PrelungireContract()
        {
        }

        [Required]
        public DateTime NouaDataIncheiere { get; set; }

        public string? Observatii { get; set; }
    }
}
