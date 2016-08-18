using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.Data;
using SGBank.BLL;
using SGBank.UI;

namespace SGBank.UI.Workflows
{
    class DeleteAccountWorkflow
    {
        private LookupWorkflow lookup = new LookupWorkflow();
        private AccountRepository repo = new AccountRepository(); //data layer in UI layer NO

        public void Execute()
        {
            var accountNumber = lookup.GetAccountNumberFromUser();
            DisplayAccountToDelete(accountNumber);         
        }

        public void DisplayAccountToDelete(int accountNumber)
        {
            MainMenu main = new MainMenu();
            Account _currentAccount = new Account();
            var manager = new AccountManager();
            var response = manager.GetAccount(accountNumber);

            Console.Clear();

            if (response.Success)
            {
                Console.WriteLine("This is the account you are considering deleting \n");
                _currentAccount = response.Data;
                PrintAccountDetails(response);

                do
                {
                    Console.WriteLine("\nPress Q to exit, Press D to delete this entry");
                    Console.WriteLine("\n\nEnter Choice: ");
                    string input = Console.ReadLine();
                    
                    if (input.Substring(0, 1).ToUpper() == "Q")         
                        break;

                    if (input.Substring(0, 1).ToUpper() == "D")
                        repo.RemoveAccount(accountNumber); //have accountmanager call this
                        break;

                } while (true);

                main.Execute();
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
    }
}
