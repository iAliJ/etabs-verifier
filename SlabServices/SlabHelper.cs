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
        string[] MyName = {};
        private List<Slab> allSlabs = new List<Slab>();

        public SlabHelper()
        {
            this.model = Model.Instance;
        }
        // Get All slabs from the model
        public void GetAllSlabs()
        {
            /*
            int num = 0;
            string[] names = {};
            model.PropArea.GetNameList(ref num, ref names);
            Console.WriteLine(num);
            foreach(var name in names)
                Console.WriteLine(name);
            */

	        int NumberNames = 0;
            eAreaDesignOrientation[] DesignOrientation = {};
            int NumberBoundaryPts = 0;
            int[] PointDelimiter = {};
            string[] PointNames = {};
            double[] PointX = {};
            double[] PointY = {};
            double[] PointZ = {};
            model.AreaObj.GetAllAreas(ref NumberNames, ref MyName, ref DesignOrientation, ref NumberBoundaryPts, ref PointDelimiter,
            ref PointNames, ref PointX, ref PointY, ref PointZ);
            foreach(var name in MyName)
                Console.WriteLine(name);
        }

        public void GetSlabLoad()
        {
            int NumberItems = 0;
	        string[] AreaName = {};
	        string[] LoadPat = {};
	        string[] CSys = {};
	        int[] Dir = {};
	        double[] Value = {};
            foreach(var name in MyName)
            {
            model.AreaObj.GetLoadUniform(name, ref NumberItems, ref AreaName, ref LoadPat, ref CSys, ref Dir, ref Value);

                foreach(var aName in AreaName)
                {
                    int index = Array.IndexOf(AreaName, aName);                
                    Console.WriteLine($"{AreaName[index]}, {LoadPat[index]}, {CSys[index]}, {Value[index]}");
                }
            }

            
            Console.WriteLine("GetSlabLoad() Executed");
        }

    }
}