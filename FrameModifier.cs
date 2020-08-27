using System;
using ETABSv17;

namespace EtabsAPI
{
    public enum Modifier{ Area, Shear2, Shear3, Torsion, Inertia2, Inertia3, Mass, Weight }
    public class FrameModifier
    {
        public double Area { get; set; }
        public double Shear2 { get; set; }
        public double Shear3 { get; set; }
        public double Torsion { get; set; }
        public double Inertia2 { get; set; }
        public double Inertia3 { get; set; }
        public double Mass { get; set; }
        public double Weight { get; set; }
        // Default constructor
        public FrameModifier()
        {
            this.Area = 1;
            this.Shear2 = 1;
            this.Shear3 = 1;
            this.Torsion = 1;
            this.Inertia2 = 1;
            this.Inertia3 = 1;
            this.Mass = 1;
            this.Weight = 1;
        }   

        public FrameModifier(double[] modifiers)
        {
            this.Area = modifiers[0];
            this.Shear2 = modifiers[1];
            this.Shear3 = modifiers[2];
            this.Torsion = modifiers[3];
            this.Inertia2 = modifiers[4];
            this.Inertia3 = modifiers[5];
            this.Mass = modifiers[6];
            this.Weight = modifiers[7];
        }

        // Convert modifier to array
        public double[] ToArray()
        {
            return new double[]
            {
                this.Area,
                this.Shear2,
                this.Shear3,
                this.Torsion,
                this.Inertia2,
                this.Inertia3,
                this.Mass,
                this.Weight
            };
        }
    }

}
    