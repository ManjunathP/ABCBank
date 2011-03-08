using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ABCBank;

namespace TestABCBank
{
    [TestClass]
    public class TestABCBank
    {

        User user;
       
        [TestInitialize]
        public void Init()
        {
            user = new User("sanjeev", "s.mishra@prowareness.nl");            
        }


        [TestMethod]
        public void TestShouldBeAbleToOpenSavingsAccountForAUser()
        {
            Account savingsAccount = Bank.OpenAccount(user, AccountType.Savings);
            Assert.AreSame(user, savingsAccount.getUser());
            Assert.IsNotNull(savingsAccount.getId());
            Assert.IsTrue(savingsAccount.getId().StartsWith(AccountType.Savings.ToString()));
           
        }

        [TestMethod]
        public void TestShouldBeAbleToOpenCurrentAccountForAUser()
        {           
            Account currentAccount = Bank.OpenAccount(user, AccountType.Current);
            Assert.AreSame(user, currentAccount.getUser());
            Assert.IsNotNull(currentAccount.getId());
            Assert.IsTrue(currentAccount.getId().StartsWith(AccountType.Current.ToString()));
        }

        [TestMethod]
        public void TestShouldBeAbleToOpenAccountForAUser()
        {
            User user = new User("manjunath", "m.hirapurshi@prowareness.nl");
            Account account = Bank.OpenAccount(user, AccountType.Current);

            Assert.AreSame(user, account.getUser());
            Assert.IsNotNull(account.getId());
            Assert.IsTrue(account.getId().StartsWith(AccountType.Current.ToString()));
        }

        [TestMethod]
        public void TestToCheckIftwoAccountsGenerateDifferentAccountNumber()
        {
            User user = new User("sanjeev", "s.mishra@prowareness.nl");
            Account savingsAccount = Bank.OpenAccount(user, AccountType.Savings);

            User user1 = new User("manjunath", "m.hirapurshi@prowareness.nl");
            Account savingsAccount1 = Bank.OpenAccount(user1, AccountType.Savings);

            Assert.AreNotEqual<string>(savingsAccount.getId(), savingsAccount1.getId());
            

        }


        [TestMethod]
        public void TestUserShouldBeAbleToDepositAmounttoAccount()
        {
            Account account = Bank.OpenAccount(user, AccountType.Current);
            double previousBalance= account.GetBalance();
            double DepositAmount = 30;
            account.Deposit(DepositAmount);
            Assert.AreEqual(previousBalance + DepositAmount, account.GetBalance());
            
        }

        [TestMethod]
        public void TestUserShouldBeAbleToWithdrawAmountFromAccount()
        {
            Account account = Bank.OpenAccount(user, AccountType.Current);
            account.Deposit(50);
            double previousBalance = account.GetBalance();
            double WithDrawAmount = 30;
            
            account.WithDraw(WithDrawAmount);
            Assert.AreEqual(previousBalance - WithDrawAmount, account.GetBalance());

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestUserShouldNotBeAbleToWithdrawAmountBeyondPreviousBalanceFromAccount()
        {
            Account account = Bank.OpenAccount(user, AccountType.Current);
            double previousBalance = account.GetBalance();
            double WithDrawAmount = previousBalance + 1.0;
            
                account.WithDraw(WithDrawAmount);            
            
            
            Assert.AreEqual(previousBalance, account.GetBalance());
            
            

        }




    }
}
