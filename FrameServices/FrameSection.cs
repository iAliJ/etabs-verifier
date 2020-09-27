using System;
using ETABSv17;
using EtabsAPI;

namespace FrameServices
{
    public enum FrameType { beam, column }
    public class FrameSection
    {
        public string Name { get; set; }
        public eFramePropType Shape { get; set; }
        public string Material { get; set; }
        public double T3 { get; set; }
        public double T2 { get; set; }
        public double Tf { get; set; }
        public double Tw { get; set; }
        public double T2b { get; set; }
        public double Tfb { get; set; }
        public FrameType Type { get; set; }
        public FrameModifier Modifier { get; set; }

        // Contructor
        public FrameSection(string name, eFramePropType shape, double t3, double t2, double tf,
                            double tw, double t2b, double tfb, double[] modifiers)    
        {
            this.Name = name;
            this.Shape = shape;
            this.T3 = t3;
            this.T2 = t2;
            this.Tf = tf;
            this.Tw = tw;
            this.T2b = t2b;
            this.Tfb = tfb;
            this.Modifier = new FrameModifier(modifiers);
        }

        public FrameSection()
        {

        }
    }

    
}