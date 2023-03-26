using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Footballers.DataProcessor.ImportDto
{
    public class ImportFootballersInTeam
    {
        [JsonProperty("Footballers")]
        public int Id { get; set; }
    }
}
