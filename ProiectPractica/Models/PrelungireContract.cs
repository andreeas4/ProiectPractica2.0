using System.ComponentModel.DataAnnotations;

namespace ProiectPractica.Models
{
    public class PrelungireContract : ActAditional
    {
        

        [Required(ErrorMessage = "Data încheierii este obligatorie")]
        public DateTime NouaDataIncheiere { get; set; }

        public string? Observatii { get; set; }
    }
}
