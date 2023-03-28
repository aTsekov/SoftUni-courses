using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Manufacturer")]
    public class ImportManufacturerDto
    {
        [XmlElement("ManufacturerName")]
        [MaxLength(40)]
        [MinLength(4)]
        [Required]
        public string ManufacturerName { get; set; } = null!;


        [XmlElement("Founded")]
        [MaxLength(100)]
        [MinLength(10)]
        [Required]
        public string Founded { get; set; } = null!;
    }
}
