using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace DiplomaProject.Domain.Entities
{
    public class Station
    {
        public int Id { get; private set; }
        public Point Location { get; set; }

        public int SectorId { get; set; }

        public virtual Sector Sector { get; set; }

        public virtual ICollection<StationData> StationData { get; set; }
    }
}