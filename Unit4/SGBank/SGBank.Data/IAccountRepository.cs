using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Data;
using SGBank.Models;


namespace SGBank.Data
{
    public interface IAccountRepository
    {      
        List<Account> GetAllAccounts();
        void AddAccount(Account account);
        Account LoadAccount(int accountNumber);
        void UpdateAccount(Account accountToUpdate);
        void RemoveAccount(int accountNumbertoRemove);
        void OverwriteFile(List<Account> accounts);
    }
}
