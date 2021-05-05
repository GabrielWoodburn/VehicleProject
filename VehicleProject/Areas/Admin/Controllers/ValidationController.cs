using Microsoft.AspNetCore.Mvc;
using VehicleProject.Models;

namespace VehicleProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ValidationController : Controller
    {
        private Repository<Employee> employeeData { get; set; }
        private Repository<VehicleType> vehicleTypeData { get; set; }

        public ValidationController(VehicleProjectContext ctx)
        { 
            employeeData = new Repository<Employee>(ctx);
            vehicleTypeData = new Repository<VehicleType>(ctx);
        }

        public JsonResult CheckVehicleType(string vehicleTypeId)
        {
            var validate = new Validate(TempData);
            validate.CheckVehicleType(vehicleTypeId, vehicleTypeData);
            if (validate.IsValid) {
                validate.MarkVehicleTypeChecked();
                return Json(true);
            }
            else {
                return Json(validate.ErrorMessage);
            }
        }

        public JsonResult CheckEmployee(string firstName, string lastName, string operation)
        {
            var validate = new Validate(TempData);
            validate.CheckEmployee(firstName, lastName, operation, employeeData);
            if (validate.IsValid) {
                validate.MarkEmployeeChecked();
                return Json(true);
            }
            else {
                return Json(validate.ErrorMessage);
            }
        }
    }
}