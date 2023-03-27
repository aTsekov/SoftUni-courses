using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Footballers.DataProcessor.ExportDto
{
    public class ExportFootballersDto
    {
        [JsonProperty("FootballerName")]
        public string FootballerName { get; set; } = null!;

        [JsonProperty("ContractStartDate")]
        public string ContractStartDate { get; set; } = null!;

        [JsonProperty("ContractEndDate")]

        public string ContractEndDate { get; set; } = null!;

        [JsonProperty("BestSkillType")]

        public string BestSkillType { get; set; } = null!;


        [JsonProperty("PositionType")]
        public string PositionType { get; set; } = null!;
    }
}
