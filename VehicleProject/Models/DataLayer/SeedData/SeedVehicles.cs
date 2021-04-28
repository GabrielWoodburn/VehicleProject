using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VehicleProject.Models
{
    internal class SeedVehicles : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> entity)
        {
            entity.HasData(
                new Vehicle { VehicleId = 1, Title = "F-150", VehicleTypeId = "truck", Price = 18.00 },
                new Vehicle { VehicleId = 2, Title = "Cruiser", VehicleTypeId = "semi", Price = 5.50 },
                new Vehicle { VehicleId = 3, Title = "F-150X", VehicleTypeId = "truck", Price = 4.50 },
                new Vehicle { VehicleId = 4, Title = "Dodge Caravan", VehicleTypeId = "van", Price = 11.50 },
                new Vehicle { VehicleId = 5, Title = "Eciipse", VehicleTypeId = "car", Price = 10.99 },
                new Vehicle { VehicleId = 6, Title = "Suzuki", VehicleTypeId = "bike", Price = 13.50 },
                new Vehicle { VehicleId = 7, Title = "Ninja", VehicleTypeId = "bike", Price = 4.25 },
                new Vehicle { VehicleId = 8, Title = "Crotter", VehicleTypeId = "semi", Price = 16.25 },
                new Vehicle { VehicleId = 9, Title = "Chevy", VehicleTypeId = "van", Price = 15.00 },
                new Vehicle { VehicleId = 10, Title = "Ninja x2", VehicleTypeId = "bike", Price = 12.50 },
                new Vehicle { VehicleId = 11, Title = "Dunebug", VehicleTypeId = "semi", Price = 8.75 },
                new Vehicle { VehicleId = 12, Title = "Jeep", VehicleTypeId = "car", Price = 9.00 },
                new Vehicle { VehicleId = 13, Title = "Patriot", VehicleTypeId = "semi", Price = 6.50D },
                new Vehicle { VehicleId = 14, Title = "Lincoln", VehicleTypeId = "car", Price = 10.25 },
                new Vehicle { VehicleId = 15, Title = "Security", VehicleTypeId = "van", Price = 15.50 },
                new Vehicle { VehicleId = 16, Title = "Harley", VehicleTypeId = "bike", Price = 14.50 },
                new Vehicle { VehicleId = 17, Title = "Toyota", VehicleTypeId = "truck", Price = 6.75 },
                new Vehicle { VehicleId = 18, Title = "Prius", VehicleTypeId = "car", Price = 8.50 },
                new Vehicle { VehicleId = 19, Title = "Red", VehicleTypeId = "truck", Price = 10.99 },
                new Vehicle { VehicleId = 20, Title = "Dodge Van", VehicleTypeId = "van", Price = 5.75 },
                new Vehicle { VehicleId = 21, Title = "Lexus G6", VehicleTypeId = "truck", Price = 8.50 },
                new Vehicle { VehicleId = 22, Title = "LongRoad", VehicleTypeId = "semi", Price = 12.50 },
                new Vehicle { VehicleId = 23, Title = "F-250", VehicleTypeId = "truck", Price = 10.99 },
                new Vehicle { VehicleId = 24, Title = "ShortRoad", VehicleTypeId = "van", Price = 13.75 },
                new Vehicle { VehicleId = 25, Title = "BigBike", VehicleTypeId = "bike", Price = 13.50 },
                new Vehicle { VehicleId = 26, Title = "Car Test", VehicleTypeId = "car", Price = 9.00 },
                new Vehicle { VehicleId = 27, Title = "Franklin", VehicleTypeId = "bike", Price = 11.00 },
                new Vehicle { VehicleId = 28, Title = "Jackson", VehicleTypeId = "car", Price = 8.75 },
                new Vehicle { VehicleId = 29, Title = "Buick", VehicleTypeId = "car", Price = 9.75 }
            );
        }
    }

}
