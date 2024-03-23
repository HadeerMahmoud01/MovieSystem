using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcProject.Data;
using MvcProject.Models;

namespace MvcProject.Controllers
{
    public class AccessController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _appDbContext;
        private readonly SignInManager<User> _signInManager;

        public AccessController(UserManager<User> userManager, AppDbContext appDbContext,SignInManager<User>signInManager)
        {
            this._userManager = userManager;
            this._appDbContext = appDbContext;
            this._signInManager = signInManager;

        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Login(Login loginuser)
        {
           
           var user = await _userManager.FindByEmailAsync(loginuser.Email);
            if (user != null) {
                var password= await _userManager.CheckPasswordAsync(user, loginuser.Password);
                if (password != null)
                {
                    var creditionals= await _signInManager.CheckPasswordSignInAsync(user, loginuser.Password, password);
                    if (creditionals.Succeeded)
                    {
                        return RedirectToAction("Index","Movie");
                    }
                }
                return Content("no");
            }
            else
            {
                return Content("nggo");
            }
        }
    }
}
