using System.Linq;

namespace VehicleProject.Models
{
    public class VehicleQueryOptions : QueryOptions<Vehicle>
    {
        public void SortFilter(VehiclesGridBuilder builder)
        {
            if (builder.IsFilterByVehicleType) {
                Where = b => b.VehicleTypeId == builder.CurrentRoute.VehicleTypeFilter;
            }
            if (builder.IsFilterByPrice) {
                if (builder.CurrentRoute.PriceFilter == "under7")
                    Where = b => b.Price < 7;
                else if (builder.CurrentRoute.PriceFilter == "7to14")
                    Where = b => b.Price >= 7 && b.Price <= 14;
                else
                    Where = b => b.Price > 14;
            }
            if (builder.IsFilterByEmployee) {
                int id = builder.CurrentRoute.EmployeeFilter.ToInt();
                if (id > 0)
                    Where = b => b.VehicleEmployees.Any(ba => ba.Employee.EmployeeId == id);
            }

            if (builder.IsSortByVehicleType) {
                OrderBy = b => b.VehicleType.Name;
            }
            else if (builder.IsSortByPrice) {
                OrderBy = b => b.Price;
            }
            else  {
                OrderBy = b => b.Title;
            }
        }
    }
}
