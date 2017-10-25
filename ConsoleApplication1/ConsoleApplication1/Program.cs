using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    /// <summary>
    /// Solution by Joseph Redimerio.
    /// Assumptions:    Simple interest rate model, calculated yearly.
    ///                 Negative inputs to Test() function are automatically converted to positive inputs.
    /// </summary>
    public class BankAccount
    {
        private double Balance { get; set; }
        private double YearlyInterestRate { get; set; }

        public BankAccount(double balance, double yearlyInterest)
        {
            Balance = Math.Abs(balance);
            YearlyInterestRate = Math.Abs(yearlyInterest);
        }

        
        public void Withdraw(double amount = 0.0)
        {
            if (amount > Balance)
                throw new Exception(string.Format("Withdraw() exception :: amount {0} > Balance {1}", amount, Balance));

            Balance = Balance - Math.Abs(amount);
        }

        public void Deposit(double amount = 0.0)
        {            
            Balance = Balance + Math.Abs(amount);
        }

        // Assumption: Interest is paid annualy
        public void AddInterest()
        {
            Balance = Balance + (Balance * (YearlyInterestRate/100));
        }

        public double GetBalance()
        {
            return Balance;
        }

    }


    class Program
    {
        public static void Test(string testName, double balance, double yearlyInterest, double deposit, double withdraw)
        {
            try
            {
                Console.WriteLine("Running {0}", testName);
                BankAccount BankAccount = new BankAccount(balance, yearlyInterest);
                BankAccount.Deposit(deposit);
                BankAccount.AddInterest();
                BankAccount.Withdraw(withdraw);
                Console.WriteLine(" Balance = {0} \n", BankAccount.GetBalance());
            }
            catch (Exception e)
            {
                throw new Exception(testName + " :: " + e.Message);
            }
        }

        static void Main(string[] args)
        {
            try
            {
                //Note: Negative values are automatically converted to positive values (absolute).
                Test("TEST1", 2000, 4.5, 500, 398.5);
                Test("TEST2", 2850.6, 4, 500.75, 398);
            }
            catch (Exception e)
            {
                Console.WriteLine("Main :: " + e.Message);
            }

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadLine();
        }
    }
}
