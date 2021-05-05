using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using VehicleProject.Models;

namespace VehicleProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class VehicleController : Controller
    {
        private VehicleProjectUnitOfWork data { get; set; }
        public VehicleController(VehicleProjectContext ctx) => data = new VehicleProjectUnitOfWork(ctx);

        public ViewResult Index() {
            var search = new SearchData(TempData);
            search.Clear();

            return View();
        }

        [HttpPost]
        public RedirectToActionResult Search(SearchViewModel vm)
        {
            if (ModelState.IsValid) {
                var search = new SearchData(TempData) {
                    SearchTerm = vm.SearchTerm,
                    Type = vm.Type
                };
                return RedirectToAction("Search");
            }  
            else {
                return RedirectToAction("Index");
            }   
        }

        [HttpGet]
        public ViewResult Search() 
        {
            var search = new SearchData(TempData);

            if (search.HasSearchTerm) {
                var vm = new SearchViewModel {
                    SearchTerm = search.SearchTerm
                };

                var options = new QueryOptions<Vehicle> {
                    Include = "VehicleType, VehicleEmployees.Employee"
                };
                if (search.IsVehicle) { 
                    options.Where = b => b.Title.Contains(vm.SearchTerm);
                    vm.Header = $"Search results for vehicle title '{vm.SearchTerm}'";
                }
                if (search.IsEmployee) {
                    int index = vm.SearchTerm.LastIndexOf(' ');
                    if (index == -1) {
                        options.Where = b => b.VehicleEmployees.Any(
                            ba => ba.Employee.FirstName.Contains(vm.SearchTerm) || 
                            ba.Employee.LastName.Contains(vm.SearchTerm));
                    }
                    else {
                        string first = vm.SearchTerm.Substring(0, index);
                        string last = vm.SearchTerm.Substring(index + 1); 
                        options.Where = b => b.VehicleEmployees.Any(
                            ba => ba.Employee.FirstName.Contains(first) && 
                            ba.Employee.LastName.Contains(last));
                    }
                    vm.Header = $"Search results for employee '{vm.SearchTerm}'";
                }
                if (search.IsVehicleType) {                  
                    options.Where = b => b.VehicleTypeId.Contains(vm.SearchTerm);
                    vm.Header = $"Search results for vehicleType ID '{vm.SearchTerm}'";
                }
                vm.Vehicles = data.Vehicles.List(options);
                return View("SearchResults", vm);
            }
            else {
                return View("Index");
            }     
        }

        [HttpGet]
        public ViewResult Add(int id) => GetVehicle(id, "Add");

        [HttpPost]
        public IActionResult Add(VehicleViewModel vm)
        {
            if (ModelState.IsValid) {
                data.LoadNewVehicleEmployees(vm.Vehicle, vm.SelectedEmployees);
                data.Vehicles.Insert(vm.Vehicle);
                data.Save();

                TempData["message"] = $"{vm.Vehicle.Title} added to Vehicles.";
                return RedirectToAction("Index");  
            }
            else {
                Load(vm, "Add");
                return View("Vehicle", vm);
            }
        }

        [HttpGet]
        public ViewResult Edit(int id) => GetVehicle(id, "Edit");
        
        [HttpPost]
        public IActionResult Edit(VehicleViewModel vm)
        {
            if (ModelState.IsValid) {
                data.DeleteCurrentVehicleEmployees(vm.Vehicle);
                data.LoadNewVehicleEmployees(vm.Vehicle, vm.SelectedEmployees);
                data.Vehicles.Update(vm.Vehicle);
                data.Save(); 
                
                TempData["message"] = $"{vm.Vehicle.Title} updated.";
                return RedirectToAction("Search");  
            }
            else {
                Load(vm, "Edit");
                return View("Vehicle", vm);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id) => GetVehicle(id, "Delete");

        [HttpPost]
        public IActionResult Delete(VehicleViewModel vm)
        {
            data.Vehicles.Delete(vm.Vehicle); 
            data.Save();
            TempData["message"] = $"{vm.Vehicle.Title} removed from Vehicles.";
            return RedirectToAction("Search");  
        }

        private ViewResult GetVehicle(int id, string operation)
        {
            var book = new VehicleViewModel();
            Load(book, operation, id);
            return View("Vehicle", book);
        }
        private void Load(VehicleViewModel vm, string op, int? id = null)
        {
            if (Operation.IsAdd(op)) { 
                vm.Vehicle = new Vehicle();
            }
            else {
                vm.Vehicle = data.Vehicles.Get(new QueryOptions<Vehicle>
                {
                    Include = "VehicleEmployees.Employee, VehicleType",
                    Where = b => b.VehicleId == (id ?? vm.Vehicle.VehicleId)
                });
            }

            vm.SelectedEmployees = vm.Vehicle.VehicleEmployees?.Select(
                ba => ba.Employee.EmployeeId).ToArray();
            vm.Employees = data.Employees.List(new QueryOptions<Employee> {
                OrderBy = a => a.FirstName });
            vm.VehicleTypes = data.VehicleTypes.List(new QueryOptions<VehicleType> {
                    OrderBy = g => g.Name });
        }

    }
}