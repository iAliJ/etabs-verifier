using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EtabsAPI;

namespace ConsoleServices
{
    
    public class ConsoleInput
    {
        string userInput;
        public void GetInput()
        {
            Console.WriteLine("Input a valid command from the list below");
            ShowCommands();
            userInput = Console.ReadLine();
            ValidateInput(userInput);
            // If input is valid, proceed to call the command
            CallCommand(userInput);
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

        private void CallCommand(string userInput)
        {
            // First determine what the command is
            CommandsList userCommand = (CommandsList) Enum.Parse(typeof(CommandsList), userInput, true);
            switch(userCommand)
            {
                case CommandsList.Beam:
                    // perform action on beams
                    break;
                case CommandsList.Column:
                    // perform action on columns
                    break;
                case CommandsList.Exit:
                    // Exit the tool
                    break;
            }
        }
    }
}