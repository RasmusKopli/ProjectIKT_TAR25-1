using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt.Data;
using Projekt.Models;
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
            // Include JobPosition navigation so the view can display the current JobPosition name
            return View(await _context.Employees
                .Include(e => e.JobPosition)
                .ToListAsync());
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

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var employee = await _context.Employees.FindAsync(id);

            if (employee == null) return NotFound();

            var viewModel = new EmployeeEditViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Reputation = employee.Reputation,
                Wage = employee.Wage,
                JobPositionId = employee.JobPositionId,
                JobPositions = new SelectList(_context.JobPositions, "Id", "JobName", employee.JobPositionId)
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmployeeEditViewModel viewModel)
        {
            if (id != viewModel.Id) return NotFound();

            if (ModelState.IsValid)
            {
                // Load employee including JobPosition navigation to keep tracking consistent
                var employee = await _context.Employees
                    .Include(e => e.JobPosition)
                    .FirstOrDefaultAsync(e => e.Id == id);
                if (employee == null) return NotFound();

                employee.Name = viewModel.Name;
                employee.Reputation = viewModel.Reputation;
                employee.Wage = viewModel.Wage;
                employee.JobPositionId = viewModel.JobPositionId;

                if (viewModel.JobPositionId.HasValue)
                {
                    var job = await _context.JobPositions.FindAsync(viewModel.JobPositionId.Value);
                    if (job != null)
                    {
                        // update both navigation and Position string
                        employee.JobPosition = job;
                        employee.Position = job.JobName;
                    }
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // If we got this far, something failed; repopulate the JobPositions select list
            viewModel.JobPositions = new SelectList(_context.JobPositions, "Id", "JobName", viewModel.JobPositionId);
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var employee = await _context.Employees
                .Include(e => e.JobPosition)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (employee == null) return NotFound();

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.JobPosition).
                FirstOrDefaultAsync(e => e.Id == id);

            if (employee != null)
            {
                if (employee != null)
                    employee.JobPosition.IsAvailable = true;

                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            var viewModel = new EmployeeCreateViewModel
            {
                JobPositions = new SelectList(_context.JobPositions, "Id", "JobName")
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeCreateViewModel viewModel)
        {
            foreach (var entry in ModelState)
            {
                foreach (var error in entry.Value.Errors)
                {
                    Console.WriteLine($"{entry.Key}: {error.ErrorMessage}");
                }
            }

            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                    Name = viewModel.Name,
                    Reputation = viewModel.Reputation,
                    Wage = viewModel.Wage,
                    JobPositionId = viewModel.JobPositionId
                };

                if (viewModel.JobPositionId.HasValue)
                {
                    var job = await _context.JobPositions.FindAsync(viewModel.JobPositionId.Value);
                    if (job != null)
                    {
                        employee.JobPosition = job;
                        employee.Position = job.JobName;
                        job.IsAvailable = false;
                        _context.JobPositions.Update(job);
                    }
                }

                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            viewModel.JobPositions = new SelectList(_context.JobPositions, "Id", "JobName", viewModel.JobPositionId);
            return View(viewModel);
        }
    }
}
