using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGBank.Data;
using SGBank.Models;
using SGBank.BLL;

namespace SGBank.Tests
{
    [TestFixture]
    public class AccountRepositoryTests
    {
        [Test]
        public void CanLoadAccount()
        {
            var repo = new AccountRepository();

            var account = repo.LoadAccount(1);

            Assert.AreEqual(1, account.AccountNumber);
            Assert.AreEqual("Mary", account.FirstName);
        }

        [Test]
        public void UpdateAccountSucceeds()
        {
            var repo = new AccountRepository();
            var accountToUpdate = repo.LoadAccount(1);
            accountToUpdate.Balance = 500.00M;
            repo.UpdateAccount(accountToUpdate);

            var result = repo.LoadAccount(1);

            Assert.AreEqual(500.00M, result.Balance);

        }

        [Test]
        public void CanLoadAccountMock()
        {
            var repo = new MockRepository();
            var account = repo.LoadAccount(10);

            Assert.AreEqual(10, account.AccountNumber);
            Assert.AreEqual("Bill", account.FirstName);
        }

        [Test]
        public void UpdateAccountSucceedsMock()
        {
            var repo = new MockRepository();
            var accountToUpdate = repo.LoadAccount(11);
            accountToUpdate.Balance = 66.00M;
            repo.UpdateAccount(accountToUpdate);

            var result = repo.LoadAccount(11);

            Assert.AreEqual(66.00M, result.Balance);

        }
    }
}
