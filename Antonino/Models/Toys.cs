using Antonino.Classes;
using System.Collections.Generic;

namespace Antonino.Models
{
    public class Toys
    {
        public List<Toy> EntityList { get; private set; }

        public Toys()
        {
            EntityList = new List<Toy>();
        }
    }
}