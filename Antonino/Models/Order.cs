using Antonino.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime RequestDate { get; set; }

        public decimal totalCost { get; set; }   
    }
}