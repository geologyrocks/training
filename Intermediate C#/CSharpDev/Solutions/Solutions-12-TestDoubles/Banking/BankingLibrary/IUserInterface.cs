using System;

namespace BankingLibrary
{
    public interface IUserInterface
    {
        int PromptForInteger(string promptMessage);
        double PromptForDouble(string promptMessage);
        String PromptForString(string promptMessage);
    }
}
