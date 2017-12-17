using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Antonino.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antonino.Tests
{
    /*
     * In this ClassTest I will test only the methods that does not require a connection.
     * I'll check the test that requires connection only in the Tests.Integration cause it seems useless to me creating another mock, as we did in Savings project. In fact I've already created and tested a mock of IDataBase in the IDataBaseTest class.
     */
    [TestClass]
    public class MongoDBTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "A null idParam argument was inappropriately allowed.")]
        public void IdChecker_Should_Throw_Exception_When_idParam_Is_Null()
        {
            // arrange
            Classes.MongoDB db = new Classes.MongoDB();

            // act
            db.IdChecker(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "A empty idParam argument was inappropriately allowed.")]
        public void IdChecker_Should_Throw_Exception_When_idParam_Is_Empty()
        {
            // arrange
            Classes.MongoDB db = new Classes.MongoDB();

            // act
            db.IdChecker(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "A empty idParam argument was inappropriately allowed.")]
        public void IdChecker_Should_Throw_Exception_When_idParam_Is_WhiteSpaced()
        {
            // arrange
            Classes.MongoDB db = new Classes.MongoDB();

            // act
            db.IdChecker("  ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A out of range statusParam argument was inappropriately allowed.")]
        public void OrderStatusChecker_Should_Throw_Exception_When_statusParam_is_Out_Of_Range()
        {
            // arrange
            Classes.MongoDB db = new Classes.MongoDB();

            // act
            db.OrderStatusChecker((OrderStatus)77);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A null objectParam argument was inappropriately allowed.")]
        public void GetParamChecker_Should_Throw_Exception_When_objectParam_Is_Null()
        {
            // arrange
            Classes.MongoDB db = new Classes.MongoDB();

            // act
            db.GetParamChecker(null);
        }
    }
}
