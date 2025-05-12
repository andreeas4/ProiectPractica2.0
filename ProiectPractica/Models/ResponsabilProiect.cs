using System.ComponentModel.DataAnnotations;

namespace ProiectPractica.Models
{
    public class ResponsabilProiect
    {
       

        [Required(ErrorMessage = "Utilizatorul este obligatoriu.")]
        public string AppUserId { get; set; } = string.Empty;

        [Display(Name = "Nume utilizator")]
        public string NumeUtilizator { get; set; } = string.Empty;

       
    }
}
