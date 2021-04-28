namespace VehicleProject.Models
{
    public class VehicleEmployee
    {
        public int VehicleId { get; set; }
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
