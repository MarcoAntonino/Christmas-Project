﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antonino.Models
{
    public class OrderedToy
    {
        public string Name { get; set; }

        public int DesiredQuantity { get; set; }

        public int Amount { get; set; }

        public decimal Cost { get; set; }

    }
}