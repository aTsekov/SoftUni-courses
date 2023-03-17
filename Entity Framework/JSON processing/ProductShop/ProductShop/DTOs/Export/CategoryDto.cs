using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProductShop.DTOs.Export
{
    public class CategoryDto
    {
        [JsonProperty("category")] 
        public string CategoryName { get; set; } = null!;

        [JsonProperty("productsCount")]
        public int ProductCount { get; set; }

        [JsonProperty("averagePrice")]
        public string  AveragePrice { get; set; } = null!;

        [JsonProperty("totalRevenue")]
        public string TotalRevenue { get; set; } = null!;

    }
}
