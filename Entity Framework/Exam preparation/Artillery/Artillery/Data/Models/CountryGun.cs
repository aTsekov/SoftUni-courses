﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artillery.Data.Models
{
    public class CountryGun
    {
        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }

        public Country Country { get; set; } = null!;

        [ForeignKey(nameof(Gun))]
        public int GunId { get; set; }

        public Gun Gun { get; set; } = null!;
    }
}
