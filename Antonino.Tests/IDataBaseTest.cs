using Antonino.Classes;
using Antonino.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antonino.Tests
{
    class IDataBaseTest
    {       

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Update_Order_Should_Throw_Exception_When_id_Is_Null()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.UpdateOrder(It.Is<string>(id => id == null), It.IsAny<OrderStatus>())).Throws<ArgumentNullException>();

            var controller = new OrderController(mock.Object);

            controller.
        }
    }
}
