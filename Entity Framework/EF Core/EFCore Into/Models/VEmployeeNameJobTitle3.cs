using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Into.Models
{
    [Keyless]
    public partial class VEmployeeNameJobTitle3
    {
        [Column("Full Name")]
        [StringLength(152)]
        [Unicode(false)]
        public string FullName { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string JobTitle { get; set; } = null!;
    }
}
