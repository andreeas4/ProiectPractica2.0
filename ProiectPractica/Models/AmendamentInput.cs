namespace ProiectPractica.Models
{
    public class AmendamentInput
    {
        public string Tip { get; set; } = "PrelungireContract";
        public ModificareValoare? ModificareValoare { get; set; } = new();
        public PrelungireContract? PrelungireContract { get; set; } = new();
        public ModificareLivrabile? ModificareLivrabile { get; set; } = new();
    }
}
