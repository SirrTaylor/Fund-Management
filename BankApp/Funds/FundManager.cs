using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Funds
{
    public class FundManager
    {
        private decimal balance;
        private bool isActive;
        private bool isClosed;
        private DateTime lastOperationTime;

        public FundManager()
        {
            balance = 0;
            isActive = true;
            isClosed = false;
            lastOperationTime = DateTime.Now;
        }


        public decimal GetBalance()
        {
            return balance;
        }

        public bool IsActive
        {
            get { return isActive; }
        }

        //Deposit
        public void Deposit(decimal amount)
        {
            if (isClosed)
            {
                Console.WriteLine("Account is closed. Deposit not allowed.");
                return;
            }

            if (amount > 0)
            {
                balance += amount;
                lastOperationTime = DateTime.Now;
                Console.WriteLine($"Deposited {amount:C}. New balance: {balance:C}");
            }else
            {
                balance = 0;
                Console.WriteLine("Incorrect value entered!");
            }
           
            if (!isActive)
            {
                ActivateAccount();
            }
        }

        //Withdraw
        public void Withdraw(decimal withdraw_amount, bool isIdentityVerified)
            {
                if (isClosed)
                {
                    Console.WriteLine("Account is closed. Withdrawal not allowed.");
                    return;
                }

                if (!isIdentityVerified)
                {
                    Console.WriteLine("Identity verification failed. Withdrawal not allowed.");
                    return;
                }

                if (balance < withdraw_amount)
                {
                    balance.Equals(null);
                    Console.WriteLine("Insufficient funds.");
                }
                else
                {
                    balance -= withdraw_amount;
                    lastOperationTime = DateTime.Now;
                    Console.WriteLine($"Withdrawn {withdraw_amount:C}. New balance: {balance:C}");
                    if (!isActive)
                    {
                        ActivateAccount();
                    }
                }  
        }

        // Close Account
        public void CloseAccount(bool isIdentityVerified)
        {
            if (isIdentityVerified) { 
                isClosed = true;
                isActive = false;
                Console.WriteLine("Account closed.");
            }
            else
            {
                isClosed = false;
                Console.WriteLine("Not account holder.");
            }
        }

        // Deactivate Account 
        public void CheckAndDeactivate(TimeSpan inactivityPeriod)
        {
            if (isClosed || !isActive) return;

            if (DateTime.Now - lastOperationTime > inactivityPeriod)
            {
                isActive = false;
                Console.WriteLine("Account deactivated due to inactivity.");
                
            }
          
        }

        // Activate Account
        private void ActivateAccount()
        {
            isActive = true;
            string message = "Account Reactivated";
            Console.WriteLine(message);
            PerformReactivationAction();
        }

        public string PerformReactivationAction()
        {
            string message = "Account Reactivated";
            return message;
        }

    }
}
