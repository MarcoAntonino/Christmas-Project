using Antonino.Classes;
using Antonino.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Antonino.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private IDataBase db;

        public OrdersController(IDataBase dbParam)
        {
            db = dbParam;
        }

        // GET: Order
        public ActionResult Index()
        {
            var orders = db.GetAllOrders();
            Orders model = new Orders();
            model.EntityList.AddRange(orders.ToList());
            return View(model);
        }

        public ActionResult Details(string id)
        {
            var order = db.GetOrder(id);
            Order model = order;
            return View(model);
        }
        
    }
}