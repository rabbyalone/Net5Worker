﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.Worker.Models
{
    public class Country
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Border { get; set; }
        public string[] Languages { get; set; }
    }
}
