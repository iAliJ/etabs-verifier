using System;

namespace EtabsAPI
{
    public interface IUserInput
    {
        void GetInput();
        void ValidateInput(string input);
    }
}