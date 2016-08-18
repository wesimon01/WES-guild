using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.Models;
using SGBank.Data;
using System.IO;

namespace SGBank.UI.Workflows
{
    class CreateAccountWorkflow
    {
        private LookupWorkflow lookup = new LookupWorkflow();
        private Account newaccount = new Account();
        private AccountRepository repo = new AccountRepository();

        public void Execute()
        {
            int accountNumber = lookup.GetAccountNumberFromUser();
            newaccount = MakeNewAccount(accountNumber);
            repo.AddAccount(newaccount);     
        }

        
        public Account MakeNewAccount(int accountNumber)
        {
            Account account = new Account();
                     
            account.AccountNumber = accountNumber;
            Console.WriteLine("Please enter the first name on the new account:");
            account.FirstName = Console.ReadLine();
            Console.WriteLine("Please enter the last name on the new account:");
            account.LastName = Console.ReadLine();
          
            do
            {
                Console.WriteLine("Please make an initial deposit: ");
                var input = Console.ReadLine();
                decimal amount;

                if (decimal.TryParse(input, out amount))
                {
                    account.Balance = amount;
                    break;
                }
                Console.WriteLine("That was not a valid amount. Please try again.");
                Console.ReadKey();
                
            } while (true);

            return account;
        }       
    }
}
