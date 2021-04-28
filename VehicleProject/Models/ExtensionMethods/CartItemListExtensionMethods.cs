using System.Linq;
using System.Collections.Generic;

namespace VehicleProject.Models
{
    public static class CartItemListExtensions
    {
        public static List<CartItemDTO> ToDTO(this List<CartItem> list) =>
            list.Select(ci => new CartItemDTO {
                VehicleId = ci.Vehicle.VehicleId,
                Quantity = ci.Quantity
            }).ToList();
    }
}
