using System;

namespace ATM
{
    public class CheckingAccount
    {
        #region Fields
        private decimal _balance;
        #endregion

        #region propetys

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

        #region Constructors        
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckingAccount"/> class.
        /// </summary>
        public CheckingAccount() : this("John Doe", 10)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckingAccount"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="initialBalance">The initial balance.</param>
        public CheckingAccount(string name, decimal initialBalance)
        {
            Owner = name;

            MakeDeposit(initialBalance);
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
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            _balance -= amount;
        }
        #endregion
    }
}
