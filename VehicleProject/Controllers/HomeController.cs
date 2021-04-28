using System;
using Microsoft.AspNetCore.Mvc;
using VehicleProject.Models;

namespace VehicleProject.Controllers
{
    public class HomeController : Controller
    {
        private Repository<Vehicle> data { get; set; }
        public HomeController(VehicleProjectContext ctx) => data = new Repository<Vehicle>(ctx);

        public ViewResult Index()
        {
            var random = data.Get(new QueryOptions<Vehicle> {
                OrderBy = b => Guid.NewGuid()
            });

            return View(random);
        }
    }
}