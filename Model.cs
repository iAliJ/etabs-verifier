using System;
using ETABSv17;

namespace EtabsAPI
{
    public class Model
    {
        private static cSapModel instance; 
        public static cSapModel Instance 
        { 
            get 
            {
                return instance;

            }
            set
            {
                if(instance == null)
                    instance = value;
            } 
        }
        public string Directory { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }    

        public Model(string directory, string name)
            {
                this.Directory = directory;
                this.Name = name;
                this.Path = Directory + System.IO.Path.DirectorySeparatorChar + Name;
            }
    }
}