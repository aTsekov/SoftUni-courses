using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProductShop.DTOs.Export
{
    public class ExportProductDto
    {
        [JsonProperty("name")]
        public string ProductName { get; set; } = null!;

        [JsonProperty("price")]
        public decimal ProductPrice { get; set; }

        [JsonProperty("seller")]
        public string SellerName { get; set; } = null!;

    }
}
