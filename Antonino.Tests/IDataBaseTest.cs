using Antonino.Classes;
using Antonino.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Antonino.Tests
{
    [TestClass]
    public class IDataBaseTest
    {
        public class MockOrderController : Controller
        {
            private IDataBase db;

            public MockOrderController(IDataBase dbParam)
            {
                db = dbParam;
            }

            public ActionResult Update()
            {
                db.UpdateOrder(null, 0);
                return View();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Update_Order_Should_Throw_Exception_When_id_Is_Null()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.UpdateOrder(It.Is<string>(id => id == string.Empty), It.IsAny<OrderStatus>())).Throws<ArgumentNullException>();

            MockOrderController mockController = new MockOrderController(mock.Object) { };

            mockController.Update();
        }
    }
}
