using System;
using EtabsAPI;

namespace ConsoleServices
{
    public interface IUserInput
    {
        void GetInput();
        void ValidateInput(string input);
    }
}