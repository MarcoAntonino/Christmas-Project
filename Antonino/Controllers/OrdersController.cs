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

        public OrdersController(IDataBase dbArg)
        {
            db = dbArg ?? throw new ArgumentNullException();
        }

        // GET: Order
        public ActionResult Index()
        {
            IEnumerable<Classes.Order> orders = db.GetAllOrders();
            Orders model = new Orders();
            foreach (Classes.Order order in orders)
            {
                Models.Order orderModel = new Models.Order();
                orderModel.ID = order.ID;
                orderModel.Kid = order.Kid;
                orderModel.Status = order.Status;
                orderModel.RequestDate = order.RequestDate;                
                orderModel.OrderedToys = populateToysList(order.Toys);
                foreach (OrderedToy toy in orderModel.OrderedToys)
                {
                    orderModel.totalCost += toy.Cost * toy.DesiredQuantity;
                }                
                model.EntityList.Add(orderModel);
            }
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
            model.TotalOrderdToys = model.OrderedToys.Sum(t => t.DesiredQuantity);
            return View(model);
        }

        private List<OrderedToy> populateToysList (List<Toy> Toys)
        {            
            List<OrderedToy> returnList = new List<OrderedToy>();
            IEnumerable<Toy> catalog = db.GetAllToys();
            foreach (Toy requestedToy in Toys)
            {
                if (returnList.Find(t => t.Name == requestedToy.Name) == null)
                {
                    Toy model = catalog.ToList().Find(t => t.Name == requestedToy.Name);
                    returnList.Add(new OrderedToy { Name = requestedToy.Name, DesiredQuantity = 1, Amount = model.Amount , Cost = model.Cost});
                }
                else
                {
                    returnList.Where(t => t.Name == requestedToy.Name).ToList().ForEach(t => t.DesiredQuantity++);
                }
            }
            return returnList;
        }

        public ActionResult Edit(string id)
        {
            Classes.Order order= db.GetOrder(id);
            try
            {
                checkStorageAvailability(order);
            }
            catch (NotEnoughToysInStorageException)
            {
                return RedirectToAction("Details", new { id = id });
            }
            Models.Order model = new Models.Order();
            model.ID = order.ID;
            model.Status = order.Status;
            return View(model);
        }

        public ActionResult Save(string id, OrderStatus status)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new MissingFieldException("Invalid Order id ");
            }
            bool result = db.UpdateOrder(id, status);
            return RedirectToAction("Index", new { result = result });
        }

        private void checkStorageAvailability(Classes.Order orderToControl)
        {           
            Models.Order model = new Models.Order();
            model.OrderedToys = populateToysList(orderToControl.Toys);
            bool isOrderedEditable = true;
            foreach (OrderedToy toy in model.OrderedToys)
            {
                if (toy.DesiredQuantity > toy.Amount)
                {
                    isOrderedEditable = false;
                }
            }

            if (!isOrderedEditable)
            {
                throw new NotEnoughToysInStorageException("There are no enough toys in the storage. Check order details for more info");
            }

        }
        
    }
}