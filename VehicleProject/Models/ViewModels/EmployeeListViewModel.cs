using System.Collections.Generic;

namespace VehicleProject.Models
{
    public class EmployeeListViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPages { get; set; }
    }
}
