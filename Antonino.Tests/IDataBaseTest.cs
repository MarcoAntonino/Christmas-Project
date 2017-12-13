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

            mock.Object.UpdateOrder(null, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Update_Order_Should_Throw_Exception_When_id_Is_Empty()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.UpdateOrder(It.Is<string>(id => id == string.Empty), It.IsAny<OrderStatus>())).Throws<ArgumentException>();

            mock.Object.UpdateOrder(string.Empty, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Update_Order_Should_Throw_Exception_When_id_Is_Whitespaced()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();            
            mock.Setup(m => m.UpdateOrder(It.Is<string>(id => string.IsNullOrWhiteSpace(id) == true), It.IsAny<OrderStatus>())).Throws<ArgumentException>();

            mock.Object.UpdateOrder("  ", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Update_Order_Should_Throw_Exception_When_Status_Is_Out_Of_Range()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.UpdateOrder(It.IsAny<string>(), It.Is<OrderStatus>(s => s < (OrderStatus)0 || s > Enum.GetValues(typeof(OrderStatus)).Cast<OrderStatus>().Last()))).Throws<ArgumentOutOfRangeException>();

            mock.Object.UpdateOrder("  ", (OrderStatus)(-1));
        }

        [TestMethod]
        public void GetAllOrders_Should_Return_An_IEnumerable_Of_Order()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetAllOrders()).Returns(new List<Order>());

            var results = mock.Object.GetAllOrders();

            Assert.IsInstanceOfType(results, typeof(IEnumerable<Order>));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetOrder_Should_Throw_Exception_When_id_Is_Null()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetOrder(It.Is<string>(id => id == null))).Throws<ArgumentNullException>();

            mock.Object.GetOrder(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetOrder_Should_Throw_Exception_When_id_Is_Empty()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetOrder(It.Is<string>(id => id == string.Empty))).Throws<ArgumentException>();

            mock.Object.GetOrder(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetOrder_Should_Throw_Exception_When_id_Is_Whitespaced()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetOrder(It.Is<string>(id => string.IsNullOrWhiteSpace(id) == true))).Throws<ArgumentException>();

            mock.Object.GetOrder("  ");
        }

        [TestMethod]
        public void GetOrder_Should_Return_An_Object_Of_Type_Order()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetOrder(It.IsAny<string>())).Returns(new Order());

            Order result = mock.Object.GetOrder("test");

            Assert.IsInstanceOfType(result, typeof(Order));
        }

        [TestMethod]
        public void GetAllToys_Should_Return_An_IEnumerable_Of_Toy()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetAllToys()).Returns(new List<Toy>());

            var results = mock.Object.GetAllToys();

            Assert.IsInstanceOfType(results, typeof(IEnumerable<Toy>));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetUser_Should_Throw_Exception_When_id_Is_Null()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetUser(It.Is<string>(id => id == null))).Throws<ArgumentNullException>();

            mock.Object.GetUser(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetUser_Should_Throw_Exception_When_id_Is_Empty()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetUser(It.Is<string>(id => id == string.Empty))).Throws<ArgumentException>();

            mock.Object.GetUser(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetUser_Should_Throw_Exception_When_id_Is_Whitespaced()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetUser(It.Is<string>(id => string.IsNullOrWhiteSpace(id) == true))).Throws<ArgumentException>();

            mock.Object.GetUser("  ");
        }

        [TestMethod]
        public void GetUser_Should_Return_An_Object_Of_Type_User()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetUser(It.IsAny<string>())).Returns(new User());

            User result = mock.Object.GetUser("test");

            Assert.IsInstanceOfType(result, typeof(User));
        }
    }
}
