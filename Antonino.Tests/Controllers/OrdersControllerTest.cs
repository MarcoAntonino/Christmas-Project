using Antonino.Classes;
using Antonino.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using Moq;
using System;
using System.Web.Mvc;

namespace Antonino.Tests.Controllers
{
    [TestClass]
    public class OrdersControllerTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A null IDataBase object argument was inappropriately allowed")]
        public void OrdersController_Should_Throw_Exception_When_IDataBase_Argument_Is_Null()
        {
            // Arrange
            OrdersController controller;
            Mock<IDataBase> IDataBaseMock = new Mock<IDataBase>();
            // Act
            controller = new OrdersController(null);
        }

        [TestMethod]
        public void Index_Should_Return_A_View()
        {
            // Arrange
            Mock<IDataBase> IDataBaseMock = new Mock<IDataBase>();

            OrdersController controller = new OrdersController(IDataBaseMock.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Details_Should_Return_A_View()
        {
            // Arrange
            Mock<IDataBase> IDataBaseMock = new Mock<IDataBase>();
            OrdersController controller = new OrdersController(IDataBaseMock.Object);
            string idTest = ObjectId.GenerateNewId().ToString();

            // Act
            ViewResult result = controller.Details(idTest) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Edit_Should_Return_A_View()
        {
            // Arrange
            Mock<IDataBase> IDataBaseMock = new Mock<IDataBase>();
            OrdersController controller = new OrdersController(IDataBaseMock.Object);
            string idTest = ObjectId.GenerateNewId().ToString();

            // Act
            ViewResult result = controller.Edit(idTest) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
