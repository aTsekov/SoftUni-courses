using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CarDealer.DTOs.Import
{
    public class ImportCustomersDto
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;
        [JsonProperty("birthDate")]
        public string Birthday  { get; set; } = null!;

        [JsonProperty("isYoungDriver")]
        public bool IsYoungDriver { get; set; }

   
    }
}
