using System;
using System.Collections.Generic;
using ETABSv17;
using EtabsAPI;

namespace EtabsAPI.JointServices
{
    public class JointHelper
    {
        private List<Joint> joints = new List<Joint>();
        private cSapModel model;

        public JointHelper()
        {
            this.model = Model.Instance;            
        }
        public void GetAllJoints()
        {
            int num = 0;
            string[] name = {};
            double[] px = {};
            double[] py = {};
            double[] pz = {};
            model.PointObj.GetAllPoints(ref num, ref name, ref px, ref py, ref pz);

            foreach(var joint in name)
            {
                int i = Array.IndexOf(name, joint);
                Joint j = new Joint(name[i], px[i], py[i], pz[i]);
                joints.Add(j);
            }

            
        }

        public int GetConnections(Joint joint)
        {
	        int NumberItems = 0;
	        int[] ObjectType = {};
	        string[] ObjectName = {};
	        int[] PointNumber = {};

            model.PointObj.GetConnectivity(joint.Name, ref NumberItems, ref ObjectType, ref ObjectName, ref PointNumber);
            return NumberItems;
             
        }

        public void CheckConnetivity()
        {
            string log = "";
            foreach(Joint joint in joints)
            {
                joint.connections = GetConnections(joint);
                if(joint.connections == 0)
                {
                    log += $"WARNING: Joint {joint.Name} is not connected to any element.\n";
                }
            }
            Console.WriteLine(log);
        }
    }
}