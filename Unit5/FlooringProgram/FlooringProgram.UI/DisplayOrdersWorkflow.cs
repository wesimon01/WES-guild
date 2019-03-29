using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using FlooringProgram.BLL;
using System.Globalization;
using FlooringProgram.UI.Util;

namespace FlooringProgram.UI
{
    class DisplayOrdersWorkflow
    {
        private OrderManager _mgr;
        MainMenu _menu = new MainMenu();
        DateTime _date;
        bool _isValidInput;

        public DisplayOrdersWorkflow(OrderManager mgr)
        {
            _mgr = mgr;
        }

        public void Execute()
        {
            do
            {
                _date = Utilities.GetDateFromUser();
                ValidateUserDate(_date);
            } while (!_isValidInput);

            DisplayAllOrders(_date);
        }

        public void DisplayAllOrders(DateTime date)
        {           
            List<Order> orders = _mgr.CallGetAllOrders(date);
            Console.Clear();

            if (orders != null)
            {
                foreach (var item in orders)
                {
                    PrintOrderDetails(item);
                }
                Console.WriteLine(" Press any key to return to the Main Menu");
                Console.ReadKey();
                _menu.Execute();
            }

            else
            {
                Console.WriteLine(" A problem occurred...");
                Console.WriteLine(" Press any key to continue...");
                Console.ReadKey();
                _menu.Execute();
            }
        }

        private void PrintOrderDetails(Order order)
        {
            Order o = order;

            Console.WriteLine("\n Order Information");
            Console.WriteLine(" =============================");
            Console.WriteLine(" Order Number: {0}", o.OrderNumber);
            Console.WriteLine(" Customer Name : {0}", o.CustomerName);
            Console.WriteLine(" State: {0}", o.State);
            Console.WriteLine(" Tax Rate: {0}", o.TaxRate);
            Console.WriteLine(" Total: {0}", o.Total);
            Console.WriteLine(" Tax: {0}", o.Tax);
            Console.WriteLine(" ProductType: {0}", o.productType);
            Console.WriteLine(" Cost/Ft2: {0}", o.CostFt2);
            Console.WriteLine(" Labor/Ft2: {0}", o.LaborFt2);
            Console.WriteLine(" Area (ft^2): {0}", o.Area);
            Console.WriteLine(" Material Cost: {0}", o.materialCost);
            Console.WriteLine(" labor cost: {0}", o.laborCost);
            Console.WriteLine(" Date: {0} ", o.date.ToString("MM/dd/yyyy"));
            Console.WriteLine("\n");
        }

        private void ValidateUserDate(DateTime date)
        {
            _isValidInput = false; 
            string pathToCheck = _mgr.CallGetFileName(date);
            _isValidInput = _mgr.CallSeeIfFileExists(pathToCheck);

                if (!_isValidInput)
                {
                    Console.WriteLine("\n That order date does not exist, 'Enter' to try again");
                    Console.ReadKey();                   
                }
                else
                {
                    _isValidInput = true;           
                }              
            }

    }
  }

