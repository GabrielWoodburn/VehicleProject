using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace VehicleProject.Models
{
    public class VehicleProjectContext : IdentityDbContext<User>
    {
        public VehicleProjectContext(DbContextOptions<VehicleProjectContext> options)
            : base(options)
        { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleEmployee> VehicleEmployees { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // BookAuthor: set primary key 
            modelBuilder.Entity<VehicleEmployee>().HasKey(ba => new { ba.VehicleId, ba.EmployeeId });

            // BookAuthor: set foreign keys 
            modelBuilder.Entity<VehicleEmployee>().HasOne(ba => ba.Vehicle)
                .WithMany(b => b.VehicleEmployees)
                .HasForeignKey(ba => ba.VehicleId);
            modelBuilder.Entity<VehicleEmployee>().HasOne(ba => ba.Employee)
                .WithMany(a => a.VehicleEmployees)
                .HasForeignKey(ba => ba.EmployeeId);

            // Book: remove cascading delete with Genre
            modelBuilder.Entity<Vehicle>().HasOne(b => b.VehicleType)
                .WithMany(g => g.Vehicles)
                .OnDelete(DeleteBehavior.Restrict);

            // seed initial data
            modelBuilder.ApplyConfiguration(new SeedVehicleTypes());
            modelBuilder.ApplyConfiguration(new SeedVehicles());
            modelBuilder.ApplyConfiguration(new SeedEmployees());
            modelBuilder.ApplyConfiguration(new SeedVehicleEmployees());
        }

        public static async Task CreateAdminUser(IServiceProvider serviceProvider)
        {
            UserManager<User> userManager =
                serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string username = "admin";
            string password = "Sesame";
            string roleName = "Admin";

            // if role doesn't exist, create it
            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            // if username doesn't exist, create it and add to role
            if (await userManager.FindByNameAsync(username) == null)
            {
                User user = new User { UserName = username };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }
    }
}