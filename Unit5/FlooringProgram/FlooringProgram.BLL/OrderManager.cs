using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using FlooringProgram.Data;
using System.IO;
using System.Configuration;
using System.IO.Log;


namespace FlooringProgram.BLL
{
    public class OrderManager
    {    
        private IOrderRepository _repo;

        public OrderManager()
        {
            AppSettingsReader reader = new AppSettingsReader();
            string repo_Set = reader.GetValue("mode", typeof(string)).ToString();
            
            if (repo_Set == "test")
            {
                 _repo = new MockOrderRepository();
            }
            else
            {
                _repo = new OrderRepository();
            }
        }

        public OrderManager(IOrderRepository repo) // constructor for unit testing
        {
            _repo = repo;
        }

       
        public Response<Order> GetOrder(int OrderNumber, DateTime date)
        {         
            var response = new Response<Order>();

            try
            {
                Order order = _repo.LoadOrder(OrderNumber, date);

                if (order == null)
                {
                    response.Success = false;
                    response.Message = "Order was not found!";
                }
                else
                {
                    response.Success = true;
                    response.Data = order;
                }
            }
            catch (Exception ex)
            {
                string Xception = ex.ToString();
                if (File.Exists(@"DataFiles\Log.txt") == false) {
                    File.Create(@"Datafiles\Log.txt").Close();
                    using (var writer = File.CreateText(@"Datafiles\Log.txt"))
                    {
                        writer.WriteLine("{0}\n", Xception);
                    }
                }
                        response.Success = false;
                        response.Message = "Order does not exist";          
            }
            return response;
        }

        
        public List<Order> CallGetAllOrders(DateTime date)
        {
            List<Order> orders = _repo.GetAllOrders(date);
            return orders;
        }

        public void CallAddOrder(Order order)
        {
            _repo.AddOrder(order);
        }

        public void CallRemoveOrder(int orderNumber, DateTime date)
        {                
            _repo.RemoveOrder(orderNumber, date);         
        }

        public void CallEditOrder(Order order)
        {       
            _repo.EditOrder(order);
        }

        public void CallCreateAndWrite(Order order)
        {
            _repo.CreateAndWrite(order);
        }

        public bool CallSeeIfFileExists(string FilePath)
        {
            bool doesExist = _repo.SeeIfFileExists(FilePath);
            return doesExist;
        }

        public string CallGetFileName(DateTime date)
        {
            string path = _repo.GetFileName(date);
            return path;
        }

        public decimal GetCostFt2(string productType)
        {           
            Product product = new Product();
            List<Product> products = _repo.GetProductInfo(productType);
            product = products.FirstOrDefault(p => p.productType.ToLower() == productType);
            decimal cost = product.CostperFt2;
            return cost;       
        }

        public decimal GetLaborFt2(string productType)
        {         
            Product product = new Product();
            List<Product> products = _repo.GetProductInfo(productType);
            product = products.FirstOrDefault(p => p.productType.ToLower() == productType);
            decimal cost = product.LaborperFt2;
            return cost;
        }

        public decimal GetTaxRate(string state)
        {
            Tax StateTax = new Tax();
            state = state.ToUpper();
            List<Tax> taxes = _repo.GetTaxInfo(state);
            StateTax = taxes.FirstOrDefault(s => s.State == state);
            decimal tax = StateTax.TaxRate;
            return tax;
        }

        public decimal GetMaterialCost(decimal CostFt2, decimal area)
        {
            decimal materialCost = CostFt2 * area;
            return materialCost;
        }

        public decimal GetLaborCost(decimal LaborFt2, decimal area)
        {
            decimal laborCost = LaborFt2 * area;
            return laborCost;
        }

        public decimal GetTax(decimal laborCost, decimal materialCost, decimal TaxRate)
        {
            decimal tax = (laborCost + materialCost) * TaxRate * 1/100M; 
            return Math.Round(tax, 2);
        }

        public decimal GetOrderTotal(decimal Tax, decimal laborCost, decimal materialCost)
        {
            decimal total = Tax + laborCost + materialCost;
            return Math.Round(total, 2);
        }

        public int GetOrderNumber(DateTime date)
        {
            string path = _repo.GetFileName(date);

            if ((_repo.SeeIfFileExists(path) == false) || (_repo.GetAllOrders(date).Count() == 0))
                return 1;
            else
            {        
                List<Order> orders = _repo.GetAllOrders(date);
                int index = orders.Max(x => x.OrderNumber);
                index++;
                return index; 
            }
        }

        //Add an order or create new file
        public void AddOrderLogix(Order order)
        {
            string filePath = _repo.GetFileName(order.date);
            bool exists = CallSeeIfFileExists(filePath);

            if (exists == true)
            {
                order.OrderNumber = GetOrderNumber(order.date);
                CallAddOrder(order);
            }

            else
            {
                order.OrderNumber = GetOrderNumber(order.date);
                CallCreateAndWrite(order);
            }
        }

    }
}