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
        private const string storageFolder = @"C:\CSharpDev\Temp";

        public BankAccount this[int accountID]
        {
            get => accounts[accountID]; 
            set => accounts[accountID] = value; 
        }

        public bool ContainsAccountID(int accountID) => accounts.ContainsKey(accountID);

        public bool ContainsAccount(BankAccount account) => accounts.ContainsValue(account);

        public int NumberOfAccounts => accounts.Count; 
        
        // Save all accounts to storage folder.
        public void SaveAccounts()
        {
            // Loop through all dictionary entries, and write each one to a separate file.
            foreach (KeyValuePair<int, BankAccount> entry in accounts)
            {
                // Get pathname, in format "C:\CSharpDev\Temp\<accountID>.txt".
                string filepath = $@"{storageFolder}\{entry.Key}.txt";

                // If the file already exists, ask user whether to overwrite or skip.
                if (File.Exists(filepath))
                {
                    Console.Write("{0} already exists. Overwrite or skip [O|S]? ", filepath);
                    string overwrite = Console.ReadLine();
                    if (overwrite.ToUpper()[0] != 'O')
                    {
                        // Skip this BankAccount, go onto next loop iteration for next BankAccount.
                        continue;
                    }
                }

                // Write this BankAccount to file.
                BankAccount account = entry.Value;
                StreamWriter fs = null;
                try
                {
                    fs = new StreamWriter(filepath);
                    account.WriteToStream(fs);
                    Console.WriteLine("Written {0} to disk.", filepath);
                }
                catch (IOException)
                {
                    Console.WriteLine("Exception occurred writing {0}.", filepath);
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Close();
                    }
                }
            }
        }

        // Load all accounts from storage folder.
        public void LoadAccounts()
        {
            // Get all the files in the C:\CSharpDev\Temp folder.
            foreach (string filepath in Directory.EnumerateFiles(storageFolder, "*.txt"))
            {
                int numberStartPos = filepath.LastIndexOf('\\') + 1;
                int dotPos = filepath.LastIndexOf('.');

                string filename = filepath.Substring(numberStartPos, dotPos - numberStartPos);

                StreamReader fs = null;
                try
                {
                    fs = new StreamReader(filepath);
                    accounts[int.Parse(filename)] = new BankAccount(fs);
                    Console.WriteLine("Loaded {0} from disk.", filepath);
                }
                catch (IOException)
                {
                    Console.WriteLine("Exception occurred writing {0}.", filepath);
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Close();
                    }
                }
            }
        }
    }
}
