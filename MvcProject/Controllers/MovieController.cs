using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcProject.Data;

namespace MvcProject.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppDbContext _context;

        public MovieController(AppDbContext context)
        {
            _context = context;
            
        }

        public async Task< IActionResult> Index()
        {
            var result= await _context.Movie.Include(m=>m.Cinema_Movie).ToListAsync();
            return View(result);
        }
    }
}
