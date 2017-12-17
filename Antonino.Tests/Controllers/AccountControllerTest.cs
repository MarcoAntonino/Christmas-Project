using Antonino.Classes;
using Antonino.Controllers;
using Antonino.Infrastructure.Abstract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Antonino.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {        
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
