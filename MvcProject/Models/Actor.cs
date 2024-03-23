using System.ComponentModel.DataAnnotations;

namespace MvcProject.Models
{
    public class Actor
    {
        [Key] 
        public int Id { get; set; }
        [Display(Name ="ProfilePictureUrl")]
        public String ProfilePictureUrl { get; set; }
        [Display (Name = "FullName")]
        public String FullName { get; set; }
        [Display(Name = "Bio")]
        public String Bio { get; set; }

        public List<Actor_Movie> Actor_Movies { get; set; }
    }
}
