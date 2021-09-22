using System;
namespace AutoStore
{
    public class CheckingAccount
    {
        private decimal _balance;
        public void AddFunds(decimal deposit)
        {
            _balance += deposit;
        }

        public void WithdrawFunds(decimal withdrawal)
        {
            if (this._balance >= withdrawal)
            {
                this._balance -= withdrawal;
            }

            else
            {
                Console.WriteLine("Insufficient funds");
            }
        }
    }
}