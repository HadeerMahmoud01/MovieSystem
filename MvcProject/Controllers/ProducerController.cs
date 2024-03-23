using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcProject.Data;

namespace MvcProject.Controllers
{
    public class ProducerController : Controller
    {
        private readonly AppDbContext _context;

        public ProducerController(AppDbContext context)
        {
            _context = context;
            
        }
        public async Task <IActionResult> Index()
        {
            if(_context == null)
            {
                return  Content("No Producers");
            }
            return View(await _context.Producer.ToListAsync());
        }
    }
}
