using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VehicleProject.Models
{
    internal class SeedEmployees : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> entity)
        {
            entity.HasData(
                new Employee { EmployeeId = 1, FirstName = "Max", LastName = "M" },
                new Employee { EmployeeId = 2, FirstName = "Sarah", LastName = "Suzie" },
                new Employee { EmployeeId = 3, FirstName = "Nana", LastName = "Crinkle" },
                new Employee { EmployeeId = 4, FirstName = "Jill", LastName = "Abert" },
                new Employee { EmployeeId = 5, FirstName = "James", LastName = "North" },
                new Employee { EmployeeId = 6, FirstName = "Emily", LastName = "Beate" },
                new Employee { EmployeeId = 7, FirstName = "Tric", LastName = "C." },
                new Employee { EmployeeId = 8, FirstName = "Sam", LastName = "Coates" },
                new Employee { EmployeeId = 9, FirstName = "Frank", LastName = "Diamond" },
                new Employee { EmployeeId = 10, FirstName = "Lilly", LastName = "Grant" },
                new Employee { EmployeeId = 11, FirstName = "Calt", LastName = "Shrew" },
                new Employee { EmployeeId = 12, FirstName = "Tyler", LastName = "Sartar" },
                new Employee { EmployeeId = 13, FirstName = "Roxane", LastName = "Looke" },
                new Employee { EmployeeId = 14, FirstName = "Demetrius", LastName = "Hand" },
                new Employee { EmployeeId = 15, FirstName = "Frank", LastName = "Herbert" },
                new Employee { EmployeeId = 16, FirstName = "Locke", LastName = "Howd" },
                new Employee { EmployeeId = 17, FirstName = "Canwo", LastName = "Loowart" },
                new Employee { EmployeeId = 18, FirstName = "Greg", LastName = "A." },
                new Employee { EmployeeId = 19, FirstName = "Jackie", LastName = "Morrison" },
                new Employee { EmployeeId = 20, FirstName = "Jimmy", LastName = "S" },
                new Employee { EmployeeId = 21, FirstName = "Mary", LastName = "W" },
                new Employee { EmployeeId = 22, FirstName = "Max", LastName = "Tacke" },
                new Employee { EmployeeId = 23, FirstName = "B", LastName = "Awworwo" },
                new Employee { EmployeeId = 25, FirstName = "Steve", LastName = "Eitter" },
                new Employee { EmployeeId = 26, FirstName = "Sampson", LastName = "Allk" }
            );
        }
    }

}