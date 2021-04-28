using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using VehicleProject.Models;

namespace VehicleProject.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private Repository<Vehicle> data { get; set; }
        public CartController(VehicleProjectContext ctx) => data = new Repository<Vehicle>(ctx);


        private Cart GetCart()
        {
            var cart = new Cart(HttpContext);
            cart.Load(data);
            return cart;
        }

        public ViewResult Index() 
        {
            var cart = GetCart();
            var builder = new VehiclesGridBuilder(HttpContext.Session);

            var vm = new CartViewModel {
                List = cart.List,
                Subtotal = cart.Subtotal,
                VehicleGridRoute = builder.CurrentRoute
            };
            return View(vm);
        }

        [HttpPost]
        public RedirectToActionResult Add(int id)
        {
            var book = data.Get(new QueryOptions<Vehicle> {
                Include = "VehicleEmployees.Employee, VehicleType",
                Where = b => b.VehicleId == id
            });
            if (book == null){
                TempData["message"] = "Unable to add vehicle to list.";   
            }
            else {
                var dto = new VehicleDTO();
                dto.Load(book);
                CartItem item = new CartItem {
                    Vehicle = dto,
                    Quantity = 1  // default value
                };

                Cart cart = GetCart();
                cart.Add(item);
                cart.Save();

                TempData["message"] = $"{book.Title} added to list";
            }

            var builder = new VehiclesGridBuilder(HttpContext.Session);
            return RedirectToAction("List", "Vehicle", builder.CurrentRoute);
        }

        [HttpPost]
        public RedirectToActionResult Remove(int id)
        {
            Cart cart = GetCart();
            CartItem item = cart.GetById(id);
            cart.Remove(item);
            cart.Save();

            TempData["message"] = $"{item.Vehicle.Title} removed from list.";
            return RedirectToAction("Index");
        }
                
        [HttpPost]
        public RedirectToActionResult Clear()
        {
            Cart list = GetCart();
            list.Clear();
            list.Save();

            TempData["message"] = "List cleared.";
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            Cart cart = GetCart();
            CartItem item = cart.GetById(id);
            if (item == null)
            {
                TempData["message"] = "Unable to locate list item";
                return RedirectToAction("List");
            }
            else
            {
                return View(item);
            }
        }

        [HttpPost]
        public RedirectToActionResult Edit(CartItem item)
        {
            Cart list = GetCart();
            list.Edit(item);
            list.Save();

            TempData["message"] = $"{item.Vehicle.Title} updated";
            return RedirectToAction("Index");
        }

        public ViewResult Checkout() => View();
    }
}