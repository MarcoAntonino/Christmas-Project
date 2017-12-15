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
            IEnumerable<Classes.Order> orders = db.GetAllOrders();
            Orders model = new Orders();
            model.EntityList.AddRange(orders.ToList());
            return View(model);
        }

        public ActionResult Details(string id)
        {
            Classes.Order order = db.GetOrder(id);
            Models.Order model = new Models.Order();
            model.ID = order.ID;
            model.Kid = order.Kid;
            model.Status = order.Status;
            model.RequestDate = order.RequestDate;
            model.OrderedToys = populateToysList(order.Toys);
            model.TotalOrderdToys = model.OrderedToys.Sum(t => t.Quantity);
            return View(model);
        }

        private List<OrderedToy> populateToysList (List<Toy> Toys)
        {
            
            List<OrderedToy> returnList = new List<OrderedToy>();
            foreach (Toy requestedToy in Toys)
            {
                if (returnList.Find(t => t.Name == requestedToy.Name) == null)
                {                    
                    returnList.Add(new OrderedToy { Name = requestedToy.Name, Quantity = 1, Amount = db.GetToy(requestedToy).Amount });
                }
                else
                {
                    returnList.Where(t => t.Name == requestedToy.Name).ToList().ForEach(t => t.Quantity++);
                }
            }
            return returnList;
        }
        
    }
}