using System.ComponentModel.DataAnnotations;

namespace ProiectPractica.Entities
{
    public class ProjectEntity
    {
        [Key]
        public int Code { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
    }
}
