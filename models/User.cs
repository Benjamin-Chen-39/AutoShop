using System;
namespace AutoStore
{
    public class User
    {
        private CheckingAccount _checkingAccount;

        public CheckingAccount CheckingAccount { get { return _checkingAccount; } }

        public User(decimal initialAmount)
        {
            _checkingAccount = new CheckingAccount(initialAmount);
        }
    }
}