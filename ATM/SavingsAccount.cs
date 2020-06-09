using System;


namespace ATM
{
    public class SavingsAccount
    {
        #region Fields
        private decimal _balance;
        #endregion

        #region Propetys
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

        #region Constructers
        // first constructor zero parameters create an object with second
        // constuctor that has defuald values
        public SavingsAccount() : this ("John doe", 10)

        {

        }
        //Second constructer creates an object with 2 parameters
        public SavingsAccount(string name, decimal amount)
        {
            Owner = name;
            MakeDeposit(amount);

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
            if (_balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            _balance -= amount;

        }
        //Calcutates interest over the actual balance
        public decimal Interest()
        {
            decimal rate = _balance / 100;
            decimal interest = rate * 1;

            _balance += interest;
   
            return interest;
        } 
        #endregion
    }
}