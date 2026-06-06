using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Data;

namespace Projekt.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly WorkplaceContext _context;

        public EmployeeController(WorkplaceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }
    }
}
