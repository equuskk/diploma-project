using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace DiplomaProject.Domain.Entities
{
    public class Station
    {
        public int Id { get; private set; }
        public Point Location { get; set; }

        public int ThicketId { get; set; }

        public virtual Thicket Thicket { get; set; }

        public virtual ICollection<StationData> StationData { get; set; }
    }
}