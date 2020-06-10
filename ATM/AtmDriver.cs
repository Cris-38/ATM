using System;
using System.Text;

namespace ATM
{
    class AtmDriver
    {
        static void Main(string[] args)
        
        {
            Console.OutputEncoding = Encoding.UTF8;

            string transactionType;
            int choice;
            decimal amount;
            int transactionCount = 0;

            CheckingAccount account1 = new CheckingAccount("cris", 100);
            SavingsAccount account2 = new SavingsAccount("cris", 200);

            Console.WriteLine($"Greetings {account1.Owner}, how may I serve you?");

            do
            {
                Console.Write("Do you want to: (D)eposit, (W)ithdraw, (C)heck Balance, (T)ransfer, (Q)uit? ");
                transactionType = Console.ReadLine().ToUpper();

                switch (transactionType)
                {
                    case "D":
                        Console.Write("Deposit to: (1)Checking or (2)Savings? ");
                        choice = int.Parse(Console.ReadLine());
                        Console.Write("How many credits do you want to Deposit? ");
                        amount = Convert.ToDecimal(Console.ReadLine());
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
                    case "W":
                        Console.Write("Withdraw from: (1)Checking or (2)Savings? ");
                        choice = int.Parse(Console.ReadLine());
                        Console.Write("How many credits do you want to withdraw? ");
                        amount = Convert.ToDecimal(Console.ReadLine());
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
                    case "C":
                        DisplayBalance(account1.Balance, account2.Balance);
                        break;
                    case "T":
                        Console.Write("Transfer from: (1)Checking to Savings or (2)Savings to Checking? ");
                        choice = int.Parse(Console.ReadLine());

                        Console.Write("Amount to transfer? ");
                        amount = int.Parse(Console.ReadLine());
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
                    case "Q":
                        DisplayBalance(account1.Balance, account2.Balance);
                        Console.WriteLine("Thank you for your business. Goodbye!");
                        Console.WriteLine("Press any key to exit!");
                        break;
                }

                if (transactionCount == 5)
                {
                    account2.Interest();
                    transactionCount = 0;
                    Console.WriteLine("Interest calculated!");
                    DisplayBalance(account1.Balance, account2.Balance);
                }

                Console.WriteLine("********************************************************************************************");
            }
            while (transactionType != "Q");
            Console.ReadKey();
        }
        private static void DisplayBalance(decimal amount1, decimal amount2)
        {
            Console.WriteLine($"Balance Checkings Account: { amount1:c}");
            Console.WriteLine($"Balance Savings Account: {amount2:c}");
        }
    }
}
