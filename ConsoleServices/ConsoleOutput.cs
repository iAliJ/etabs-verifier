using System;
using EtabsAPI;

namespace ConsoleServices
{
    public class ConsoleOutput
    {
        public void StartMessage()
        {
            string displayMessage = "Welcome to ETABS Verifier Tool";
            displayMessage += "\nRefer to the documention on how to use the commands";
            Console.WriteLine(displayMessage);
        }

        public void ErrorMessage()
        {

        }

        public void NoErrorMessage()
        {

        }
    }
}