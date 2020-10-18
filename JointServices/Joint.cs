namespace EtabsAPI.JointServices
{
    public class Joint
    {
        public string Name {get; set;}
        public double Px {get; set;}
        public double Py {get; set;}
        public double Pz {get; set;}
        public int connections {set; get;}

        public Joint(string name, double x, double y, double z)
        {
            this.Name = name;
            this.Px = x;
            this.Py = y;
            this.Pz = z; 
            this.connections = 0;       
        }
    }
}