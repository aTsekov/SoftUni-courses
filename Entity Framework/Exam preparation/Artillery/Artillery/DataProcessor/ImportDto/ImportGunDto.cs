using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Artillery.DataProcessor.ImportDto
{
    public class ImportGunDto
    {
        [JsonProperty("ManufacturerId")]
        [Required]
        public int ManufacturerId { get; set; }

        [JsonProperty("GunWeight")]
        [Range(100, 1_350_000)]
        [Required]
        public int GunWeight { get; set; }

        
        [JsonProperty("BarrelLength")]
        [Range(2.00, 35.00)]
        [Required]
        public double BarrelLength { get; set; }

        [JsonProperty("NumberBuild")]
        public int? NumberBuild { get; set; }


        [JsonProperty("Range")]
        [Range(1, 100_000)]
        [Required]
        public int Range { get; set; }

        [JsonProperty("GunType")]
        [Required]
        public string GunType { get; set; } = null!;

        [JsonProperty("ShellId")]
        [Required]
        public int ShellId { get; set; }

        [JsonProperty("Countries")]
        public ImportCountryIdDto[] Countries { get; set; } = null!;
    }
}
