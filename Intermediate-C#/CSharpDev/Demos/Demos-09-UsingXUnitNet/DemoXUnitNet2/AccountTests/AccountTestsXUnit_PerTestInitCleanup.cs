using System;
using Xunit;
using AccountLibrary;

namespace AccountTests
{
    public class AccountTestsXUnit_PerTestInitCleanup : IDisposable
    {
        private Account account;
        private float initial;

        // Equivalent to [TestInitialize] in MSTest.
        public AccountTestsXUnit_PerTestInitCleanup()
        {
            initial = 200;
            account = new Account(initial);
        }

        // Equivalent to [TestCleanup] in MSTest.
        public void Dispose()
        {
            // Nothing to do in this example.
        }

        [Fact]
        public void Account_WhenCreated_TheAmountIsStoredAsTheBalance()
        {
            float expected = initial;
            float actual = account.Balance;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Account_DepositPositiveFunds_Succeeds()
        {
            float amount = 300;

            account.Deposit(amount);

            float expected = initial + amount;
            float actual = account.Balance;
            Assert.Equal(expected, actual);
        }
    }
}
 