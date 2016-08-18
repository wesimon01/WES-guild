using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using System.IO;
using System.Globalization;

namespace FlooringProgram.Data
{
    public class OrderRepository : IOrderRepository
    {   
        private string _ProductPath = @"DataFiles\Products.txt";
        private string _StateTaxPath = @"DataFiles\Taxes.txt";

        public string GetFileName(DateTime date)
        {
            string orderDateString = @"DataFiles\Orders_" + date.ToString("MMddyyyy") + ".txt";
            return orderDateString;
        }

        public bool SeeIfFileExists(string FilePath)
        {
            bool doesExist = File.Exists(FilePath);
            return doesExist;
        }

        public List<Order> GetAllOrders(DateTime date)
            {
                List<Order> orders = new List<Order>();
                var reader = File.ReadAllLines(GetFileName(date));

                for (int i = 1; i < reader.Length; i++)
                {
                    var columns = reader[i].Split(',');

                    Order order = new Order();

                    order.OrderNumber = int.Parse(columns[0]);
                    order.CustomerName = columns[1];
                    order.State = columns[2];
                    order.TaxRate = decimal.Parse(columns[3]);
                    order.productType = (columns[4]);
                    order.Area = decimal.Parse(columns[5]);
                    order.CostFt2 = decimal.Parse(columns[6]);
                    order.LaborFt2 = decimal.Parse(columns[7]);
                    order.materialCost = decimal.Parse(columns[8]);
                    order.laborCost = decimal.Parse(columns[9]);
                    order.Tax = decimal.Parse(columns[10]);
                    order.Total = decimal.Parse(columns[11]);
                    order.date = DateTime.ParseExact(columns[12], "MM/dd/yyyy", CultureInfo.InvariantCulture);

                    orders.Add(order);
                }
                return orders;
            }

        public List<Product> GetProductInfo(string productType)
        {
            List<Product> products = new List<Product>();
            var reader = File.ReadAllLines(_ProductPath);

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                Product product = new Product();

                product.productType = columns[0];
                product.CostperFt2 = decimal.Parse(columns[1]);
                product.LaborperFt2 = decimal.Parse(columns[2]);            
                products.Add(product);
            }
            return products;
        }

        public List<Tax> GetTaxInfo(string state)
        {
            List<Tax> taxes  = new List<Tax>();
            var reader = File.ReadAllLines(_StateTaxPath);

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                Tax tax = new Tax();

                tax.State = columns[0];
                tax.TaxRate = decimal.Parse(columns[1]);
                taxes.Add(tax);
            }
            return taxes;
        }

        public void AddOrder(Order order)
        {                
            List<Order> orders = GetAllOrders(order.date);              
            orders.Add(order);
            OverwriteFile(orders);
        }

        public Order LoadOrder(int orderNumber, DateTime date)
        {
            List<Order> orders = GetAllOrders(date);

            return orders.FirstOrDefault(a => (a.OrderNumber == orderNumber) 
            && (a.date.ToString("MM/dd/yyyy") == date.ToString("MM/dd/yyyy")));
        }
        
        public void RemoveOrder(int orderNumbertoRemove, DateTime date)
        {
          List<Order> orders = GetAllOrders(date);

          Order orderTodelete = orders.FirstOrDefault(a => (a.OrderNumber == orderNumbertoRemove) 
          && (a.date.ToString("MM/dd/yyyy") == date.ToString("MM/dd/yyyy")));
          orders.Remove(orderTodelete);

            OverwriteFile(orders);
         }

         public void EditOrder(Order orderToUpdate)
         {
                List<Order> orders = GetAllOrders(orderToUpdate.date);

                Order existingOrder = orders.First(a => a.OrderNumber == orderToUpdate.OrderNumber);
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

            OverwriteFile(orders);
        }

        public void OverwriteFile(List<Order> orders)
        {
            File.Delete(GetFileName(orders[0].date));

            using (var writer = File.CreateText(GetFileName(orders[0].date)))
            {
                writer.WriteLine("OrderNumber, CustomerName, State, TaxRate, productType, Area, CostFt2, LaborFt2"
                    + ", materialCost, laborCost, Tax, Total, date");

                foreach (var order in orders)
                {
                    writer.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}"
                        + ",{12}", order.OrderNumber, order.CustomerName, order.State, order.TaxRate,
                        order.productType, order.Area, order.CostFt2, order.LaborFt2, order.materialCost,
                        order.laborCost, order.Tax, order.Total, order.date.ToString("MM/dd/yyyy"));
                }
         }
      }

       public void CreateAndWrite(Order order)
       {
            File.Create(GetFileName(order.date)).Close();

            using (var writer = File.CreateText(GetFileName(order.date)))
            {
                writer.WriteLine("OrderNumber, CustomerName, State, TaxRate, productType, Area, CostFt2, LaborFt2"
                    + ", materialCost, laborCost, Tax, Total, date");

                writer.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}"
                    + ",{12}", order.OrderNumber, order.CustomerName, order.State, order.TaxRate,
                    order.productType, order.Area, order.CostFt2, order.LaborFt2, order.materialCost,
                    order.laborCost, order.Tax, order.Total, order.date.ToString("MM/dd/yyyy"));
            }
         }

    }
}
    


