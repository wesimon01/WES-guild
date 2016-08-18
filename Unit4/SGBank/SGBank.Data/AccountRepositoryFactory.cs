using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;


namespace SGBank.Data
{
    public class AccountRepositoryFactory
    {
            public static IAccountRepository CreateAccountRepository(string Type)
            {
                switch (Type.ToUpper())
                {
                    case "A":
                        return new AccountRepository();
                    case "M":
                        return new MockRepository();                 
                    default:
                        throw new NotSupportedException(String.Format("{0} not supported!", Type));
                }
            }
        }
    }








