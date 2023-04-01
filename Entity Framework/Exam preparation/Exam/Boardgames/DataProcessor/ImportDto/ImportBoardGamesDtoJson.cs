using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Boardgames.DataProcessor.ImportDto
{
    public class ImportBoardGamesDtoJson
    {
        [JsonProperty("Boardgames")]
        public int Id { get; set; }
    }
}
