using System;
using EtabsAPI;

namespace ConsoleServices
{
    // Responsibility of this class is to convert user input to a valid command and call etabs model modifier classes
    static class InputParser
    {
        public static FrameHelper frameHelper;

        // Set user input to a beam modifier object
        public static void SetBeamModifier(string userValue, Modifier modifierType)
        {
            switch(modifierType)
            {
                case Modifier.Area:
                    userBeamModifier.Area = userValue;
                case Modifier.Shear2:
                    userBeamModifier.Shear2 = userValue;
                case Modifier.Shear3:
                    userBeamModifier.Shear3 = userValue;
                case Modifier.Torsion:
                    userBeamModifier.Torsion = userValue;
                case Modifier.Inertia2:
                    userBeamModifier.Inertia2 = userValue;
                case Modifier.Inertia3:
                    userBeamModifier.Inertia3 = userValue;
                case Modifier.Mass:
                    userBeamModifier.Mass = userValue;    
                case Modifier.Weight:
                    userBeamModifier.Weight = userValue;                      
            }
        }

        public static FrameModifier GetBeamModifier()
        {
            return userBeamModifier;
        }

        public static void SetColumnModifier(string userValue, Modifier modifierType)
        {
            switch(modifierType)
            {
                case Modifier.Area:
                    userColumnModifier.Area = userValue;
                case Modifier.Shear2:
                    userColumnModifier.Shear2 = userValue;
                case Modifier.Shear3:
                    userColumnModifier.Shear3 = userValue;
                case Modifier.Torsion:
                    userColumnModifier.Torsion = userValue;
                case Modifier.Inertia2:
                    userColumnModifier.Inertia2 = userValue;
                case Modifier.Inertia3:
                    userColumnModifier.Inertia3 = userValue;
                case Modifier.Mass:
                    userColumnModifier.Mass = userValue;    
                case Modifier.Weight:
                    userColumnModifier.Weight = userValue;                      
            }
        }

        public static FrameModifier GetColumnModifier()
        {
            return userColumnModifier;
        }

    }
}