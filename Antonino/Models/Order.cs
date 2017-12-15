using Antonino.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antonino.Models
{
    public class Order
    {
        public string ID { get; set; }

        public string Kid { get; set; }

        public OrderStatus Status { get; set; }

        public List<OrderedToy> OrderedToys { get; set; }

        public int TotalOrderdToys { get; set; }

        public DateTime RequestDate { get; set; }
    }
}