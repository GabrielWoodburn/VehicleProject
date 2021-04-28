using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VehicleProject.Models
{
    public class VehicleViewModel : IValidatableObject
    {
        public Vehicle Vehicle { get; set; }
        public IEnumerable<VehicleType> VehicleTypes { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public int[] SelectedEmployees { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext ctx) {
            if (SelectedEmployees == null)
            {
                yield return new ValidationResult(
                  "Please select at least one employee.",
                  new[] { nameof(SelectedEmployees) });
            }
        }

    }
}
