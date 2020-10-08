using System;
using System.Collections;
using System.Collections.Generic;
using ETABSv17;

namespace EtabsAPI.FrameServices
{
    class FrameHelper
    {
        public cSapModel model;
        public FrameModifier ColumnModifier { get; private set;}
        public FrameModifier BeamModifier { get; private set; }
        // Return all frame of beam type

        // Constructor
        public FrameHelper()
        {
            this.model = Model.Instance;
            this.ColumnModifier = new FrameModifier();
            this.BeamModifier = new FrameModifier();
        }
        // This method will get frames properties from a model and store them into list of frameSection objects
        public List<FrameSection> GetAllFrameProperties()
        {
            List<FrameSection> frameSections = new List<FrameSection>();  
            int numberOfFrames = 0;
            string[] names = {};
            eFramePropType[] shapes = {}; 
            string[] materials = {};
            double[] t3 = {};
            double[] t2 = {};
            double[] tf = {};
            double[] tw = {};
            double[] t2b = {};
            double[] tfb = {};
            model.PropFrame.GetAllFrameProperties(ref numberOfFrames, ref names, ref shapes, ref t3, ref t2, ref tf, ref tw, ref t2b, ref tfb);          
            
            // convert the arraye to list
            for(int i = 0; i < numberOfFrames; i++)
            {
                double[] modifiers = {};
                model.PropFrame.GetModifiers(names[i], ref modifiers);
                FrameSection fs = new FrameSection(names[i], shapes[i], t3[i], t2[i], tf[i], tw[i], t2b[i], tfb[i], modifiers);
                frameSections.Add(fs);                
            }
            return frameSections;
        }

        public List<FrameSection> GetAllBeamSections(List<FrameSection> allFrameProperties)
        {
            List<FrameSection> beamSections = new List<FrameSection>();
            foreach(FrameSection frameSection in allFrameProperties)
            {
                int frameType = 0; 
                model.PropFrame.GetTypeRebar(frameSection.Name, ref frameType);
                if(frameType == 2) // 0 = none 1 = column 2 = beam
                    beamSections.Add(frameSection);
            }            
            return beamSections;
        }

        public void UpdateFrameSectionModifier(FrameSection frameSection)
        {
            double[] modifiers = frameSection.Modifier.ToArray();
            model.PropFrame.SetModifiers(frameSection.Name, ref modifiers);
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