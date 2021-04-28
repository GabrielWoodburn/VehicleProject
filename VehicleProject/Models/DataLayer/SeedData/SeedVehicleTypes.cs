using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VehicleProject.Models
{
    internal class SeedVehicleTypes : IEntityTypeConfiguration<VehicleType>
    {
        public void Configure(EntityTypeBuilder<VehicleType> entity)
        {
            entity.HasData(
                new VehicleType { VehicleTypeId = "car", Name = "Car" },
                new VehicleType { VehicleTypeId = "truck", Name = "Truck" },
                new VehicleType { VehicleTypeId = "semi", Name = "Semi" },
                new VehicleType { VehicleTypeId = "van", Name = "Van" },
                new VehicleType { VehicleTypeId = "bike", Name = "Bike" }
            );
        }
    }

}
