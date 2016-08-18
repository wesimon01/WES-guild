using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FlooringProgram.Data;
using FlooringProgram.Models;
using FlooringProgram.BLL;
using FlooringProgram.UI;

namespace FlooringProgram.Tests
{
    [TestFixture]

    class OrderManagerTests
    {
        [Test]
        public void NotFoundOrderReturnsFailTestMode()
        {
            var repo = new MockOrderRepository();
            var manager = new OrderManager(repo);
            DateTime date = new DateTime(2016, 7, 3);

            var response = manager.GetOrder(9999, date );

            Assert.IsFalse(response.Success);
        }

        [Test]
        public void FoundOrderReturnsSuccessTestMode()
        {
            var repo = new MockOrderRepository();
            var manager = new OrderManager(repo);
            DateTime date = new DateTime(2016, 7, 3);

            var response = manager.GetOrder(4, date);

            Assert.IsTrue(response.Success);
            Assert.AreEqual(4, response.Data.OrderNumber);
            Assert.AreEqual("goatsimulator", response.Data.CustomerName);
        }

        [Test]
        public void ProperlyAssignOrderNumberTestMode()
        {

            var repo = new MockOrderRepository();
            var manager = new OrderManager(repo);
            DateTime date = DateTime.Now;

            int answer = manager.GetOrderNumber(date);

            Assert.AreEqual(5, answer);
        }

        [Test]
        public void AddOrderLogixTestMode()
        {
            var repo = new MockOrderRepository();
            DateTime date = DateTime.Now;
            var manager = new OrderManager(repo);

            Order order = new Order()
            {  
                CustomerName = "Crooked-Hillary",
                State = "OH",
                date = new DateTime(2016, 1, 1),
                TaxRate = 6.25M,
                Total = 462.1875M,
                Tax = 27.1875M,
                productType = "carpet",
                CostFt2 = 2.25M,
                LaborFt2 = 2.10M,
                Area = 100.00M,
                materialCost = 225.00M,
                laborCost = 210.00M

            };

            manager.AddOrderLogix(order);

            var orderlist = manager.CallGetAllOrders(order.date);

            Assert.AreEqual(5, orderlist.Count);
            Assert.AreEqual(5, order.OrderNumber);
        }

    }
}
