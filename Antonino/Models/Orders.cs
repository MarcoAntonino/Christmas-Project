using Antonino.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antonino.Models
{
    public class Orders
    {
        public List<Order> EntityList { get; private set; }

        public Orders()
        {
            EntityList = new List<Order>();
        }
    }
}