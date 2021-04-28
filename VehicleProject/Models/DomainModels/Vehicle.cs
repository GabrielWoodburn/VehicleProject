using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VehicleProject.Models
{
    public partial class Vehicle
    {
        public int VehicleId { get; set; }

        [Required(ErrorMessage = "Please enter a title.")]
        [StringLength(200)]
        public string Title { get; set; }

        [Range(0.0, 1000000.0, ErrorMessage = "Price must be more than 0.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Please select a vehicleTypeId.")]
        public string VehicleTypeId { get; set; }

        public VehicleType VehicleType { get; set; }
        public ICollection<VehicleEmployee> VehicleEmployees { get; set; }
    }
}
