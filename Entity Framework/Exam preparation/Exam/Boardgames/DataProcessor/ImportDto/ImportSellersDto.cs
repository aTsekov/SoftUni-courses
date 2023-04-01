using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Boardgames.DataProcessor.ImportDto
{
    public class ImportSellersDto
    {
        [JsonProperty("Name")]
        [Required]
        [MaxLength(20)]
        [MinLength(5)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(2)]
        [JsonProperty("Address")]
        public string Address { get; set; }

        [Required]
        [JsonProperty("Country")]
        public string Country { get; set; }

        [Required]
        [JsonProperty("Website")]
        [RegularExpression(@"^www\.[a-zA-Z0-9\-]+\.com$")]
        public string Website { get; set; }

        [JsonProperty("Boardgames")] 
        public List<int> Boardgames { get; set; } = new List<int>();
    }
}
