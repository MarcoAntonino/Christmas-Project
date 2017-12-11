using Antonino.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Antonino.Controllers
{
    public class OrderController : Controller
    {
        private IDataBase db;

        public OrderController(IDataBase dbParam)
        {
            db = dbParam;
        }

        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
        
    }
}