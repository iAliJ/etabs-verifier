using System;

namespace EtabsAPI
{
    public class UserInput
    {
        public FrameModifier ColumnModifier { get; private set;}
        public FrameModifier BeamModifier { get; private set; }

        public UserInput()
        {
            this.ColumnModifier = new FrameModifier();
            this.BeamModifier = new FrameModifier();
        }
        public void UpdateColumnSectionModifier(Modifier modifier, double ModifierValue)
        {
            switch(modifier)
            {
                case Modifier.Area:
                    ColumnModifier.Area = ModifierValue;
                    break;
                case Modifier.Shear2:
                    ColumnModifier.Shear2 = ModifierValue;
                    break;
                case Modifier.Shear3:
                    ColumnModifier.Shear3 = ModifierValue;
                    break;
                case Modifier.Torsion:
                    ColumnModifier.Torsion = ModifierValue;
                    break;
                case Modifier.Inertia2:
                    ColumnModifier.Inertia2 = ModifierValue;
                    break;
                case Modifier.Inertia3:
                    ColumnModifier.Inertia3 = ModifierValue;
                    break;
                case Modifier.Mass:
                    ColumnModifier.Mass = ModifierValue;
                    break;
                case Modifier.Weight:
                    ColumnModifier.Weight = ModifierValue;
                    break;
                default:
                    throw new Exception("Unknown stiffness modifier parameter");
            }
        }

        public void UpdateBeamSectionModifier(Modifier modifier, double ModifierValue)
        {
            switch(modifier)
            {
                case Modifier.Area:
                    BeamModifier.Area = ModifierValue;
                    break;
                case Modifier.Shear2:
                    BeamModifier.Shear2 = ModifierValue;
                    break;
                case Modifier.Shear3:
                    BeamModifier.Shear3 = ModifierValue;
                    break;
                case Modifier.Torsion:
                    BeamModifier.Torsion = ModifierValue;
                    break;
                case Modifier.Inertia2:
                    BeamModifier.Inertia2 = ModifierValue;
                    break;
                case Modifier.Inertia3:
                    BeamModifier.Inertia3 = ModifierValue;
                    break;
                case Modifier.Mass:
                    BeamModifier.Mass = ModifierValue;
                    break;
                case Modifier.Weight:
                    BeamModifier.Weight = ModifierValue;
                    break;
                default:
                    throw new Exception("Unknown stiffness modifier parameter");
            }
        }
    }
}