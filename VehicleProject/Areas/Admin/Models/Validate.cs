using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace VehicleProject.Models
{
    public class Validate
    {
        private const string VehicleTypeKey = "validVehicleType";
        private const string EmployeeKey = "validEmployee";
        private const string EmailKey = "validEmail";

        private ITempDataDictionary tempData { get; set; }
        public Validate(ITempDataDictionary temp) => tempData = temp;

        public bool IsValid { get; private set; }
        public string ErrorMessage { get; private set; }

        public void CheckGenre(string vehicleTypeId, Repository<VehicleType> data)
        {
            VehicleType entity = data.Get(vehicleTypeId);
            IsValid = (entity == null) ? true : false;
            ErrorMessage = (IsValid) ? "" : 
                $"VehicleType id {vehicleTypeId} is already in the database.";
        }
        public void MarkGenreChecked() => tempData[VehicleTypeKey] = true;
        public void ClearGenre() => tempData.Remove(VehicleTypeKey);
        public bool IsGenreChecked => tempData.Keys.Contains(VehicleTypeKey);

        public void CheckAuthor(string firstName, string lastName, string operation, Repository<Employee> data)
        {
            Employee entity = null; 
            if (Operation.IsAdd(operation)) {
                entity = data.Get(new QueryOptions<Employee> {
                    Where = a => a.FirstName == firstName && a.LastName == lastName });
            }
            IsValid = (entity == null) ? true : false;
            ErrorMessage = (IsValid) ? "" : 
                $"Employee {entity.FullName} is already in the database.";
        }
        public void MarkAuthorChecked() => tempData[EmployeeKey] = true;
        public void ClearAuthor() => tempData.Remove(EmployeeKey);
        public bool IsAuthorChecked => tempData.Keys.Contains(EmployeeKey);
    }
}
