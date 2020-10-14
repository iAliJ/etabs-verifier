using ETABSv17;
using System;
using System.Collections.Generic;
using EtabsAPI;

namespace EtabsAPI.SlabServices
{
    // This class is helper to get and modify slab from the model
    public class SlabHelper
    {

        public cSapModel model;
        string[] allAreaObj = {};
        List<string> allSlabObj = new List<string>();
        private List<Slab> allSlabs = new List<Slab>();

        public SlabHelper()
        {
            this.model = Model.Instance;
        }
        // Get All slabs from the model
        public void GetAllSlabs()
        {
	        int NumberNames = 0;
            eAreaDesignOrientation[] DesignOrientation = {};
            int NumberBoundaryPts = 0;
            int[] PointDelimiter = {};
            string[] PointNames = {};
            double[] PointX = {};
            double[] PointY = {};
            double[] PointZ = {};
            model.AreaObj.GetAllAreas(ref NumberNames, ref allAreaObj, ref DesignOrientation, ref NumberBoundaryPts, ref PointDelimiter,
            ref PointNames, ref PointX, ref PointY, ref PointZ);

            // Filter the allAreaObj Array to save only slab areas
            foreach(var area in allAreaObj)
            {
                // get the index of area
                int index = Array.IndexOf(allAreaObj, area);
                if(DesignOrientation[index] == eAreaDesignOrientation.Floor)
                {
                    allSlabObj.Add(area);
                }
            }
        }

        public string CheckAllSlabsLoaded()
        {
            string logger = "";
            int NumberItems = 0;
	        string[] AreaName = {};
	        string[] LoadPat = {};
	        string[] CSys = {};
	        int[] Dir = {};
	        double[] Value = {};
            foreach(var name in allSlabObj)
            {
                model.AreaObj.GetLoadUniform(name, ref NumberItems, ref AreaName, ref LoadPat, ref CSys, ref Dir, ref Value);
                if(ElementInArray(name, AreaName) < 2)
                {
                    logger += ($"WARNING: Area {name} : Not all load patterns are assigned please check the model\n");
                }
            }     
            return logger;
            
        }

        private int ElementInArray(string element, string[] elements)
        {
            int result = 0;
            foreach(var e in elements)
            {
                if(e == element)
                {
                    result += 1;
                }
            }
            return result;            
        }
    }
}