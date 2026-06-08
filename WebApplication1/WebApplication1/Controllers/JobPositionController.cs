using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Data;
using Projekt.Migrations;
using Projekt.Models;
using Projekt.ViewModels.JobPositionVM;

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

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var position = await _context.JobPositions.FirstOrDefaultAsync(m => m.Id == id);

            if (position == null) return NotFound();

            var viewModel = new JobPositionDetailsViewModel
            {
                Id = position.Id,
                JobName = position.JobName,
                JobId = position.JobId,
                Salary = position.Salary,
                IsAvailable = position.IsAvailable
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View(new JobPositionCreateViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JobPositionCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var position = new JobPositions
                {
                    JobName = viewModel.JobName,
                    JobId = viewModel.JobId,
                    Salary = viewModel.Salary,
                    IsAvailable = viewModel.IsAvailable
                };

                _context.JobPositions.Add(position);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var position = await _context.JobPositions.FirstOrDefaultAsync(m => m.Id == id);

            if (position == null) return NotFound();

            var viewModel = new JobPositionDeleteViewModel
            {
                Id = position.Id,
                JobName = position.JobName,
                JobId = position.JobId,
                Salary = position.Salary,
                IsAvailable = position.IsAvailable
            };

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var position = await _context.JobPositions.FindAsync(id);

            if (position != null)
            {
                _context.JobPositions.Remove(position);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Apply(int? id)
        {
            if (id == null) return NotFound();

            var position = await _context.JobPositions.FindAsync(id);

            if (position == null) return NotFound();

            if (!position.IsAvailable)
                return RedirectToAction(nameof(Index));

            var viewModel = new JobPositionApplyViewModel
            {
                JobPositionId = position.Id,
                JobName = position.JobName,
                Wage = position.Salary
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Apply (JobPositionApplyViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var position = await _context.JobPositions.FindAsync(viewModel.JobPositionId);

                if (position == null) return NotFound();

                if (!position.IsAvailable)
                {
                    ModelState.AddModelError("", "This position is no longer available.");
                    return View(viewModel);
                }

                var employee = new Employee
                {
                    Name = viewModel.Name,
                    Reputation = viewModel.Reputation,
                    Wage = viewModel.Wage,
                    JobPositionId = viewModel.JobPositionId,
                    Position = viewModel.JobName
                };

                    position.IsAvailable = false;

                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }
    }
}
