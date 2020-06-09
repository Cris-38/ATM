using System;

namespace ATM
{
    public class CheckingAccount
    {
        #region Fields
        private decimal _balance; 
        #endregion

        #region propetys
        public string Owner { get; set; }

        //Read only propety for de balance
        public decimal Balance 
        {
            get
            {
                return _balance;
            }
        }
        #endregion

        #region Constructors
        // first constructor zero parameters create an object with second
        // constuctor that has defuald values
        public CheckingAccount() : this("John Doe", 10)
        {

        }
        //Second constructer creates an object with 2 parameters 
        public CheckingAccount(string name, decimal initialBalance)
        {
            Owner = name;

            MakeDeposit(initialBalance);
        }
        #endregion

        #region Methods
        //Makes a deposit to account balance
        public void MakeDeposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Amount of deposit must be positive");
            }
            _balance += amount;
        }
        //Makes withdrawles from account balance
        public void MakeWithdrawal(decimal amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            _balance -= amount;
        }
        #endregion


    }
}
