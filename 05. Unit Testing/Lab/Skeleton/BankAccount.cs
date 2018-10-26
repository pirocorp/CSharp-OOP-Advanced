namespace Skeleton
{
    using System;

    public class BankAccount
    {
        private decimal balance;

        public BankAccount()
        {
            
        }

        public BankAccount(decimal amount)
        {
            this.Balance = amount;
        }

        public decimal Balance
        {
            get => this.balance;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(this.Balance)} cannot be negative.", nameof(this.Balance));
                }

                this.balance = value;
            }
        }

        public decimal Account { get; set; }

        public void Deposit(decimal depositAmount)
        {
            if (depositAmount <= 0)
            {
                throw new ArgumentException($"Cannot deposit negative or zero money.");
            }

            this.Balance += depositAmount;
        }
    }
}