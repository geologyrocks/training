using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    class Bank : Dictionary<int, BankAccount>
    {
        public Dictionary<int, BankAccount> BankAccounts = new Dictionary<int, BankAccount>();
    }
}
