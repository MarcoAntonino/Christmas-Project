using Antonino.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Antonino.Tests.Mocks
{
    public class MockOrderController : Controller
    {
        private IDataBase db;

        public MockOrderController(IDataBase dbParam)
        {
            db = dbParam;
        }

        public ActionResult Update(string id, OrderStatus status)
        {
            db.UpdateOrder(id, status);
            return View();
        }
    }
}
