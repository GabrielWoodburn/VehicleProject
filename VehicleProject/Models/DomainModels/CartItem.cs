using Newtonsoft.Json;

namespace VehicleProject.Models
{
    public class CartItem
    {
        public VehicleDTO Vehicle { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        public double Subtotal => Vehicle.Price * Quantity;
    }
}
