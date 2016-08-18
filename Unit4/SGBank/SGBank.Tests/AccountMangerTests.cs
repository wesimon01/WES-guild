using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGBank.BLL;
using SGBank.Data;

namespace SGBank.Tests
{
    [TestFixture]
    public class AccountMangerTests
    {
        [Test]
        public void FoundAccountReturnsSuccess()
        {
            var manager = new AccountManager();

            var response = manager.GetAccount(1);

            Assert.IsTrue(response.Success);
            Assert.AreEqual(1, response.Data.AccountNumber);
            Assert.AreEqual("Mary", response.Data.FirstName);
        }

        [Test]
        public void NotFoundAccountReturnsFail()
        {
            var manager = new AccountManager();

            var response = manager.GetAccount(9999);

            Assert.IsFalse(response.Success);
        }

        [Test]
        public void FoundAccountReturnsSuccessMock()
        {
            var manager = new AccountManager(new MockRepository());

            var response = manager.GetAccount(10);

            Assert.IsTrue(response.Success);
            Assert.AreEqual(10, response.Data.AccountNumber);
            Assert.AreEqual("Gates", response.Data.LastName);
        }

        [Test]
        public void NotFoundAccountReturnsFailMock()
        {
            var manager = new AccountManager(new MockRepository());

            var response = manager.GetAccount(9999);

            Assert.IsFalse(response.Success);

        }
    }
}
