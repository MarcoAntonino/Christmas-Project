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

        public ActionResult UpdateNullId()
        {
            db.UpdateOrder(null, 0);
            return View();
        }

        public ActionResult UpdateEmptyId()
        {
            db.UpdateOrder("", 0);
            return View();
        }

        public ActionResult UpdateWhitespacedId()
        {
            db.UpdateOrder(" ", 0);
            return View();
        }
    }
}
