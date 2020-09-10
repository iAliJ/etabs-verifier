using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EtabsAPI
{
    enum CommandsList
    {
        Beam, Column, Exit
    }
    public class ConsoleInput : IUserInput
    {
        string userInput;
        public void GetInput()
        {
            Console.WriteLine("Input a valid command from the list below");
            ShowCommands();
            userInput = Console.ReadLine();
            ValidateInput(userInput);
        }

        public void ValidateInput(string input)
        {
            bool isValid = false;
            foreach(var command in Enum.GetNames(typeof(CommandsList)))
            {   
                if(command.ToUpper() == input.ToUpper())
                {
                    isValid = true;        
                }
            }
            if(!isValid)
            {
                Console.WriteLine("Invalid input");
                GetInput();
            }
        }

        private void ShowCommands()
        {
            string commands = "";
            commands += $"{CommandsList.Beam.ToString()}: Modify beam properties\n";
            commands += $"{CommandsList.Column.ToString()}: Modify column properties\n";
            commands += $"{CommandsList.Exit.ToString()}: Exit the tool\n";
            
            Console.WriteLine(commands);
        }
    }
}