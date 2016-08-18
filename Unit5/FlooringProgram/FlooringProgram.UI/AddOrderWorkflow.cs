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
    class AddOrderWorkflow
    {
        private OrderManager _mgr;
        Order _order = new Order();

        public AddOrderWorkflow(OrderManager mgr)
        {
            _mgr = mgr;
        }

        public void Execute()
        {          
            _order = GetOrderInfo();           
            _mgr.AddOrderLogix(_order);
        }

        private Order GetOrderInfo()
        {
                Order order = new Order();

                Console.Clear();
                Console.WriteLine("\n Enter Customer Name: ");
                string name = Console.ReadLine();
                order.CustomerName = name;

            do
            {
                Console.WriteLine("\n Enter customer state (OH,PA,IN,MI): ");
                string state = Console.ReadLine();
                state = state.ToUpper();

                if (state == "OH" || state == "MI" || state == "IN" || state == "PA")
                {
                    order.State = state;
                    break;
                }

                Console.WriteLine(" That is not a valid state, Press Any key to try again");
                Console.ReadKey();

            } while (true);

            do
            {

                Console.WriteLine("\n Enter flooring material desired (carpet, laminate, tile, wood): ");
                string material = Console.ReadLine();
                material = material.ToLower();

                if (material == "carpet" || material == "laminate" || material == "tile" || material == "wood") {
                    order.productType = material;
                    break;
                }
                
                Console.WriteLine(" That is not a valid flooring material, Press Any key to try again");
                Console.ReadKey();

            } while (true);

            do
            {
                Console.WriteLine("\n Area of flooring desired: ");
                string input = Console.ReadLine();
                decimal area;

                if (decimal.TryParse(input, out area))
                {
                    order.Area = area;
                    break;
                }
                Console.WriteLine(" That was not a valid area. Please try again.");
                Console.ReadKey();

            } while (true);

            order.date = GetDateFromUser();

            // set the rest
            order.TaxRate = _mgr.GetTaxRate(order.State);          
            order.CostFt2 = _mgr.GetCostFt2(order.productType);
            order.LaborFt2 = _mgr.GetLaborFt2(order.productType);
            order.laborCost = _mgr.GetLaborCost(order.LaborFt2, order.Area);
            order.materialCost = _mgr.GetMaterialCost(order.CostFt2, order.Area);
            order.Tax = _mgr.GetTax(order.laborCost, order.materialCost, order.TaxRate);
            order.Total = _mgr.GetOrderTotal(order.Tax, order.laborCost, order.materialCost);
            
            return order;
        }

        private DateTime GetDateFromUser()
        {
            do
            {
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


    }
}
