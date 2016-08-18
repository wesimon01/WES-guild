using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using FlooringProgram.BLL;
using System.Globalization;

namespace FlooringProgram.UI
{
    class DeleteOrderWorkflow
    {
        private OrderManager _mgr;
        Order _selected = new Order();
        Response<Order> _response = new Response<Order>();
        MainMenu _main = new MainMenu();
        DateTime _date;     
        int _orderNumber;

        public DeleteOrderWorkflow(OrderManager mgr)
        {
            _mgr = mgr;
        }

        public void Execute()
        {
            _date = GetDateFromUser();
            ValidateUserDate(_date);
            do
            {
                _orderNumber = GetOrderNumberFromUser();
                _response = _mgr.GetOrder(_orderNumber, _date);
                if (_response.Success == false)
                {
                    Console.WriteLine(" {0}, press Any Key to Continue", _response.Message);
                    Console.ReadKey();
                }
            } while (_response.Success == false);

            DisplayOrderToDelete(_orderNumber, _date);
        }

        private void DisplayOrderToDelete(int orderNumber, DateTime date)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\n This is the order you are considering deleting \n");              
                PrintOrderDetails(_response.Data);
              
                    Console.WriteLine("\n Press Q to exit, Press D to delete this entry");
                    Console.WriteLine("\n Enter Choice: ");
                    string input = Console.ReadLine();

                if (input != null && input != "")
                {
                    if (input.Substring(0, 1).ToUpper() == "Q")
                    {
                        break;
                    }
                    if (input.Substring(0, 1).ToUpper() == "D")
                    {
                        _mgr.CallRemoveOrder(orderNumber, date);
                        break;
                    }
                }
                } while (true);

                _main.Execute();
            }
        

        private void PrintOrderDetails(Order order)
        {
            Order o = order;

            Console.WriteLine(" Order Information");
            Console.WriteLine("=============================");
            Console.WriteLine(" Order Number: {0}", o.OrderNumber);
            Console.WriteLine(" Customer Name : {0}", o.CustomerName);
            Console.WriteLine(" State: {0}", o.State);
            Console.WriteLine(" Tax Rate: {0}", o.TaxRate);
            Console.WriteLine(" Total: {0}", o.Total);
            Console.WriteLine(" Tax: {0}", o.Tax);
            Console.WriteLine(" ProductType: {0}", o.productType);
            Console.WriteLine(" Cost/Ft2: {0}", o.CostFt2);
            Console.WriteLine(" Labor/Ft2: {0}", o.LaborFt2);
            Console.WriteLine(" Area: {0}", o.Area);
            Console.WriteLine(" Material Cost: {0}", o.materialCost);
            Console.WriteLine(" labor cost: {0}", o.laborCost);
            Console.WriteLine(" Date: {0} ", o.date.ToString("MM/dd/yyyy"));
        }

        private int GetOrderNumberFromUser()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\n Enter an order number: ");
                string input = Console.ReadLine();
                int orderNumber;

                if (int.TryParse(input, out orderNumber))
                    return orderNumber;

                Console.WriteLine(" That was not a valid order number.  Press any key to try again...");
                Console.ReadKey();
            } while (true);
        }

        private DateTime GetDateFromUser()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\n Enter an order date (MM/DD/YYYY) : ");
                string input = Console.ReadLine();
                DateTime date;

                if (DateTime.TryParseExact(input, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                    return date;

                Console.WriteLine(" That was not a valid date.  Press any key to try again...");
                Console.ReadKey();
            } while (true);
        }

        private void ValidateUserDate(DateTime date)
        {
            bool isValidInput = false;
            string pathToCheck = _mgr.CallGetFileName(date);
            isValidInput = _mgr.CallSeeIfFileExists(pathToCheck);

            if (isValidInput == false)
            {
                Console.WriteLine("\n That order date does not exist, 'Enter' to try again");
                Console.ReadKey();
                Execute();
            }
            else
            {
                isValidInput = true;
            }

        }

    }
}
