using System;

namespace ATM
{
    public class SavingsAccount
    {
        #region Fields
        private decimal _balance;
        #endregion

        #region Propetys        
        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>
        /// The owner.
        /// </value>
        public string Owner { get; set; }

        /// <summary>
        /// Gets the balance.
        /// </summary>
        /// <value>
        /// The balance.
        /// </value>
        public decimal Balance
        {
            get
            {
                return _balance;
            }
        }
        #endregion

        #region Constructers       
        /// <summary>
        /// Initializes a new instance of the <see cref="SavingsAccount"/> class.
        /// </summary>
        public SavingsAccount() : this ("John doe", 10)

        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="SavingsAccount"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="amount">The amount.</param>
        public SavingsAccount(string name, decimal amount)
        {
            Owner = name;
            MakeDeposit(amount);

        }
        #endregion

        #region Methods        
        /// <summary>
        /// Makes the deposit.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <exception cref="Exception">Amount of deposit must be positive</exception>
        public void MakeDeposit(decimal amount)
        {

            if (amount <= 0)
            {
                throw new Exception("Amount of deposit must be positive");
            }
            _balance += amount;
        }
        /// <summary>
        /// Makes the withdrawal.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <exception cref="Exception">Amount of withdrawal must be positive</exception>
        /// <exception cref="InvalidOperationException">Not sufficient funds for this withdrawal</exception>
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
        /// <summary>
        /// Interests this instance.
        /// </summary>
        /// <returns></returns>
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