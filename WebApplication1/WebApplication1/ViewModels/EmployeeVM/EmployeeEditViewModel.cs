using Microsoft.AspNetCore.Mvc.Rendering;

namespace Projekt.ViewModels.EmployeeVM
{
    public class EmployeeEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Reputation { get; set; }
        public int Wage { get; set; }
        public int? JobPositionId { get; set; }
        public SelectList? JobPositions { get; set; }
    }
}
