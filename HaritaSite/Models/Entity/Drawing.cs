using NetTopologySuite.Geometries;

namespace HaritaSite.Models.Entity
{
    public class Drawing : Base
    {
        public string Type { get; set; }
        public string Coordinates { get; set; }
        public Geometry? Shape { get; set; }
    }
}
