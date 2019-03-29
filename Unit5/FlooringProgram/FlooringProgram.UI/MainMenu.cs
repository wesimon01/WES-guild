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
                ConsoleColor defaultColor = Console.ForegroundColor;
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

                Console.ForegroundColor = defaultColor;
                Console.WriteLine("\n 1. Display Orders");
                Console.WriteLine(" 2. Add an Order");
                Console.WriteLine(" 3. Edit an Order");
                Console.WriteLine(" 4. Remove an Order");
                Console.WriteLine(" 5. (Q) to Quit");

                Console.WriteLine("\n\n Enter Choice: ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Execute();
                }
                if (input.ToUpper() == "Q") {
                    break;
                }
     
                ProcessChoice(input);

            } while (true);
        }

        private void ProcessChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    // display all orders...
                    var displayOrdersWorkflow = new DisplayOrdersWorkflow(_mgr);
                    displayOrdersWorkflow.Execute();
                    break;
                case "2":
                    // add an order...
                    var addOrderWorkflow = new AddOrderWorkflow(_mgr);
                    addOrderWorkflow.Execute();
                    break;
                    // edit an order...
                case "3":
                    var editOrderWorkflow = new EditOrderWorkflow(_mgr);
                    editOrderWorkflow.Execute();
                    break;
                    // remove an order...
                case "4":
                    var deleteOrderWorkflow = new DeleteOrderWorkflow(_mgr);
                    deleteOrderWorkflow.Execute();
                    break;
                default:
                    Execute();
                    break;                                
            }
        }
    }
}
