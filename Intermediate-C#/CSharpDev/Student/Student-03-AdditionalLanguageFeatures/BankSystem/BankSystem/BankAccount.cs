using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class BankAccountEventArgs : EventArgs
    {
        private double transactionAmount;
        private DateTime timestamp = DateTime.Now;

        public BankAccountEventArgs(double transactionAmount) => this.transactionAmount = transactionAmount;

        public override string ToString() => $"Transaction amount {transactionAmount}, timestamp {timestamp}";
    }

    public class BankAccount
    {   
        // Property
        public string AccountHolder { get; internal set; }
        public double Balance { get; internal set; }
        // Fields.
        private string _accountHolder;
        private double _balance = 0;
        private List<double> transactions = new List<double>();

        // Events.
        public event EventHandler<BankAccountEventArgs> ProtectionLimitExceeded;
        public event EventHandler<BankAccountEventArgs> Overdrawn;

        // Constructor.
        public BankAccount(){}


        // Constructor to initialize a BankAccount from a stream.
        public BankAccount(StreamReader reader)
        {
            // Read account holder from file, as a single line.
            _accountHolder = reader.ReadLine();

            // Read balance from file, as a single line, and convert to a double.
            _balance = double.Parse(reader.ReadLine());

            // Read transactions from file, and split at spaces.
            string allTxStr = reader.ReadLine();
            string[] splitTxStr = allTxStr.Split(' ');

            // Loop through the transaction strings read from file, and add each to the transactions list (as a double).
            foreach (string txstr in splitTxStr)
            {
                if (!string.IsNullOrEmpty(txstr))
                {
                    double tx = double.Parse(txstr);
                    transactions.Add(tx);
                }
            }
        }

        // Method to write a BankAccount to a stream.
        public void WriteToStream(StreamWriter writer)
        {
            // Write account holder to file, as a single line.
            writer.WriteLine("{0}", _accountHolder);

            // Write balance to file, as a single line.
            writer.WriteLine("{0}", _balance);

            // Write transactions to file (space-separated), as a single line.
            foreach (double transaction in transactions)
            {
                writer.Write("{0} ", transaction);
            }
            // Append a newline after writing the last transaction amount.
            writer.WriteLine();
        }

        // Methods.
        public void Deposit(double amount)
        {
            // If attempt to deposit more than 100000, disallow this deposit!
            if (amount > 100000)
            {
                throw new BankException("Cannot deposit more than 100000.", _accountHolder, amount);
            }

            // Deposit money, and store transaction amount.
            _balance += amount;
            transactions.Add(amount);

            // If balance has exceeded the government's protection limit, raise a ProtectionLimitExceeded event.
            if (_balance >= 50000 && ProtectionLimitExceeded != null)
            {
                ProtectionLimitExceeded(this, new BankAccountEventArgs(amount));
            }
        }

        public void Withdraw(double amount)
        {
            // If account is already overdrawn, disallow this withdrawal!
            if (_balance < 0)
            {
                throw new BankException("Cannot withdraw from an overdrawn account.", _accountHolder, amount);
            }

            // Withdraw money, and store transaction amount as a negative amount (to denote a withdrawal). 
            _balance -= amount;
            transactions.Add(-amount);

            // If account is now negative, raise an Overdrawn event.
            if (_balance < 0 && Overdrawn != null)
            {
                Overdrawn(this, new BankAccountEventArgs(amount));
            }
        }

        public double GetBalance()
        {
            return _balance;
        }

        // Return a read-only wrapper for the transaction list. Prevents client app from meddling...
        public ReadOnlyCollection<double> Transactions => transactions.AsReadOnly();

        public override string ToString() => $"Account {AccountHolder}, balance {Balance:C}";
    }
}
