using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Country")]
    public class ImportCountryDto
    {
        [XmlElement("CountryName")]
        [MaxLength(60)]
        [MinLength(4)]
        [Required]
        public string CountryName { get; set; } = null!;

        [XmlElement("ArmySize")]
        [Range(50_000,10_000_000)]
        [Required]
        public int ArmySize { get; set; }
    }
}
