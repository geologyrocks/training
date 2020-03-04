using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class Bank
    {
        private Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();

        public BankAccount this[int accountID]
        {
            get => accounts[accountID]; 
            set => accounts[accountID] = value; 
        }

        public bool ContainsAccountID(int accountID) => accounts.ContainsKey(accountID);

        public bool ContainsAccount(BankAccount account) => accounts.ContainsValue(account);
    }
}
