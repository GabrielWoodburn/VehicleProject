using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using VehicleProject.Models;

namespace VehicleProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class VehicleTypeController : Controller
    {
        private Repository<VehicleType> data { get; set; }
        public VehicleTypeController(VehicleProjectContext ctx) => data = new Repository<VehicleType>(ctx);

        public ViewResult Index()
        {
            var search = new SearchData(TempData);
            search.Clear();

            var genres = data.List(new QueryOptions<VehicleType> {
                OrderBy = g => g.Name
            });
            return View(genres);
        }

        [HttpGet]
        public ViewResult Add() => View("VehicleType", new VehicleType());

        [HttpPost]
        public IActionResult Add(VehicleType vehicleType)
        {
            var validate = new Validate(TempData);
            if (!validate.IsVehicleTypeChecked) {
                validate.CheckVehicleType(vehicleType.VehicleTypeId, data);
                if (!validate.IsValid) {
                    ModelState.AddModelError(nameof(vehicleType.VehicleTypeId), validate.ErrorMessage);
                }     
            }

            if (ModelState.IsValid) {
                data.Insert(vehicleType);
                data.Save();
                validate.ClearVehicleType();
                TempData["message"] = $"{vehicleType.Name} added to VehicleTypes.";
                return RedirectToAction("Index");  
            }
            else {
                return View("VehicleType", vehicleType);
            }
        }

        [HttpGet]
        public ViewResult Edit(string id) => View("VehicleType", data.Get(id));

        [HttpPost]
        public IActionResult Edit(VehicleType vehicleType)
        {
            if (ModelState.IsValid) {
                data.Update(vehicleType);
                data.Save();
                TempData["message"] = $"{vehicleType.Name} updated.";
                return RedirectToAction("Index");  
            }
            else {
                return View("VehicleType", vehicleType);
            }
        }

        [HttpGet]
        public IActionResult Delete(string id) {
            var vehicleType = data.Get(new QueryOptions<VehicleType> {
                Include = "Vehicles",
                Where = g => g.VehicleTypeId == id
            });

            if (vehicleType.Vehicles.Count > 0) {
                TempData["message"] = $"Can't delete vehicleType {vehicleType.Name} " 
                                    + "because it's associated with these vehicles.";
                return GoToVehicleSearchResults(id);
            }
            else {
                return View("VehicleType", vehicleType);
            }
        }

        [HttpPost]
        public IActionResult Delete(VehicleType vehicleType)
        {
            data.Delete(vehicleType);
            data.Save();
            TempData["message"] = $"{vehicleType.Name} removed from VehicleTypes.";
            return RedirectToAction("Index"); 
        }

        public RedirectToActionResult ViewBooks(string id) => GoToVehicleSearchResults(id);

        private RedirectToActionResult GoToVehicleSearchResults(string id)
        {
            var search = new SearchData(TempData) {
                SearchTerm = id,
                Type = "vehicleType"
            };
            return RedirectToAction("Search", "Vehicle");
        }

    }
}