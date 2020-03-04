using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class Bank : IEnumerable<KeyValuePair<int, BankAccount>>
    {
        private Dictionary<int, BankAccount> _accounts = new Dictionary<int, BankAccount>();

        public BankAccount this[int accountID]
        {
            get => _accounts[accountID]; 
            set => _accounts[accountID] = value; 
        }

        public bool ContainsAccountID(int accountID) => _accounts.ContainsKey(accountID);

        public bool ContainsAccount(BankAccount account) => _accounts.ContainsValue(account);

        public IEnumerator<KeyValuePair<int, BankAccount>> GetEnumerator()
        {
            return _accounts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _accounts.GetEnumerator();
        }
    }
}
