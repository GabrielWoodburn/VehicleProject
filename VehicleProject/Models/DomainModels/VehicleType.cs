using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace VehicleProject.Models
{
    public class VehicleType
    {
        [MaxLength(10)]
        [Required(ErrorMessage = "Please enter a vehicleType id.")]
        [Remote("CheckVehicleType", "Validation", "Area")]
        public string VehicleTypeId { get; set; }
        
        [StringLength(25)]
        [Required(ErrorMessage = "Please enter a vehicle type name.")]
        public string Name { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
    }
}