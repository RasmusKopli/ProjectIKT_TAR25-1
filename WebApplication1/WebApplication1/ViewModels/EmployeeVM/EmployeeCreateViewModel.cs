using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Projekt.ViewModels.EmployeeVM
{
    public class EmployeeCreateViewModel
    {
        public string Name { get; set; }
        public string Reputation { get; set; }
        public int Wage { get; set; }
        public int? JobPositionId { get; set; }

        [ValidateNever]
        public SelectList? JobPositions { get; set; }
    }
}
