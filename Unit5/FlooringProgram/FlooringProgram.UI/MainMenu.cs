using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.BLL;

namespace FlooringProgram.UI
{
    public class MainMenu
    {
        OrderManager _mgr = new OrderManager();

        public void Execute()
        {
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n WELCOME TO SG_FLOORING CORP.");
                Console.WriteLine(@"            __       ");
                Console.WriteLine(@"         __/  \__    ");
                Console.WriteLine(@"        /  \__/  \   ");
                Console.WriteLine(@"        \__/  \__/   ");
                Console.WriteLine(@"        /  \__/  \   ");
                Console.WriteLine(@"        \__/  \__/   ");
                Console.WriteLine(@"           \__/      ");
                Console.WriteLine("==============================");
                Console.WriteLine("\n 1. Display Orders");
                Console.WriteLine(" 2. Add an Order");
                Console.WriteLine(" 3. Edit an Order");
                Console.WriteLine(" 4. Remove an Order");
                Console.WriteLine(" 5. (Q) to Quit");

                Console.WriteLine("\n\n Enter Choice: ");
                string input = Console.ReadLine();

                if (input == "" || input == null)
                {
                    Execute();
                }
                if ((input.Substring(0, 1).ToUpper()) == "Q")
                    break;

                ProcessChoice(input);

            } while (true);
        }

        private void ProcessChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    // display all orders...
                    DisplayOrdersWorkflow displayOrders = new DisplayOrdersWorkflow(_mgr);
                    displayOrders.Execute();
                    break;
                case "2":
                    // add an order...
                    AddOrderWorkflow addOrder = new AddOrderWorkflow(_mgr);
                    addOrder.Execute();
                    break;
                    // edit an order...
                case "3":
                    EditOrderWorkflow editOrder = new EditOrderWorkflow(_mgr);
                    editOrder.Execute();
                    break;
                    // remove an order...
                case "4":
                    DeleteOrderWorkflow deleteOrder = new DeleteOrderWorkflow(_mgr);
                    deleteOrder.Execute();
                    break;
                default:
                    Execute();
                    break;                                
            }
        }
    }
}
