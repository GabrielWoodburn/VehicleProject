using System.Linq;

namespace VehicleProject.Models
{
    public class VehicleProjectUnitOfWork : IVehicleProjectUnitOfWork
    {
        private VehicleProjectContext context { get; set; }
        public VehicleProjectUnitOfWork(VehicleProjectContext ctx) => context = ctx;

        private Repository<Vehicle> vehicleData;
        public Repository<Vehicle> Vehicles {
            get {
                if (vehicleData == null)
                    vehicleData = new Repository<Vehicle>(context);
                return vehicleData;
            }
        }

        private Repository<Employee> employeeData;
        public Repository<Employee> Employees {
            get {
                if (employeeData == null)
                    employeeData = new Repository<Employee>(context);
                return employeeData;
            }
        }

        private Repository<VehicleEmployee> vehicleemployeeData;
        public Repository<VehicleEmployee> VehicleEmployees {
            get {
                if (vehicleemployeeData == null)
                    vehicleemployeeData = new Repository<VehicleEmployee>(context);
                return vehicleemployeeData;
            }
        }

        private Repository<VehicleType> vehicletypeData;
        public Repository<VehicleType> VehicleTypes
        {
            get {
                if (vehicletypeData == null)
                    vehicletypeData = new Repository<VehicleType>(context);
                return vehicletypeData;
            }
        }

        public void DeleteCurrentVehicleEmployees(Vehicle vehicle)
        {
            var currentEmployees = VehicleEmployees.List(new QueryOptions<VehicleEmployee> {
                Where = ve => ve.VehicleId == vehicle.VehicleId
            });
            foreach (VehicleEmployee ve in currentEmployees) {
                VehicleEmployees.Delete(ve);
            }
        }

        public void LoadNewVehicleEmployees(Vehicle vehicle, int[] employeeids)
        {
            vehicle.VehicleEmployees = employeeids.Select(i =>
                new VehicleEmployee { Vehicle = vehicle, EmployeeId = i })
                .ToList();
        }

        public void Save() => context.SaveChanges();
    }
}