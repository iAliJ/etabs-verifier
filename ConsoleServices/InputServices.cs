using System;

namespace EtabsAPI.ConsoleServices
{    
    // resposiblity of this class is to process the user input
    public class InputServices
    {
        // Classify user input and call the related methods
        // This method should be called only after isValidInput() has been called.
        public static void CallCommand(string userInput)
        {
            CommandsList userCommand = (CommandsList) Enum.Parse(typeof(CommandsList), userInput, true);
            switch(userCommand)
            {
                case CommandsList.Beam:
                    Console.WriteLine("Calling beam commands ...");
                    ConsoleInput.ShowBeamCommands();                    
                    CallBeamCommand(ConsoleInput.GetBeamCommands());
                    break;
                case CommandsList.Column:
                    // perform action on columns
                    Console.WriteLine("Calling column commands ...");
                    ConsoleInput.ShowColumnCommands();
                    CallColumnCommand(ConsoleInput.GetColumnCommands());
                    break;
                case CommandsList.Exit:
                    // Exit the tool
                    break;
            }
        }

        public static void CallBeamCommand(string userInput)
        {
            BeamCommandsList userCommand = (BeamCommandsList) Enum.Parse(typeof(BeamCommandsList), userInput, true);
            switch(userCommand)
            {
                case BeamCommandsList.modifiers:
                // Call beam modifiers commands                
                ProcessBeamModifier(ConsoleInput.GetBeamModifier());
                break;

                case BeamCommandsList.sections:
                // Cal beam sections commands
                break;
            }
        }

        public static void CallColumnCommand(string userInput)
        {
            ColumnCommandsList userCommand = (ColumnCommandsList) Enum.Parse(typeof(ColumnCommandsList), userInput, true);
            switch(userCommand)
            {
                case ColumnCommandsList.modifiers:
                // Call column modifiers commands                
                ProcessBeamModifier(ConsoleInput.GetColumnModifier());
                break;

                case ColumnCommandsList.sections:
                // Cal column sections commands
                break;
            }
        }
        // This method will validate if user input is matching with commands list.
        public static bool isValidInput(string userInput)
        {
            bool isValid = false;
            // validate initial commends
            foreach(var command in Enum.GetNames(typeof(CommandsList)))
            {   
                if(command.ToUpper() == userInput.ToUpper())
                {
                    Console.WriteLine("Valid input");
                    isValid = true;
                    break;
                }
            }

            // validate beam commands
            foreach(var command in Enum.GetNames(typeof(BeamCommandsList)))
            {   
                if(command.ToUpper() == userInput.ToUpper())
                {
                    Console.WriteLine("Valid beam input");
                    isValid = true;
                    break;
                }
            }
            return isValid;
        }

        public static void ProcessBeamModifier(string userInput)
        {
            // Convert input to array then call InputParser method
            string[] Smodifiers = userInput.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
            double[] modifiers = Array.ConvertAll(Smodifiers, new Converter<string, double>(Double.Parse));
            InputParser.ChangeColumnModifier(modifiers);
        }

        public static void ProcessColumnModifier(string userInput)
        {
            // Convert input to array then call InputParser method
            string[] Smodifiers = userInput.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
            double[] modifiers = Array.ConvertAll(Smodifiers, new Converter<string, double>(Double.Parse));
            InputParser.ChangeBeamModifier(modifiers);
        }
    }
}