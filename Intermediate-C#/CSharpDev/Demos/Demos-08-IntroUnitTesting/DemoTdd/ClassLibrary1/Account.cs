using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Account
    { 
        public float Balance { get; private set; }
        public Account(float amount)
        {
            if (amount == 0)
                throw new ArgumentException("Gimme some dosh!");

            Balance = amount;
        } 
        
        public void Deposit(float amount)
        {
            if (amount < 30000 && amount > 0)
            {
                Balance += amount;
            }
            else if (amount <= 0)
            {
                throw new ArgumentException($"Deposit amount {amount} must be greater than 0.");
            }
            else
            {
                throw new ArgumentException($"Deposit amount {amount} is over the permitted deposit threshold.");
            }
        }
    }
}
