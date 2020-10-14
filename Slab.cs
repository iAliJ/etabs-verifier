using ETABSv17;

namespace EtabsAPI.SlabServices
{
    public class Slab
    {
        public string Name {get; set;}
        public SlabType Type {get; set;}
        public ShellType SType {get; set;}
        public string MatProp {get; set;}
        public double Thickness {get; set;}
        public int Color {get; set;}
        public string Notes {get; set;}
        public string GUID {get; set;}
        public Slab(string name, SlabType type, ShellType stype, string mat, double t, int color, string notes, string guid )
        {
            this.Name = name;
            this.Type = type;
            this.SType = stype;
            this.MatProp = mat;
            this.Thickness = t;
            this.Color = color;
            this.Notes = notes; 
            this.GUID = guid;
        }
    }

    public enum SlabType{
        Slab, Drop, Stiff_DO_NOT_USE, Ribbed, Waffle
    }

    public enum ShellType{
        ShellThin = 1,  
        ShellThick,
        Membrane, 
        PlateThin_DO_NOT_USE,
        PlateThick_DO_NOT_USE,
        Layered
      }
}
