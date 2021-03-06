﻿using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BossModels
{
    public class BossDetail
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public string Description { get; set; }
        public string Weakness { get; set; }
        public string Tips { get; set; }
        public int LocationID { get; set; }
        public Location Location { get; set; }
    }
}
