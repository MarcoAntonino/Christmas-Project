using Antonino.Classes;
using Antonino.Controllers;
using Antonino.Tests.Mocks;
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Update_Order_Should_Throw_Exception_When_id_Is_Null()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.UpdateOrder(It.Is<string>(id => id == null), It.IsAny<OrderStatus>())).Throws<ArgumentNullException>();

            MockOrderController mockController = new MockOrderController(mock.Object) { };

            mockController.UpdateNullId();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Update_Order_Should_Throw_Exception_When_id_Is_Empty()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.UpdateOrder(It.Is<string>(id => id == string.Empty), It.IsAny<OrderStatus>())).Throws<ArgumentException>();            

            MockOrderController mockController = new MockOrderController(mock.Object) { };

            mockController.UpdateEmptyId();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Update_Order_Should_Throw_Exception_When_id_Is_Whitespaced()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();            
            mock.Setup(m => m.UpdateOrder(It.Is<string>(id => id == " "), It.IsAny<OrderStatus>())).Throws<ArgumentException>();

            MockOrderController mockController = new MockOrderController(mock.Object) { };

            mockController.UpdateWhitespacedId();
        }
    }
}
