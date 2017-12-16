using Antonino.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antonino.Models
{
    public class Orders
    {
        public List<Models.Order> EntityList { get; private set; }

        public Orders()
        {
            EntityList = new List<Models.Order>();
        }
    }
}