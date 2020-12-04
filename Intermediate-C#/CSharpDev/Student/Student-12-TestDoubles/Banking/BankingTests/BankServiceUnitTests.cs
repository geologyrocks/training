using System;
using Xunit;
using BankingLibrary;
using Moq;
using FluentAssertions;

namespace BankingLibrary.UnitTests
{
    public class BankServiceUnitTests
    {
        private Mock<IRestClient> restClientMock;
        private Mock<IUserInterface> userInterfaceMock;
        private BankService bs;
        private Account acc;
        public BankServiceUnitTests()
        {
            restClientMock = new Mock<IRestClient>();
            userInterfaceMock = new Mock<IUserInterface>();
            bs = new BankService(restClientMock.Object, userInterfaceMock.Object);
            acc = new Account() { Id = 123, Name = "Jess" };
            acc.Deposit(1000);
            acc.Deposit(2000);
            acc.Deposit(3000);
        }

        [Fact]
        public void DepositIntoAccount_IncreasesAccountBalance_IfAccountExists()
        {
            // Arrange
            userInterfaceMock.SetupSequence(x => x.PromptForInteger(It.IsAny<string>())).Returns(123).Returns(50);
            restClientMock.Setup(x => x.GetById(123)).Returns(acc).Verifiable();
            //restClientMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(true);
            //restClientMock.Setup(x => x.Update(It.IsAny<int>(),It.IsAny<Account>())).Returns(true);

            // Act
            bs.DepositIntoAccount();

            // Assert
            acc.Balance.Should().Be(6050);
            restClientMock.VerifyAll();
            userInterfaceMock.Verify(m => m.PromptForInteger(It.IsAny<string>()), Times.Exactly(2));
        }


        [Fact]
        public void DepositIntoAccount_Triggers_ArgumentException_If_Account_Does_Not_Exist()
        {
            // Arrange
            userInterfaceMock.Setup(x => x.PromptForInteger(It.IsAny<string>())).Returns(123);
            restClientMock.Setup(x => x.GetById(123)).Returns<object>(null);

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() => bs.DepositIntoAccount());
        }
        
        [Fact]
        public void WithdrawFromAccount_DecreasesAccountBalance_IfAccountExists()
        {
            // Arrange
            userInterfaceMock.SetupSequence(x => x.PromptForInteger(It.IsAny<string>())).Returns(123).Returns(1000);
            restClientMock.Setup(x => x.GetById(123)).Returns(acc).Verifiable();

            // Act
            bs.WithdrawFromAccount();

            // Assert
            acc.Balance.Should().Be(5000);
            restClientMock.VerifyAll();
            userInterfaceMock.Verify(m => m.PromptForInteger(It.IsAny<string>()), Times.Exactly(2));
        }

    }
}
