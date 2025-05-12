using System.ComponentModel.DataAnnotations;

namespace ProiectPractica.Models
{
    public class ModificareLivrabile : ActAditional
    {
        

        [Display(Name = "Este adăugare?")]
        public bool EsteAdaugare { get; set; } = true; // default este adăugare
    }
}