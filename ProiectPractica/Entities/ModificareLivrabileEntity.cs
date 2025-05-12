namespace ProiectPractica.Entities
{
    public class ModificareLivrabileEntity : ActAditionalEntity
    {
        public ModificareLivrabileEntity()
        {
        }

        public string DescriereSchimbare { get; set; }

        public bool EsteAdaugare { get; set; } // true = adăugare, false = eliminare
    }
}
