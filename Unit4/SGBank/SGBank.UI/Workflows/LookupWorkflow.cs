using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.BLL;
using SGBank.Data;

namespace SGBank.UI.Workflows
{
    public class LookupWorkflow
    {
        private Account _currentAccount;

        public void Execute()
        {
            int accountNumber = GetAccountNumberFromUser();
            DisplayAccountInformation(accountNumber);
        }

        public void DisplayAccountInformation(int accountNumber)
        {
            var manager = new AccountManager();

            var response = manager.GetAccount(accountNumber);
            
            Console.Clear();

            if (response.Success)
            {
                _currentAccount = response.Data;
                PrintAccountDetails(response);
                DisplayLookupMenu();
                       
            }
            else
            {
                Console.WriteLine("A problem occurred...");
                Console.WriteLine(response.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

        }

        public void DisplayAllAccounts()
        {
            var repo = new AccountRepository();

            var accounts = repo.GetAllAccounts();

            Console.Clear();

            if (accounts != null) {

                foreach (var item in accounts)
                {
                    PrintAllAccountDetails(item);
                }
                Console.WriteLine(" Press any key to return to the Main Menu");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("A problem occurred...");
                //Console.WriteLine(response.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private void DisplayLookupMenu()
        {
            do
            {
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Transfer");
                Console.WriteLine("\n(Q) to quit");

                Console.WriteLine("\n\nEnter Choice: ");
                string input = Console.ReadLine();

                
                    if (input.Substring(0, 1).ToUpper() == "Q")
                    break;

                ProcessChoice(input);
            } while (true);
        }

        private void ProcessChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    var depositWF = new DepositWorkflow();
                    depositWF.Execute(_currentAccount);
                    break;
                case "2":
                    var withdrawWF = new WithdrawWorkflow();
                    withdrawWF.Execute(_currentAccount);
                    break;
                case "3":
                    var transferWF = new TransferFundsWorkflow();
                    transferWF.Execute(_currentAccount);
                    break;
            }    
        }

        private void PrintAccountDetails(Response<Account> response)
        {
            Console.WriteLine("Account Information");
            Console.WriteLine("=============================");
            Console.WriteLine("Account Number: {0}", response.Data.AccountNumber);
            Console.WriteLine("Name : {0} {1}", response.Data.FirstName, response.Data.LastName);
            Console.WriteLine("Account Balance: {0:c}", response.Data.Balance);
        }

        public int GetAccountNumberFromUser()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Enter an account number: ");
                string input = Console.ReadLine();
                int accountNumber;

                if (int.TryParse(input, out accountNumber))
                    return accountNumber; 
                
                Console.WriteLine("That was not a valid account number.  Press any key to try again...");
                Console.ReadKey();
            } while (true);      
        }

        private void PrintAllAccountDetails(Account account)
        {
            Console.WriteLine("\nAccount Information");
            Console.WriteLine("=============================");
            Console.WriteLine("Account Number: {0}", account.AccountNumber);
            Console.WriteLine("Name : {0} {1}", account.FirstName, account.LastName);
            Console.WriteLine("Account Balance: {0:c}\n", account.Balance);
        }

        public static string PromptForType()
        {
            Console.WriteLine("Select Account Repo - (A)ccount Repository\n (M)ockRepository");
            Console.Write("User Choice: ");
            return Console.ReadLine();
        }
    }
}
