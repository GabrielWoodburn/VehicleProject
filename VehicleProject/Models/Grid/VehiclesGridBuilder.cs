using Microsoft.AspNetCore.Http;

namespace VehicleProject.Models
{
    public class VehiclesGridBuilder : GridBuilder
    {
        public VehiclesGridBuilder(ISession sess) : base(sess) { }

        public VehiclesGridBuilder(ISession sess, VehiclesGridDTO values, 
            string defaultSortField) : base(sess, values, defaultSortField)
        {
            bool isInitial = values.VehicleType.IndexOf(FilterPrefix.VehicleType) == -1;
            routes.EmployeeFilter = (isInitial) ? FilterPrefix.Employee + values.Employee : values.Employee;
            routes.VehicleTypeFilter = (isInitial) ? FilterPrefix.VehicleType + values.VehicleType : values.VehicleType;
            routes.PriceFilter = (isInitial) ? FilterPrefix.Price + values.Price : values.Price;
        }

        public void LoadFilterSegments(string[] filter, Employee author)
        {
            if (author == null) { 
                routes.EmployeeFilter = FilterPrefix.Employee + filter[0];
            } else {
                routes.EmployeeFilter = FilterPrefix.Employee + filter[0]
                    + "-" + author.FullName.Slug();
            }
            routes.VehicleTypeFilter = FilterPrefix.VehicleType + filter[1];
            routes.PriceFilter = FilterPrefix.Price + filter[2];
        }
        public void ClearFilterSegments() => routes.ClearFilters();

        string def = VehiclesGridDTO.DefaultFilter;   
        public bool IsFilterByEmployee => routes.EmployeeFilter != def;
        public bool IsFilterByVehicleType => routes.VehicleTypeFilter != def;
        public bool IsFilterByPrice => routes.PriceFilter != def;

        public bool IsSortByVehicleType =>
            routes.SortField.EqualsNoCase(nameof(VehicleType));
        public bool IsSortByPrice =>
            routes.SortField.EqualsNoCase(nameof(Vehicle.Price));
    }
}
