using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace VehicleProject.Models
{
    public class SearchData
    {
        private const string SearchKey = "search";
        private const string TypeKey = "searchtype";

        private ITempDataDictionary tempData { get; set; }
        public SearchData(ITempDataDictionary temp) =>
            tempData = temp;

        public string SearchTerm
        {
            get => tempData.Peek(SearchKey)?.ToString();
            set => tempData[SearchKey] = value;
        }
        public string Type
        {
            get => tempData.Peek(TypeKey)?.ToString();
            set => tempData[TypeKey] = value;
        }

        public bool HasSearchTerm => !string.IsNullOrEmpty(SearchTerm);
        public bool IsVehicle => Type.EqualsNoCase("vehicle");
        public bool IsEmployee => Type.EqualsNoCase("employee");
        public bool IsVehicleType => Type.EqualsNoCase("vehicleType");

        public void Clear()
        {
            tempData.Remove(SearchKey);
            tempData.Remove(TypeKey);
        }
    }
}
