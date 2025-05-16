namespace ProiectPractica.Entities
{
    public class UserSelectedProject
    {
        public string UserId { get; set; }
        public AppUserEntity User { get; set; }

        public int ProiectId { get; set; }
        public ProiectEntity Proiect { get; set; }
    }
}
