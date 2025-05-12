using System.ComponentModel.DataAnnotations;

namespace ProiectPractica.Models
{
    public enum StatusProiect
    {
        [Display(Name = "Nou")]
        Nou,

        [Display(Name = "În desfășurare")]
        InDesfasurare,

        [Display(Name = "Suspendat")]
        Suspendat,

        [Display(Name = "Prelungit")]
        Prelungit,

        [Display(Name = "Întârziat")]
        Intarziat,

        [Display(Name = "Finalizat")]
        Finalizat,

        [Display(Name = "Anulat")]
        Anulat
    }
}
