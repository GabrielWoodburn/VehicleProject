using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VehicleProject.Models
{
    internal class SeedVehicleEmployees : IEntityTypeConfiguration<VehicleEmployee>
    {
        public void Configure(EntityTypeBuilder<VehicleEmployee> entity)
        {
            entity.HasData(
                new VehicleEmployee { VehicleId = 1, EmployeeId = 18 },
                new VehicleEmployee { VehicleId = 2, EmployeeId = 20 },
                new VehicleEmployee { VehicleId = 3, EmployeeId = 7 },
                new VehicleEmployee { VehicleId = 4, EmployeeId = 2 },
                new VehicleEmployee { VehicleId = 5, EmployeeId = 19 },
                new VehicleEmployee { VehicleId = 6, EmployeeId = 8 },
                new VehicleEmployee { VehicleId = 7, EmployeeId = 12 },
                new VehicleEmployee { VehicleId = 8, EmployeeId = 16 },
                new VehicleEmployee { VehicleId = 9, EmployeeId = 2 },
                new VehicleEmployee { VehicleId = 10, EmployeeId = 20 },
                new VehicleEmployee { VehicleId = 11, EmployeeId = 15 },
                new VehicleEmployee { VehicleId = 12, EmployeeId = 4 },
                new VehicleEmployee { VehicleId = 13, EmployeeId = 21 },
                new VehicleEmployee { VehicleId = 14, EmployeeId = 5 },
                new VehicleEmployee { VehicleId = 15, EmployeeId = 9 },
                new VehicleEmployee { VehicleId = 16, EmployeeId = 13 },
                new VehicleEmployee { VehicleId = 17, EmployeeId = 7 },
                new VehicleEmployee { VehicleId = 18, EmployeeId = 4 },
                new VehicleEmployee { VehicleId = 19, EmployeeId = 11 },
                new VehicleEmployee { VehicleId = 20, EmployeeId = 22 },
                new VehicleEmployee { VehicleId = 21, EmployeeId = 17 },
                new VehicleEmployee { VehicleId = 22, EmployeeId = 3 },
                new VehicleEmployee { VehicleId = 23, EmployeeId = 14 },
                new VehicleEmployee { VehicleId = 24, EmployeeId = 1 },
                new VehicleEmployee { VehicleId = 25, EmployeeId = 10 },
                new VehicleEmployee { VehicleId = 26, EmployeeId = 6 },
                new VehicleEmployee { VehicleId = 27, EmployeeId = 23 },
                new VehicleEmployee { VehicleId = 28, EmployeeId = 4 },
                new VehicleEmployee { VehicleId = 28, EmployeeId = 26 },
                new VehicleEmployee { VehicleId = 29, EmployeeId = 25 }
            );
        }
    }

}
