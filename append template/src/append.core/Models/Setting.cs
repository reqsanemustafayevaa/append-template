﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace append.core.Models
{
    public class Setting:BaseEntity
    {
        [Required]
        [StringLength(60)]
        public string Value { get; set; }
       
        [StringLength(30)]
        public string? Key {  get; set; }
       
    }
}
