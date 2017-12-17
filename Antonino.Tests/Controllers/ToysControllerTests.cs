using Antonino.Classes;
using Antonino.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Web.Mvc;

namespace Antonino.Tests.Controllers
{
    [TestClass]
    public class ToysControllerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A null IDataBase object argument was inappropriately allowed")]
        public void ToysController_Should_Throw_Exception_When_IDataBase_Argument_Is_Null()
        {
            // Arrange
            ToysController controller;
            Mock<IDataBase> IDataBaseMock = new Mock<IDataBase>();
            // Act
            controller = new ToysController(null);
        }

        [TestMethod]
        public void Index_Should_Return_A_View()
        {
            // Arrange
            Mock<IDataBase> IDataBaseMock = new Mock<IDataBase>();

            ToysController controller = new ToysController(IDataBaseMock.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
