using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ABCBank
{
    public enum AccountType { Savings = 1, Current = 2, Recurring = 3 };
    public class Account
    {        

        protected static int _Id;
        protected string _AccountId;
        protected User _user;
        protected double _Balance;
        protected  AccountType _type;

        public Account(User user, AccountType type)
        {
            _user = user;
            _Id++;
            
            _type = type;
            _AccountId = type.ToString() + _Id.ToString();
        }

        public virtual User getUser()
        {
            return _user;
        }

        public virtual string getId()
        {

            return _AccountId;
        }

        public virtual void Deposit(double DepositAmount)
        {
            _Balance += DepositAmount;
        }

        public virtual double GetBalance()
        {
            return _Balance;
        }


        public virtual void WithDraw(double WithDrawAmount)
        {
            if (WithDrawAmount > _Balance)
               
                throw new Exception("Insufficient Funds.");

            _Balance -= WithDrawAmount;
        }
    }
}
