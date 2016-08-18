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

    class OrderRepositoryTests
    {
        [Test]
        public void CanLoadOrderTest()
        {
            var repo = new MockOrderRepository();
            DateTime date = new DateTime(2016, 1, 1);

            var order = repo.LoadOrder(1, date);

            Assert.AreEqual(1, order.OrderNumber);
            Assert.AreEqual("Crooked-Hillary", order.CustomerName);
        }

        [Test]
        public void CanGetAllOrdersTest()
        {
            var repo = new MockOrderRepository();
            DateTime date = DateTime.Now;

            var orders = repo.GetAllOrders(date);

            Assert.AreEqual(4, orders.Count());        
        }

        [Test]
        public void CanRemoveOrderTest()
        {
            var repo = new MockOrderRepository();
            DateTime date = new DateTime(2016, 1, 2);

            var orders = repo.GetAllOrders(date);
            repo.RemoveOrder(2, date);

            Assert.AreEqual(3, orders.Count());          
        }

        [Test]
        public void CanEditOrdersTest()
        {
            var repo = new MockOrderRepository();
            DateTime date = new DateTime(2016, 1, 3);

            var orderToUpdate = repo.LoadOrder(3, date);
            orderToUpdate.State = "IN";
            repo.EditOrder(orderToUpdate);

            Assert.AreEqual("IN", orderToUpdate.State);
        }

        [Test]
        public void CanGetAllOrdersProd()
        {
            var repo = new OrderRepository();
            DateTime date = new DateTime(2016, 7, 3);

            var orders = repo.GetAllOrders(date);
            Assert.AreEqual(3, orders.Count());
        }

        [Test]
        public void CanLoadOrderProd()
        {
            var repo = new OrderRepository();
            DateTime date = new DateTime(2016, 7, 3);

            var order = repo.LoadOrder(3, date);

            Assert.AreEqual(3, order.OrderNumber);
            Assert.AreEqual("doge", order.CustomerName);
        }

        [Test]
        public void CanRemoveOrderProd()
        {
            var repo = new OrderRepository();
            DateTime date = new DateTime(2016, 7, 3);
       
            repo.RemoveOrder(2, date);
            List<Order> orders = repo.GetAllOrders(date);
            Assert.AreEqual(1, orders.Count());
        }


    }
}
