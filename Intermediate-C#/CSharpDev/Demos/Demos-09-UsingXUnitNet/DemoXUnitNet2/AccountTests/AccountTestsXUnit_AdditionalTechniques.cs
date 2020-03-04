using System;
using Xunit;
using AccountLibrary;

namespace AccountTests
{
    public class AccountTestsXUnit_AdditionalTechniques
    {
        // Equivalent to [Ignore] in MSTest.
        [Fact(Skip="Demonstrate how to skip/ignore a test")]
        public void Account_DepositTooMuchFunds_Fails()
        {
            Account account = new Account(200);
            account.Deposit(30_000);
        }

        // No equivalent of Assert.Inconclusive() in xUnit.
        /*
        [Test]
        public void Account_DepositTooLittle_Fails()
        {
            Account account = new Account(200);
            account.Deposit(1);
            Assert.Inconclusive("TODO: Decide if OK");
        }
        */

        [Fact]
        // No equivalent of [ExpectedException] in xUnit, use Assert.Throws() instead.
        // [ExpectedException(typeof(ArgumentException))]
        public void Account_CreateWithInitialAmountOf0_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => {
                Account a = new Account(0);
            });
        }
        
        [Fact]
        public void Account_CreateWithInitialAmountOf0_ThrowsExceptionWithMessage()
        {
            try
            {
                Account a = new Account(0);

                // No Assert.Fail() in xUnit. Use Assert.True(false...) instead.
                // Assert.Fail("Expected exception did not occur");
                Assert.True(false, "Expected exception did not occur");
            }
            catch (Exception ex)
            {
                // No Assert.IsInstanceOfType() in xUnit. Use Assert.IsType<T>() instead.
                // Assert.IsInstanceOfType(ex, typeof(ArgumentException));
                Assert.IsType<ArgumentException>(ex);
                Assert.Equal("Gimme some dosh!", ex.Message);
            }
        }
    }
}
 