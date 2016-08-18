using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.UI;
using SGBank.Data;
using SGBank.BLL;


namespace SGBank.UI.Workflows
{
    class TransferFundsWorkflow
    {   
        private LookupWorkflow lookup = new LookupWorkflow();
        AccountManager manager = new AccountManager();

        public void Execute(Account account)
        {
            decimal amount = GetTransferAmount();
            int otherAccountNumber = GetOtherAccountNumberFromUser();
            var otherAccount = manager.GetAccount(otherAccountNumber);

            var response = manager.Transfer(account, otherAccount.Data, amount);

            if (response.Success)
            {
                Console.Clear();
                Console.WriteLine("Withdraw {0:c} from account {1}.  New Balance is {2}.", response.Data.TransferAmount, response.Data.AccountNumberT, response.Data.NewBalanceT);
                Console.WriteLine("Deposit {0:c} to account {1}.  New Balance is {2}.", response.Data.TransferAmount, response.Data.AccountNumberR, response.Data.NewBalanceR);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                var accountResponse = manager.GetAccount(account.AccountNumber);
                PrintAccountDetails(accountResponse);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("An error occurred.  {0}", response.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private decimal GetTransferAmount()
        {
            do
            {
                Console.Write("Enter a transfer amount: ");
                var input = Console.ReadLine();
                decimal amount;

                if (decimal.TryParse(input, out amount))
                    return amount;

                Console.WriteLine("That was not a valid amount. Please try again.");
                Console.ReadKey();
            } while (true);
        }

        private int GetOtherAccountNumberFromUser()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Enter an account number to transfer funds to: ");
                string input = Console.ReadLine();
                int accountNumber;

                if (int.TryParse(input, out accountNumber))
                    return accountNumber;

                Console.WriteLine("That was not a valid account number.  Press any key to try again...");
                Console.ReadKey();
            } while (true);
        }

        private void PrintAccountDetails(Response<Account> response)
        {
            Console.WriteLine("Account Information");
            Console.WriteLine("=============================");
            Console.WriteLine("Account Number: {0}", response.Data.AccountNumber);
            Console.WriteLine("Name : {0} {1}", response.Data.FirstName, response.Data.LastName);
            Console.WriteLine("Account Balance: {0:c}", response.Data.Balance);
        }

    }
}
