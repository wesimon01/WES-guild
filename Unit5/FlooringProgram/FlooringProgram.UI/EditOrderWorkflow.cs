using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.BLL;
using System.Globalization;
using FlooringProgram.Models;

namespace FlooringProgram.UI
{
    class EditOrderWorkflow
    {
        private OrderManager _mgr;
        MainMenu _menu = new MainMenu();
        Response<Order> _response = new Response<Order>();
        Order _editedOrder = new Order();
        DateTime _date;
        int _orderNumber;

        public EditOrderWorkflow(OrderManager mgr)
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
                if (_response.Success ==  false)
                {
                    Console.WriteLine(" {0}, press Any Key to Continue", _response.Message);
                    Console.ReadKey();
                }
            } while (_response.Success == false);

            _editedOrder = GetNewOrderAttributes(_response.Data);
            DisplayUpdatedOrderBeforeWrite(_editedOrder);
        }

        private Order GetNewOrderAttributes(Order orderToEdit)
        {
            Order order = new Order();

            Console.Clear();
            Console.WriteLine("\n Edit Customer Name, press Enter to keep current value ({0}):", orderToEdit.CustomerName);
            string name = Console.ReadLine();

            if (string.IsNullOrEmpty(name))
                order.CustomerName = orderToEdit.CustomerName;
            else
                order.CustomerName = name;

            do
            {
                Console.WriteLine("\n Edit customer state (OH,PA,IN,MI), press Enter to keep current value ({0}): ", orderToEdit.State);
                string state = Console.ReadLine();
                state = state.ToUpper();

                if (string.IsNullOrEmpty(state))
                {
                    order.State = orderToEdit.State;
                    break;
                }

                if (state == "OH" || state == "MI" || state == "IN" || state == "PA")
                {
                    order.State = state;
                    break;

                }

                Console.WriteLine("\n That is not a valid state, press any key");
                Console.ReadKey();

            } while (true);

            do
            {

                Console.WriteLine("\n Edit flooring material desired (carpet, laminate, tile, wood),\n press Enter to keep current value ({0}): ", orderToEdit.productType);
                string material = Console.ReadLine();
                material = material.ToLower();

                if (string.IsNullOrEmpty(material))
                {
                    order.productType = orderToEdit.productType;
                    break;
                }

                if (material == "carpet" || material == "laminate" || material == "tile" || material == "wood")
                {
                    order.productType = material;
                    break;
                }

                Console.WriteLine("\n That is not a valid flooring material, press any key");
                Console.ReadKey();

            } while (true);

            do
            {
                Console.WriteLine("\n Edit Area (ft^2) of flooring desired, press Enter to keep current value ({0}): ", orderToEdit.Area);
                string input = Console.ReadLine();
                decimal area;

                if (string.IsNullOrEmpty(input))
                {
                    order.Area = orderToEdit.Area;
                    break;
                }

                if (decimal.TryParse(input, out area))
                {
                    order.Area = area;
                    break;
                }

                Console.WriteLine("\n That was not a valid area. Please try again.");
                Console.ReadKey();

            } while (true);

            order.OrderNumber = orderToEdit.OrderNumber;
            order.TaxRate = _mgr.GetTaxRate(order.State);
            order.CostFt2 = _mgr.GetCostFt2(order.productType);
            order.LaborFt2 = _mgr.GetLaborFt2(order.productType);
            order.laborCost = _mgr.GetLaborCost(order.LaborFt2, order.Area);
            order.materialCost = _mgr.GetMaterialCost(order.CostFt2, order.Area);
            order.Tax = _mgr.GetTax(order.laborCost, order.materialCost, order.TaxRate);
            order.Total = _mgr.GetOrderTotal(order.Tax, order.laborCost, order.materialCost);
            order.date = orderToEdit.date;

            return order;
        }

        private int GetOrderNumberFromUser()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\n Enter an order number: ");
                string input = Console.ReadLine();
                int accountNumber;

                if (int.TryParse(input, out accountNumber))
                    return accountNumber;

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

                if (DateTime.TryParseExact(input, "MM/dd/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out date))
                {
                    return date;
                }

                Console.WriteLine("\n That was not a valid date.  Press any key to try again...");
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

        private void DisplayUpdatedOrderBeforeWrite(Order editedOrder)
        {
            do
            {
                Console.Clear();
                PrintUpdatedOrderDetails(editedOrder);
      
                Console.WriteLine("\n Enter Q to exit, Enter W to write the new order information");
                Console.WriteLine("\n Enter Choice: ");
                string input = Console.ReadLine();

                if (input != null && input != "")
                {

                    if (input.Substring(0, 1).ToUpper() == "Q")
                    {
                        break;
                    }

                    if (input.Substring(0, 1).ToUpper() == "W")
                    {
                        _mgr.CallEditOrder(editedOrder);
                        break;
                    }
                }
            } while (true);

            _menu.Execute();
        }

        private void PrintUpdatedOrderDetails(Order order)
        {
            Order o = order;

            Console.WriteLine("\n Edited Order Information");
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
            Console.WriteLine(" Area: {0}", o.Area);
            Console.WriteLine(" Material Cost: {0}", o.materialCost);
            Console.WriteLine(" labor cost: {0}", o.laborCost);
            Console.WriteLine(" Date: {0} ", o.date.ToString("MM/dd/yyyy"));
            Console.WriteLine("\n Would you like to Write these changes?");
            Console.WriteLine("\n");
        }
    
    }
}