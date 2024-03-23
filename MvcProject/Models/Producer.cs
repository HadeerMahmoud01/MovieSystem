using System.ComponentModel.DataAnnotations;

namespace MvcProject.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "ProfilePictureUrl")]
        public String ProfilePictureUrl { get; set; }
        [Display(Name = "FullName")]
        public String FullName { get; set; }
        [Display (Name = "Bio")]
        public String Bio { get; set; }

        public List<Movie> MoviesList { get; set; }
    }
}
