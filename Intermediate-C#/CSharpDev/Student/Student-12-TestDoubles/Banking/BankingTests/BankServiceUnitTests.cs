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

        public BankServiceUnitTests()
        {
            restClientMock = new Mock<IRestClient>();
            userInterfaceMock = new Mock<IUserInterface>();
        }

        [Fact]
        public void BankService_DepositIntoAccount_IncreasesAccountBalance()
        {
            // Arrange
            BankService bs = new BankService(restClientMock.Object, userInterfaceMock.Object);
            Account acc = new Account();
            acc.Id = 123;
            userInterfaceMock.SetupSequence(x => x.PromptForInteger(It.IsAny<string>())).Returns(123).Returns(50);
            restClientMock.Setup(x => x.GetById(123)).Returns(acc);
            //restClientMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(true);
            //restClientMock.Setup(x => x.Update(It.IsAny<int>(),It.IsAny<Account>())).Returns(true);

            // Act
            bs.DepositIntoAccount();

            // Assert
            acc.Balance.Should().Be(50);
            restClientMock.VerifyAll();
            userInterfaceMock.VerifyAll();
        }

    }
}
