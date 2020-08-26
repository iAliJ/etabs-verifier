using System;
using System.Collections;
using System.Collections.Generic;
using ETABSv17;

namespace EtabsAPI
{
    class FrameHelper
    {
        public cSapModel model;
        // Return all frame of beam type

        // Constructor
        public FrameHelper()
        {
            this.model = Model.Instance;
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

                FrameSection fs = new FrameSection(names[i], shapes[i], t3[i], t2[i], tf[i], tw[i], t2b[i], tfb[i]);
                frameSections.Add(fs);                
            }
            return frameSections;
        }
    }
}