using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.Models;

namespace SGBank.UI.Workflows
{
    class WithdrawWorkflow
    {
            public void Execute(Account account)
            {
                decimal amount = GetWithDrawAmount();

                var manager = new AccountManager();

                var resopnse = manager.WithDraw(account, amount);

                if (resopnse.Success)
                {
                    Console.Clear();
                    Console.WriteLine("Withdraw {0:c} from account {1}.  New Balance is {2}.", resopnse.Data.WithdrawAmount, resopnse.Data.AccountNumber, resopnse.Data.NewBalance);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("An error occurred.  {0}", resopnse.Message);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }

            private decimal GetWithDrawAmount()
            {
                do
                {
                    Console.Write("Enter a withdraw amount: ");
                    var input = Console.ReadLine();
                    decimal amount;

                    if (decimal.TryParse(input, out amount))
                        return amount;

                    Console.WriteLine("That was not a valid amount. Please try again.");
                    Console.ReadKey();
                } while (true);
            }
        }
    }






