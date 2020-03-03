using System;
using Xunit;
using Moq;
using BankingLibrary;

namespace BankingTests
{
    public class BankServiceTests
    {
        Mock<IRestClient> mockRestClient;
        Mock<IUserInterface> mockUserInterface;
        BankService fixture;
        Account acc123, acc456;

        public BankServiceTests()
        {
            // Create a mock for IRestClient.
            mockRestClient = new Mock<IRestClient>();

            // Create a mock for IUserInterface.
            mockUserInterface = new Mock<IUserInterface>();

            // Inject mock objects into a BankService instance.
            fixture = new BankService(mockRestClient.Object, mockUserInterface.Object);

            // Create and initialize some handy Account objects.
            acc123 = new Account { Name = "David", Id = 123 };
            acc456 = new Account { Name = "Sarah", Id = 456 };
            acc123.Deposit(1000);
            acc456.Deposit(2000);
        }

        [Fact]
        public void DepositIntoAccount_ExistingAccount_IncreasesBalance()
        {
            // Arrange: Set expectations on mock objects.
            mockUserInterface.Setup(m => m.PromptForInteger("Account id")).Returns(123);
            mockRestClient.Setup(m => m.GetById(123)).Returns(acc123);
            mockUserInterface.Setup(m => m.PromptForInteger("Amount to deposit")).Returns(50);
            mockRestClient.Setup(m => m.Update(123, acc123)).Returns(true);

            // Act.
            fixture.DepositIntoAccount();

            // Assert.
            Assert.Equal(1050, acc123.Balance);

            // Verify expected methods were invoked on the mock objects.
            mockRestClient.Verify(m => m.GetById(123));
            mockUserInterface.Verify(m => m.PromptForInteger(It.IsAny<string>()), Times.Exactly(2));
            mockRestClient.Verify(m => m.Update(123, acc123));
        }

        [Fact]
	    public void DepositIntoAccount_NonExistingAccount_ExceptionOccurs()
        {
            // Arrange: Set expectations on mock object.
            mockUserInterface.Setup(m => m.PromptForInteger("Account id")).Returns(123);
            mockRestClient.Setup(m => m.GetById(123)).Returns<Account>(null);

            // Act.
            Assert.Throws<ArgumentException>(() =>
            {
                fixture.DepositIntoAccount();
            });

            // Verify expected methods were invoked on the mock objects.
            mockRestClient.Verify(m => m.GetById(123));
            mockUserInterface.Verify(m => m.PromptForInteger(It.IsAny<string>()), Times.Once);
            mockRestClient.Verify(m => m.Update(123, It.IsAny<Account>()), Times.Never);
        }

        [Fact]
        public void WithdrawFromAccount_ExistingAccount_DdecreasesBalance()
        {
            // Arrange: Set expectations on mock objects.
            mockUserInterface.Setup(m => m.PromptForInteger("Account id")).Returns(123);
            mockRestClient.Setup(m => m.GetById(123)).Returns(acc123);
            mockUserInterface.Setup(m => m.PromptForInteger("Amount to withdraw")).Returns(50);
            mockRestClient.Setup(m => m.Update(123, acc123)).Returns(true);

            // Act.
            fixture.WithdrawFromAccount();

            // Assert.
            Assert.Equal(950, acc123.Balance);

            // Verify expected methods were invoked on the mock objects.
            mockRestClient.Verify(m => m.GetById(123));
            mockUserInterface.Verify(m => m.PromptForInteger(It.IsAny<string>()), Times.Exactly(2));
            mockRestClient.Verify(m => m.Update(123, acc123));
        }

        [Fact]
	    public void WithdrawFromAccount_NonExistingAccount_ExceptionOccurs()
        {
            // Arrange: Set expectations on mock object.
            mockUserInterface.Setup(m => m.PromptForInteger("Account id")).Returns(123);
            mockRestClient.Setup(m => m.GetById(123)).Returns<Account>(null);

            // Act.
            Assert.Throws<ArgumentException>(() =>
            {
                fixture.WithdrawFromAccount();
            });

            // Verify expected methods were invoked on the mock objects.
            mockRestClient.Verify(m => m.GetById(123));
            mockUserInterface.Verify(m => m.PromptForInteger(It.IsAny<string>()), Times.Once);
            mockRestClient.Verify(m => m.Update(123, It.IsAny<Account>()), Times.Never);
        }

        [Fact]
        public void TransferFunds_ExistingAccounts_AmountTransferred()
        {
            // Arrange: Set expectations on mock objects.
            mockUserInterface.Setup(m => m.PromptForInteger("Account id #1")).Returns(123);
            mockUserInterface.Setup(m => m.PromptForInteger("Account id #2")).Returns(456);
            mockUserInterface.Setup(m => m.PromptForInteger("Amount to transfer")).Returns(50);

            mockRestClient.Setup(m => m.GetById(123)).Returns(acc123);
            mockRestClient.Setup(m => m.GetById(456)).Returns(acc456);

            mockRestClient.Setup(m => m.Update(123, acc123)).Returns(true);
            mockRestClient.Setup(m => m.Update(456, acc456)).Returns(true);

            // Act.
            fixture.TransferFunds();

            // Assert.
            Assert.Equal(950, acc123.Balance);
            Assert.Equal(2050, acc456.Balance);

            // Verify expected methods were invoked on the mock objects.
            mockRestClient.Verify(m => m.GetById(It.IsAny<int>()), Times.Exactly(2));
            mockUserInterface.Verify(m => m.PromptForInteger(It.IsAny<string>()), Times.Exactly(3));
            mockRestClient.Verify(m => m.Update(123, acc123), Times.Once);
            mockRestClient.Verify(m => m.Update(456, acc456), Times.Once);
        }
    }
}
