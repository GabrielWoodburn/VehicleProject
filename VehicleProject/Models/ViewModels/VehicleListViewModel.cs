using System.Collections.Generic;

namespace VehicleProject.Models
{
    public class BookListViewModel 
    {
        public IEnumerable<Vehicle> Vehicles { get; set; }
        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPages { get; set; }

        // data for filter drop-downs - one hardcoded
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<VehicleType> VehicleTypes { get; set; }
        public Dictionary<string, string> Prices =>
            new Dictionary<string, string> {
                { "under7", "Under $7" },
                { "7to14", "$7 to $14" },
                { "over14", "Over $14" }
            };
    }
}
