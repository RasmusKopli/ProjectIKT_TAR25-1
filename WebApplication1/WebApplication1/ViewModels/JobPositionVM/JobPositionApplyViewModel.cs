using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Projekt.ViewModels.JobPositionVM
{
    public class JobPositionApplyViewModel
    {
        public int JobPositionId { get; set; }

        [ValidateNever]
        public string JobName { get; set; }

        public string Name { get; set; }
        public string Reputation { get; set; }
        public int Wage { get; set; }
    }
}
