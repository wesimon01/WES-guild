﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.Models;

namespace SGBank.UI.Workflows
{
    public class DepositWorkflow
    {
        public void Execute(Account account)
        {
            decimal amount = GetDepositAmount();

            var manager = new AccountManager();

            var resopnse = manager.Deposit(account, amount);

            if (resopnse.Success)
            {
                Console.Clear();
                Console.WriteLine("Deposited {0:c} to account {1}.  New Balance is {2}.", resopnse.Data.DepositAmount, resopnse.Data.AccountNumber, resopnse.Data.NewBalance);
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

        private decimal GetDepositAmount()
        {
            do
            {
                Console.Write("Enter a deposit amount: ");
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
