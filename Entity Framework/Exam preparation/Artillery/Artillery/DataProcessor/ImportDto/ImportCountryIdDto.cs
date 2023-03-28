using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Artillery.DataProcessor.ImportDto
{
    public class ImportCountryIdDto
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
    }
}
