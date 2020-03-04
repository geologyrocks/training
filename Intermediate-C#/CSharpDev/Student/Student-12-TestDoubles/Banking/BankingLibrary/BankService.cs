using System;

namespace BankingLibrary
{
    public class BankService
    {
        private IRestClient restClient;
        private IUserInterface ui;

        public BankService(IRestClient restClient, IUserInterface ui)
        {
            this.restClient = restClient;
            this.ui = ui;
        }

        public void DepositIntoAccount()
        {
            int id = ui.PromptForInteger("Account id");

            Account acc = restClient.GetById(id);
            if (acc == null)
            {
                throw new ArgumentException("Invalid account id");
            }

            int amount = ui.PromptForInteger("Amount to deposit");
            acc.Deposit(amount);
            restClient.Update(id, acc);
        }

        public void WithdrawFromAccount()
        {
            int id = ui.PromptForInteger("Account id");

            Account acc = restClient.GetById(id);
            if (acc == null)
            {
                throw new ArgumentException("Invalid account id");
            }

            int amount = ui.PromptForInteger("Amount to withdraw");
            acc.Withdraw(amount);
            restClient.Update(id, acc);
        }

        public void TransferFunds()
        {
            int id1 = ui.PromptForInteger("Account id #1");
            int id2 = ui.PromptForInteger("Account id #2");

            Account acc1 = restClient.GetById(id1);
            Account acc2 = restClient.GetById(id2);
            if (acc1 == null || acc2 == null)
            {
                throw new ArgumentException("Invalid account id(s)");
            }

            int amount = ui.PromptForInteger("Amount to transfer");
            acc1.Withdraw(amount);
            acc2.Deposit(amount);
            restClient.Update(id1, acc1);
            restClient.Update(id2, acc2);
        }
    }
}
