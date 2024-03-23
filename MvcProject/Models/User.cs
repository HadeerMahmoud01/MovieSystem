using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity;
namespace MvcProject.Models
{
    public class User : IdentityUser
    {
        public string Email { get; set; }
    }
}
