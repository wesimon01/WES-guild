using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using System.IO;

namespace SGBank.Data
{
    public class AccountRepository : IAccountRepository
    {
        public string FilePath = @"DataFiles\Bank.txt";

        public List<Account> GetAllAccounts()
        {
            List<Account> accounts = new List<Account>();

            var reader = File.ReadAllLines(FilePath);

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var account = new Account();

                account.AccountNumber = int.Parse(columns[0]);
                account.FirstName = columns[1];
                account.LastName = columns[2];
                account.Balance = decimal.Parse(columns[3]);

                accounts.Add(account);
            }
            return accounts;
        }

        public void AddAccount(Account account)
        {
            List<Account> accounts = GetAllAccounts();
            accounts.Add(account);

            OverwriteFile(accounts);
        }

        public Account LoadAccount(int accountNumber)
        {
            List<Account> accounts = GetAllAccounts();
            return accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }

        public void UpdateAccount(Account accountToUpdate)
        {
            var accounts = GetAllAccounts();

            var existingAccount = accounts.First(a => a.AccountNumber == accountToUpdate.AccountNumber);
            existingAccount.FirstName = accountToUpdate.FirstName;
            existingAccount.LastName = accountToUpdate.LastName;
            existingAccount.Balance = accountToUpdate.Balance;

            OverwriteFile(accounts);
        }
       
        public void RemoveAccount(int accountNumbertoRemove)
        {
            List<Account> accounts = GetAllAccounts();
            Account accountTodelete = accounts.FirstOrDefault(a => a.AccountNumber == accountNumbertoRemove);
            accounts.Remove(accountTodelete);

            OverwriteFile(accounts);
        }

        public void OverwriteFile(List<Account> accounts)
        {
            File.Delete(FilePath);

            using (var writer = File.CreateText(FilePath))
            {
                writer.WriteLine("AccountNumber,FirstName,LastName,Balance");

                foreach (var account in accounts)
                {
                    writer.WriteLine("{0},{1},{2},{3}", account.AccountNumber, account.FirstName, account.LastName, account.Balance);
                }
            }
        }

        //public void SortAccounts() {
        //    List<Account> accounts = GetAllAccounts();
        //    List<Account> SortedAccounts = accounts.OrderBy(a => a.LastName).ToList();

        //}

    }
}
