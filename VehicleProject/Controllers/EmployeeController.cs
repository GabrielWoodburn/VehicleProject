using Microsoft.AspNetCore.Mvc;
using VehicleProject.Models;

namespace VehicleProject.Controllers
{
    public class EmployeeController : Controller
    {
        private Repository<Employee> data { get; set; }
        public EmployeeController(VehicleProjectContext ctx) => data = new Repository<Employee>(ctx);

        public IActionResult Index() => RedirectToAction("List");

        public ViewResult List(GridDTO vals)
        {
            string defaultSort = nameof(Employee.FirstName);
            var builder = new GridBuilder(HttpContext.Session, vals, defaultSort);
            builder.SaveRouteSegments();

            var options = new QueryOptions<Employee> {
                Include = "VehicleEmployees.Vehicle",
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize,
                OrderByDirection = builder.CurrentRoute.SortDirection
            };
            if (builder.CurrentRoute.SortField.EqualsNoCase(defaultSort))
                options.OrderBy = a => a.FirstName;
            else
                options.OrderBy = a => a.LastName;

            var vm = new AuthorListViewModel {
                Employees = data.List(options),
                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(data.Count)
            };

            return View(vm);
        }

        public IActionResult Details(int id)
        {
            var author = data.Get(new QueryOptions<Employee> {
                Include = "VehicleEmployees.Vehicle",
                Where = a => a.EmployeeId == id
            });
            return View(author);
        }
    }
}