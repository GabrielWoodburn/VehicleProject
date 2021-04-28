using Microsoft.AspNetCore.Mvc;
using VehicleProject.Models;

namespace VehicleProject.Controllers
{
    public class VehicleController : Controller
    {
        private VehicleProjectUnitOfWork data { get; set; }
        public VehicleController(VehicleProjectContext ctx) => data = new VehicleProjectUnitOfWork(ctx);

        public RedirectToActionResult Index() => RedirectToAction("List");

        public ViewResult List(VehiclesGridDTO values)
        {
            var builder = new VehiclesGridBuilder(HttpContext.Session, values, 
                defaultSortField: nameof(Vehicle.Title));

            var options = new VehicleQueryOptions {
                Include = "VehicleEmployees.Employee, VehicleType",
                OrderByDirection = builder.CurrentRoute.SortDirection,
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize
            };
            options.SortFilter(builder);

            var vm = new VehicleListViewModel {
                Vehicles = data.Vehicles.List(options),
                Employees = data.Employees.List(new QueryOptions<Employee> {
                    OrderBy = a => a.FirstName }),
                VehicleTypes = data.VehicleTypes.List(new QueryOptions<VehicleType> {
                    OrderBy = g => g.Name }),
                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(data.Vehicles.Count)
            };

            return View(vm);
        }

        public ViewResult Details(int id)
        {
            var book = data.Vehicles.Get(new QueryOptions<Vehicle> {
                Include = "VehicleEmployees.Employee, VehicleType",
                Where = b => b.VehicleId == id
            });
            return View(book);
        }

        [HttpPost]
        public RedirectToActionResult Filter(string[] filter, bool clear = false)
        {
            var builder = new VehiclesGridBuilder(HttpContext.Session);

            if (clear) {
                builder.ClearFilterSegments();
            }
            else {
                var author = data.Employees.Get(filter[0].ToInt());
                builder.LoadFilterSegments(filter, author);
            }

            builder.SaveRouteSegments();
            return RedirectToAction("List", builder.CurrentRoute);
        }
    }   
}