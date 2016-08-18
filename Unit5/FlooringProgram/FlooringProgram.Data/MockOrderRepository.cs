using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using System.IO;

namespace FlooringProgram.Data
{
    public class MockOrderRepository : IOrderRepository
    {
        private List<Order> _orderlist = new List<Order>();

        public string GetFileName(DateTime date)
        {
            string orderDateString = @"DataFiles\Orders_" + date.ToString("MMddyyyy") + ".txt";
            return orderDateString;
        }

        public bool SeeIfFileExists(string AnyDate)
        {
            return true;
        }

        public MockOrderRepository()
        {             
                _orderlist.Add(new Order()
                {
                    OrderNumber = 1,
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

                });

                _orderlist.Add(new Order()
                {
                    OrderNumber = 2,
                    CustomerName = "Trump",
                    State = "PA",
                    date = new DateTime(2016, 1, 2),
                    TaxRate = 6.75M,
                    Total = 410.99M,
                    Tax = 25.99M,
                    productType = "laminate",
                    CostFt2 = 1.75M,
                    LaborFt2 = 2.10M,
                    Area = 100.00M,
                    materialCost = 175.00M,
                    laborCost = 210.00M
                });

                _orderlist.Add(new Order()
                {
                    OrderNumber = 3,
                    CustomerName = "Flint",
                    State = "MI",
                    date = new DateTime(2016, 1, 3),
                    TaxRate = 5.75M,
                    Total = 808.99M,
                    Tax = 43.99M,
                    productType = "tile",
                    CostFt2 = 3.50M,
                    LaborFt2 = 4.15M,
                    Area = 100.00M,
                    materialCost = 350.00M,
                    laborCost = 415.00M
                });

                _orderlist.Add(new Order()
                {
                    OrderNumber = 4,
                    CustomerName = "goatsimulator",
                    State = "IN",
                    date = new DateTime(2016, 1, 4),
                    TaxRate = 6.00M,
                    Total = 1049.40M,
                    Tax = 59.40M,
                    productType = "wood",
                    CostFt2 = 5.15M,
                    LaborFt2 = 4.75M,
                    Area = 100,
                    materialCost = 515.00M,
                    laborCost = 475.00M

                });        
            }
        
        public List<Order> GetAllOrders(DateTime date)
        {
            return _orderlist;
        }

        public Order LoadOrder(int OrderNumber, DateTime date)
        {
            return _orderlist.FirstOrDefault(a => a.OrderNumber == OrderNumber);
        }

        public void AddOrder(Order order)
        {
             _orderlist.Add(order);
        }

        public void CreateAndWrite(Order order)
        {
            _orderlist.Add(order); //no need to write order to new repo in Test mode
        }

        public void RemoveOrder(int orderNumbertoRemove, DateTime date)
        {
            Order orderTodelete = _orderlist.FirstOrDefault(a => a.OrderNumber == orderNumbertoRemove);
            _orderlist.Remove(orderTodelete);
        }

        public void EditOrder(Order orderToUpdate)
        {
            
            Order existingOrder = _orderlist.First(a => a.OrderNumber == orderToUpdate.OrderNumber);
            existingOrder.OrderNumber = orderToUpdate.OrderNumber;
            existingOrder.CustomerName = orderToUpdate.CustomerName;
            existingOrder.State = orderToUpdate.State;
            existingOrder.TaxRate = orderToUpdate.TaxRate;
            existingOrder.productType = orderToUpdate.productType;
            existingOrder.Area = orderToUpdate.Area;
            existingOrder.CostFt2 = orderToUpdate.CostFt2;
            existingOrder.LaborFt2 = orderToUpdate.LaborFt2;
            existingOrder.materialCost = orderToUpdate.materialCost;
            existingOrder.laborCost = orderToUpdate.laborCost;
            existingOrder.Tax = orderToUpdate.Tax;
            existingOrder.Total = orderToUpdate.Total;
            existingOrder.date = orderToUpdate.date;
        }

        public List<Product> GetProductInfo(string productType) {
            List<Product> products = new List<Product>();
            products.Add(new Product()
            {
                productType = "carpet",
                CostperFt2 = 2.25M,
                LaborperFt2 = 2.10M
            });
            products.Add(new Product()
            {
                productType = "laminate",
                CostperFt2 = 1.75M,
                LaborperFt2 = 2.10M
            });
            products.Add(new Product()
            {
                productType = "tile",
                CostperFt2 = 3.50M,
                LaborperFt2 = 4.15M
            });
            products.Add(new Product()
            {
                productType = "wood",
                CostperFt2 = 5.15M,
                LaborperFt2 = 4.75M
            });
            return products;
             }

        public List<Tax> GetTaxInfo(string state) {
            List<Tax> taxes = new List<Tax>();

            taxes.Add(new Tax()
            {
                State = "OH",
                TaxRate = 6.25M
            });
            taxes.Add(new Tax()
            {
                State = "PA",
                TaxRate = 6.75M
            });
            taxes.Add(new Tax()
            {
                State = "MI",
                TaxRate = 5.75M
            });
            taxes.Add(new Tax()
            {
                State = "IN",
                TaxRate = 6.00M
            });

            return taxes;
        }

        public void OverwriteFile(List<Order> orders) { }
       
    }
}