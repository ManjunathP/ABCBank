using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ABCBank
{
    public class Bank
    {
        

        public static Account OpenAccount(User user, ABCBank.AccountType type)
        {
            return new Account(user, type);

        }
    }
}
