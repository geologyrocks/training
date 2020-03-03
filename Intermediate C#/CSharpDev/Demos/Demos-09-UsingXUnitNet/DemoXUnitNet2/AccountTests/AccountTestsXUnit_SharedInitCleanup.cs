using System;
using System.Data.SqlClient;
using Xunit;
using AccountLibrary;

namespace AccountTests
{
    // Imagine all account tests need a SqlConnection object.
    // We can define a fixture class to create/dispose the SqlConnection object once only.
    public class DatabaseFixture : IDisposable
    {
        public SqlConnection Db { get; private set; }

        // Equivalent to [ClassInitialize] in MSTest.
        public DatabaseFixture()
        {
            // Create SqlConnection object and maybe populate test database.
            // Db = new SqlConnection("MyConnectionString");
            // ...
        }

        // Equivalent to [ClassCleanup] in MSTest.
        public void Dispose()
        {
            // Maybe delete test data in database.
            // ...
        }
    }

    public class AccountTestsXUnit_SharedInitCleanup : IClassFixture<DatabaseFixture>, IDisposable
    {
        private Account account;
        private float initial;

        private DatabaseFixture databaseFixture;

        public AccountTestsXUnit_SharedInitCleanup(DatabaseFixture databaseFixture)
        {
            initial = 200;
            account = new Account(initial);
            this.databaseFixture = databaseFixture;
        }

        public void Dispose()
        {
        }

        [Fact]
        public void Account_WhenCreated_TheAmountIsStoredAsTheBalance()
        {
            float expected = initial;
            float actual = account.Balance;
            Assert.Equal(expected, actual);

            // We can use the shared databaseFixture.Db object if needed...
            SqlCommand command = new SqlCommand("select * from products", databaseFixture.Db);
            // ...
        }

        [Fact]
        public void Account_DepositPositiveFunds_Succeeds()
        {
            float amount = 300;

            account.Deposit(amount);

            float expected = initial + amount;
            float actual = account.Balance;
            Assert.Equal(expected, actual);

            // We can use the shared databaseFixture.Db object if needed...
            SqlCommand command = new SqlCommand("select * from categories", databaseFixture.Db);
            // ...
        }
    }
}