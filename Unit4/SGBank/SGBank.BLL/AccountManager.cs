using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using SGBank.Data;
using SGBank.Models;

namespace SGBank.BLL
{
    public class AccountManager 
    {
        private IAccountRepository _repo { get; set; }

        public AccountManager()
        {
            _repo = new AccountRepository();
        }

        //public AccountManager():this(new AccountRepository()) { }

        public AccountManager(IAccountRepository repo)
        {
            _repo = repo;
        }

        public AccountManager(string type)
        {
            _repo = AccountRepositoryFactory.CreateAccountRepository(type);
        }

        public Response<Account> GetAccount(int accountNumber)
        {
            var repo = _repo;
            var response = new Response<Account>();
            
            try
            {
                var account = repo.LoadAccount(accountNumber);

                if (account == null)
                {
                    response.Success = false;
                    response.Message = "Account was not found!";
                }
                else
                {
                    response.Success = true;
                    response.Data = account;
                }
            }
            catch (Exception ex)
            {
                // log the exception
                response.Success = false;
                response.Message = ex.Message; //"There was an error.  Please try again later.";
            }

            return response;
        }

        public Response<DepositReciept> Deposit(Account account, decimal amount)
        {            
            var response = new Response<DepositReciept>();

            try
            {
                if (amount <= 0)
                {
                    response.Success = false;
                    response.Message = "Must deposit a positive value.";
                }
                else
                {
                    account.Balance += amount;
                    var repo = new AccountRepository();
                    repo.UpdateAccount(account);
                    response.Success = true;

                    response.Data = new DepositReciept();
                    response.Data.AccountNumber = account.AccountNumber;
                    response.Data.DepositAmount = amount;
                    response.Data.NewBalance = account.Balance;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public Response<WithDrawReciept> WithDraw(Account account, decimal amount)
        {
            var response = new Response<WithDrawReciept>();

            try
            {
                if (amount <= 0)
                {
                    response.Success = false;
                    response.Message = "Must withdraw a positive value.";
                }
                else
                {
                    account.Balance -= amount;
                    var repo = new AccountRepository();
                    repo.UpdateAccount(account);
                    response.Success = true;

                    response.Data = new WithDrawReciept();
                    response.Data.AccountNumber = account.AccountNumber;
                    response.Data.WithdrawAmount = amount;
                    response.Data.NewBalance = account.Balance;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public Response<TransferReciept> Transfer(Account accountT, Account accountR, decimal amount)
        {   
            var response = new Response<TransferReciept>();

            try
            {
                if (amount <= 0)
                {
                    response.Success = false;
                    response.Message = "Must transfer a positive value.";
                }
                else
                {
                    accountT.Balance -= amount; //update transferring account balance
                    var repo = new AccountRepository();
                    repo.UpdateAccount(accountT);
                    
                    accountR.Balance += amount; //update receiving account balance
                    repo.UpdateAccount(accountR);
                    response.Success = true;

                    response.Data = new TransferReciept();
                    response.Data.AccountNumberT = accountT.AccountNumber;
                    response.Data.AccountNumberR = accountR.AccountNumber;
                    response.Data.NewBalanceT = accountT.Balance;
                    response.Data.NewBalanceR = accountR.Balance;
                    response.Data.TransferAmount = amount;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
