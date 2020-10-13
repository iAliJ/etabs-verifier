using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EtabsAPI.ConsoleServices
{
    // Responsibility of this class is to get and promt for input from the user.
    public class ConsoleInput
    {
        private static string userInput;
        public static void GetInput()
        {
            Console.WriteLine("Input a valid command from the list below");
            ShowCommands();
            userInput = Console.ReadLine();
            if(!InputServices.isValidInput(userInput))
            {
                ConsoleInput.GetInput();
            };
            InputServices.CallCommand(userInput);
        }

        // Show available commands to the user
        private static void ShowCommands()
        {
            string commands = "";
            commands += $"{CommandsList.Beam.ToString()}: Modify beam properties\n";
            commands += $"{CommandsList.Column.ToString()}: Modify column properties\n";
            commands += $"{CommandsList.Exit.ToString()}: Exit the tool\n";
            
            Console.WriteLine(commands);
        }

        public static void ShowBeamCommands()
        {
            string commands = $"{BeamCommandsList.modifiers.ToString()}: Modify beam properties modifiers\n";
            // For now this tool will only set beam modifiers
            //string commands = $"{BeamCommandsList.sections.ToString()}: Modify beam section properties\n";
            Console.WriteLine(commands);
        }

        public static string GetBeamCommands()
        {
            // Get beam valid command from the user then call the input services to process it
            Console.WriteLine("Input a valid command from the list above");
            userInput = Console.ReadLine();
            if(!InputServices.isValidInput(userInput))
            {
                ConsoleInput.GetBeamCommands();
            }
            return userInput;
        }

        public static string GetBeamModifier()
        {
            string message = "input beam modifier values array in the following order:\n";
            message += "A, V1, V2, T, I2, I3, Mass, Weight";
            Console.WriteLine(message);            
            string userInput = Console.ReadLine();            
            return userInput;
        }

        public static void ShowColumnCommands()
        {
            string commands = $"{ColumnCommandsList.modifiers.ToString()}: Modify All columns property modifiers\n";
            Console.WriteLine(commands);
        }

        public static string GetColumnCommands()
        {
            Console.WriteLine("Input a valid command from the list above");
            userInput = Console.ReadLine();
            if(!InputServices.isValidInput(userInput))
            {
                ConsoleInput.GetColumnCommands();
            }
            return userInput;
        }

        public static string GetColumnModifier()
        {
            string message = "input column modifier values array in the following order:\n";
            message += "A, V1, V2, T, I2, I3, Mass, Weight";
            Console.WriteLine(message);            
            string userInput = Console.ReadLine();            
            return userInput;
        }
    }
}