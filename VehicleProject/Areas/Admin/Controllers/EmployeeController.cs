using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using VehicleProject.Models;

namespace VehicleProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private Repository<Employee> data { get; set; }
        public EmployeeController(VehicleProjectContext ctx) => data = new Repository<Employee>(ctx);

        public ViewResult Index()
        {
            var employees = data.List(new QueryOptions<Employee> {
                OrderBy = a => a.FirstName
            });
            return View(employees);
        }

        public RedirectToActionResult Select(int id, string operation)
        {
            switch (operation.ToLower())
            {
                case "view vehicles":
                    return RedirectToAction("ViewVehicles", new { id });
                case "edit":
                    return RedirectToAction("Edit", new { id });
                case "delete":
                    return RedirectToAction("Delete", new { id });
                default:
                    return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ViewResult Add() => View("Employee", new Employee());

        [HttpPost]
        public IActionResult Add(Employee employee, string operation)
        {
            var validate = new Validate(TempData);
            if (!validate.IsAuthorChecked) {
                validate.CheckAuthor(employee.FirstName, employee.LastName, operation, data);
                if (!validate.IsValid) {
                    ModelState.AddModelError(nameof(employee.LastName), validate.ErrorMessage);
                }    
            }
            
            if (ModelState.IsValid) {
                data.Insert(employee);
                data.Save();
                validate.ClearAuthor();
                TempData["message"] = $"{employee.FullName} added to Employees.";
                return RedirectToAction("Index");  
            }
            else {
                return View("Employee", employee);
            }
        }

        [HttpGet]
        public ViewResult Edit(int id) => View("Employee", data.Get(id));

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid) {
                data.Update(employee);
                data.Save();
                TempData["message"] = $"{employee.FullName} updated.";
                return RedirectToAction("Index");  
            }
            else {
                return View("Employee", employee);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = data.Get(new QueryOptions<Employee> {
                Include = "VehicleEmployees",
                Where = a => a.EmployeeId == id
            });

            if (employee.VehicleEmployees.Count > 0) {
                TempData["message"] = $"Can't delete author {employee.FullName} because they are associated with these vehicles.";
                return GoToEmployeeSearch(employee);
            }
            else {
                return View("Employee", employee);
            }
        }

        [HttpPost]
        public RedirectToActionResult Delete(Employee author)
        {
            data.Delete(author);
            data.Save();
            TempData["message"] = $"{author.FullName} removed from Employees.";
            return RedirectToAction("Index");  
        }

        public RedirectToActionResult ViewVehicles(int id)
        {
            var author = data.Get(id);
            return GoToEmployeeSearch(author);
        }

        private RedirectToActionResult GoToEmployeeSearch(Employee employee)
        {
            var search = new SearchData(TempData) {
                SearchTerm = employee.FullName,
                Type = "employee"
            };
            return RedirectToAction("Search", "Vehicle");
        }
    }
}