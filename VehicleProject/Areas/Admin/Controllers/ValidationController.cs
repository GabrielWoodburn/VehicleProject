using Microsoft.AspNetCore.Mvc;
using VehicleProject.Models;

namespace VehicleProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ValidationController : Controller
    {
        private Repository<Employee> authorData { get; set; }
        private Repository<VehicleType> genreData { get; set; }

        public ValidationController(VehicleProjectContext ctx)
        { 
            authorData = new Repository<Employee>(ctx);
            genreData = new Repository<VehicleType>(ctx);
        }

        public JsonResult CheckGenre(string genreId)
        {
            var validate = new Validate(TempData);
            validate.CheckGenre(genreId, genreData);
            if (validate.IsValid) {
                validate.MarkGenreChecked();
                return Json(true);
            }
            else {
                return Json(validate.ErrorMessage);
            }
        }

        public JsonResult CheckAuthor(string firstName, string lastName, string operation)
        {
            var validate = new Validate(TempData);
            validate.CheckAuthor(firstName, lastName, operation, authorData);
            if (validate.IsValid) {
                validate.MarkAuthorChecked();
                return Json(true);
            }
            else {
                return Json(validate.ErrorMessage);
            }
        }
    }
}