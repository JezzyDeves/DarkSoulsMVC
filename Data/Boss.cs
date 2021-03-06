﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Boss
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Health { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Weakness { get; set; }
        [Required]
        public string Tips { get; set; }

        public int LocationID { get; set; }
        [ForeignKey(nameof(LocationID))]
        public virtual Location Location { get; set; }

    }
}
