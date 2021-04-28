using Newtonsoft.Json;

namespace VehicleProject.Models
{
    public class VehiclesGridDTO : GridDTO
    {
        [JsonIgnore]
        public const string DefaultFilter = "all";

        public string Employee { get; set; } = DefaultFilter;
        public string VehicleType { get; set; } = DefaultFilter;
        public string Price { get; set; } = DefaultFilter;
    }
}
