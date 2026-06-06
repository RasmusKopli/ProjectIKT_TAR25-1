using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Data;

namespace Projekt.Controllers
{
    public class JobPositionController : Controller
    {
        private readonly WorkplaceContext _context;

        public JobPositionController(WorkplaceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.JobPositions.ToListAsync());
        }
    }
}
