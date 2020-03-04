using System.Collections.Generic;

namespace BankingLibrary
{
    public interface IRestClient
    {
        List<Account> GetAll();
        Account GetById(int id);
        Account Insert(Account acc);
        bool Update(int id, Account acc);
        bool Delete(int id);
    }
}
