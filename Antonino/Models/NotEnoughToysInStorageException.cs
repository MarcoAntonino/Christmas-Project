using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antonino.Models
{
    public class NotEnoughToysInStorageException : Exception
    {
        public NotEnoughToysInStorageException(string message) : base(message)
        {

        }

        public NotEnoughToysInStorageException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}