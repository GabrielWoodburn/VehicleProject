using System.Collections.Generic;

namespace VehicleProject.Models
{
    public class AuthorListViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPages { get; set; }
    }
}
