using System.Collections.Generic;

namespace VehicleProject.Models
{
    public class VehicleListViewModel 
    {
        public IEnumerable<Vehicle> Vehicles { get; set; }
        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPages { get; set; }

        // data for filter drop-downs
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<VehicleType> VehicleTypes { get; set; }
        public Dictionary<string, string> Prices =>
            new Dictionary<string, string> {
                { "under10", "Under $10" },
                { "10to15", "$10 to $15" },
                { "over15", "Over $15" }
            };
    }
}
