using System.ComponentModel.DataAnnotations;

namespace MvcProject.Data.Dto
{
    public class ActorDto
    {

        public int Id { get; set; }
        [Display(Name = "ProfilePictureUrl")]
        [Required (ErrorMessage = "ProfilePictureUrl is required")]
        public String ProfilePictureUrl { get; set; }
        [Display(Name = "FullName")]
        [Required (ErrorMessage = "FullName is Required")]
        public String FullName { get; set; }
        [Display(Name = "Bio")]
        [Required(ErrorMessage ="Bio is Required")]
        public String Bio { get; set; }
    }
}
