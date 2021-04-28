namespace VehicleProject.Models
{
    public interface IVehicleProjectUnitOfWork
    {
        Repository<Vehicle> Vehicles { get; }
        Repository<Employee> Employees { get; }
        Repository<VehicleEmployee> VehicleEmployees { get; }
        Repository<VehicleType> VehicleTypes { get; }

        void DeleteCurrentVehicleEmployees(Vehicle vehicle);
        void LoadNewVehicleEmployees(Vehicle vehicle, int[] employeeids);
        void Save();
    }
}
