using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Projekt.Data;
using Projekt.ViewModels.EmployeeVM;

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

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var employee = await _context.Employees.FirstOrDefaultAsync(m =>  m.Id == id);

            if (employee == null) return NotFound();

            var viewModel = new EmployeeDetailsViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Position = employee.Position,
                Reputation = employee.Reputation,
                Wage = employee.Wage
            };

            return View(viewModel);
        }
    }
}
