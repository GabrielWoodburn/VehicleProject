using System.Collections.Generic;

namespace VehicleProject.Models
{
    public class CartViewModel 
    {
        public IEnumerable<CartItem> List { get; set; }
        public double Subtotal { get; set; }
        public RouteDictionary VehicleGridRoute { get; set; }
    }
}
