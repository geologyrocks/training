using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;

namespace UnitTestProject1
{
    [TestClass]
    public class AccountTests
    {
        private Account account;
        private float initial;

        [AssemblyInitialize]
        public static void PerAssemblyInit(TestContext context)
        {
            // Runs once only, before first test in assembly.
        }

        [AssemblyCleanup]
        public static void PerAssemblyCleanup()
        {
            // Runs once only, after last test in assembly.
        }

        [ClassInitialize]
        public static void PerClassInit(TestContext context)
        {
            // Runs once only, before first test in class.
        }

        [ClassCleanup]
        public static void PerClassCleanup()
        {
            // Runs once only, after last test in class.
        }

        [TestInitialize]
        public void PerTestInit()
        {
            initial = 200;
            account = new Account(initial);
        }

        [TestCleanup]
        public void PerTestCleanup()
        {
            // Nothing to do in this example.
        }

        [TestMethod]
        public void Account_WhenCreated_TheAmountIsStoredAsTheBalance()
        {
            float expected = initial;
            float actual = account.Balance;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Account_DepositPositiveFunds_Succeeds()
        {
            float amount = 300;

            account.Deposit(amount);

            float expected = initial + amount;
            float actual = account.Balance;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Ignore]
        public void Account_DepositTooMuchFunds_Fails()
        {
            float amount = 30000;
            account.Deposit(amount);
        }

        [TestMethod]
        public void Account_DepositTooLittle_Fails()
        {
            float amount = 1;
            account.Deposit(amount);
            Assert.Inconclusive("TODO: Decide if OK");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Account_CreateWithInitialAmountOf0_ThrowsException()
        {
            float initial = 0;
            Account a = new Account(initial);
        }

        [TestMethod]
        public void Account_CreateWithInitialAmountOf0_ThrowsExceptionWithMessage()
        {
            try
            {
                float initial = 0;
                Account a = new Account(initial);
                Assert.Fail("Expected exception did not occur");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
                Assert.AreEqual("Gimme some dosh!", ex.Message);
            }
        }
    }
}
