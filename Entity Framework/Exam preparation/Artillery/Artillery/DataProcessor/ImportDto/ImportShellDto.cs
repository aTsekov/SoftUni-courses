using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Shell")]
    public class ImportShellDto
    {
        [XmlElement("ShellWeight")]
        [Range(2, 1_680)]
        [Required]
        public double ShellWeight { get; set; }

        [MaxLength(30)]
        [MinLength(4)]
        [Required]
        [XmlElement("Caliber")] public string Caliber { get; set; } = null!;

    }
}
