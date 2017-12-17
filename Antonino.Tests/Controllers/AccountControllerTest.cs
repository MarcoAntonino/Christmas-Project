using Antonino.Classes;
using Antonino.Controllers;
using Antonino.Infrastructure.Abstract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Web.Mvc;

namespace Antonino.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A null IAuthProvider object argument was inappropriately allowed")]
        public void AccountController_Should_Throw_Exception_When_IAuthProvider_Argument_Is_Null()
        {
            // Arrange
            AccountController controller;
            Mock<IDataBase> IDataBaseMock = new Mock<IDataBase>();
            // Act
            controller = new AccountController(null, IDataBaseMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A null IDataBase object argument was inappropriately allowed")]
        public void AccountController_Should_Throw_Exception_When_IDataBase_Argument_Is_Null()
        {
            // Arrange
            AccountController controller;
            Mock<IAuthProvider> authProviderMock = new Mock<IAuthProvider>();
            // Act
            controller = new AccountController(authProviderMock.Object, null);
        }        

        [TestMethod]
        public void Login_Should_Return_A_View()
        {
            // Arrange
            Mock<IAuthProvider> authProviderMock = new Mock<IAuthProvider>();
            Mock<IDataBase> IDataBaseMock = new Mock<IDataBase>();

            AccountController controller = new AccountController(authProviderMock.Object, IDataBaseMock.Object);

            // Act
            ViewResult result = controller.Login() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }        
    }
}
