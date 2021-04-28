using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace VehicleProject.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        [StringLength(200)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        [MaxLength(200)]
        [Remote("CheckEmployee", "Validation", "Area", 
            AdditionalFields = "FirstName, Operation")]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public ICollection<VehicleEmployee> VehicleEmployees { get; set; }
    }
}
