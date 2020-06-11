using System;
using System.Text;

namespace ATM
{
    class AtmDriver
    {
        static void Main(string[] args)
        
        {
            //OutputEncoding for the euro sign
            Console.OutputEncoding = Encoding.UTF8;

            //Declare variablres
            string transactionType;
            int choice;
            decimal amount;
            int transactionCount = 0;

            //Creating the checkaccount and the savingsaccount
            CheckingAccount account1 = new CheckingAccount("cris", 100);
            SavingsAccount account2 = new SavingsAccount("cris", 200);

            //Greeting account owner
            Console.WriteLine($"Greetings {account1.Owner}, how may I serve you?");

            //Do-while loop for transactions till user quits
            do
            {
                Console.Write("Do you want to: (D)eposit, (W)ithdraw, (C)heck Balance, (T)ransfer, (Q)uit? ");
                transactionType = Console.ReadLine().ToUpper();

                switch (transactionType)
                {
                    //Deposit 
                    case "D":
                        Console.Write("Deposit to: (1)Checking or (2)Savings? ");
                        choice = int.Parse(Console.ReadLine());
                        Console.Write("How many credits do you want to Deposit? ");
                        amount = Convert.ToDecimal(Console.ReadLine());
                        //Deposit to checkings account
                        if (choice == 1)
                        {
                            try
                            {
                                account1.MakeDeposit(amount);
                                transactionCount++;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        //deposit to savingsaccount
                        else
                        {
                            try
                            {
                                account2.MakeDeposit(amount);
                                transactionCount++;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        DisplayBalance(account1.Balance, account2.Balance);
                        break;
                    //Withdraw
                    case "W":
                        Console.Write("Withdraw from: (1)Checking or (2)Savings? ");
                        choice = int.Parse(Console.ReadLine());
                        Console.Write("How many credits do you want to withdraw? ");
                        amount = Convert.ToDecimal(Console.ReadLine());
                        //Witdraw from checkingsaccount
                        if (choice == 1)
                        {
                            try
                            {
                                account1.MakeWithdrawal(amount);
                                transactionCount++;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                        }
                        //Withdraw from savingsaccount
                        else
                        {
                            try
                            {
                                account2.MakeWithdrawal(amount);
                                transactionCount++;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        DisplayBalance(account1.Balance, account2.Balance);
                        break;
                    //Check balance
                    case "C":
                        DisplayBalance(account1.Balance, account2.Balance);
                        break;
                    //Transfer
                    case "T":
                        Console.Write("Transfer from: (1)Checking to Savings or (2)Savings to Checking? ");
                        choice = int.Parse(Console.ReadLine());

                        Console.Write("Amount to transfer? ");
                        amount = int.Parse(Console.ReadLine());
                        //Transfer from checkingsaccount to savingsaccount
                        if (choice == 1)
                        {
                            try
                            {
                                account1.MakeWithdrawal(amount);
                                account2.MakeDeposit(amount);
                                transactionCount++;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        //Transfer from savingsaccount to checkingsaccount
                        else
                        {
                            try
                            {
                                account2.MakeWithdrawal(amount);
                                account1.MakeDeposit(amount);
                                transactionCount++;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        DisplayBalance(account1.Balance, account2.Balance);
                        break;
                    //Quit
                    case "Q":
                        DisplayBalance(account1.Balance, account2.Balance);
                        Console.WriteLine("Thank you for your business. Goodbye!");
                        Console.WriteLine("Press any key to exit!");
                        break;
                }

                //Calculate interest
                if (transactionCount == 5)
                {
                    account2.Interest();
                    transactionCount = 0;
                    Console.WriteLine("Interest calculated!");
                    DisplayBalance(account1.Balance, account2.Balance);
                }

                Console.WriteLine("********************************************************************************************");
            }
            while (transactionType != "Q");//When user Quits
            Console.ReadKey();
        }
        /// <summary>
        /// Display the balances
        /// </summary>
        /// <param name="amount1"></param>
        /// <param name="amount2"></param>
        private static void DisplayBalance(decimal amount1, decimal amount2)
        {
            Console.WriteLine($"Balance Checkings Account: { amount1:c}");
            Console.WriteLine($"Balance Savings Account: {amount2:c}");
        }
    }
}
