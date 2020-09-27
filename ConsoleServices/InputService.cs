using System;

namespace ConsoleServices
{    
    // Ask and store user commands and input.
    public class InputService
    {
        string userInput;
        public void GetInitialCommand()
        {
            string commands = "";
            commands += $"{CommandsList.Beam.ToString()}: Modify beam properties\n";
            commands += $"{CommandsList.Column.ToString()}: Modify column properties\n";
            commands += $"{CommandsList.Exit.ToString()}: Exit the tool\n";
            
            Console.WriteLine(commands);
            userInput = Console.ReadLine();
        }

        private void GetBeamCommand()
        {

        }

        private void GetColumnCommand()
        {

        }

        // Classify user input and call the related methods
        public void ClassifyInput()
        {
            // First validate the input
            if(isValidInput())
            {
                // proceed
                Console.WriteLine("Input is valid");
            }
            else
            {
                // ask for input again
                GetInitialCommand();
            }
        }

        public bool isValidInput()
        {
            bool isValid = false;
            foreach(var command in Enum.GetNames(typeof(CommandsList)))
            {   
                if(command.ToUpper() == userInput.ToUpper())
                    isValid = true;
            }
            return isValid;
        }
    }
}