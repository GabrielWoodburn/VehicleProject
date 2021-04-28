using System.Collections.Generic;

namespace VehicleProject.Models
{
    public class VehicleDTO
    {
        public int VehicleId { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public Dictionary<int, string> Employees { get; set; }

        public void Load(Vehicle vehicle)
        {
            VehicleId = vehicle.VehicleId;
            Title = vehicle.Title;
            Price = vehicle.Price;
            Employees = new Dictionary<int, string>();
            foreach (VehicleEmployee ba in vehicle.VehicleEmployees) {
                Employees.Add(ba.Employee.EmployeeId, ba.Employee.FullName);
            }
        }
    }

}
