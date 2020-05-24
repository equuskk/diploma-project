using System;

namespace DiplomaProject.Domain.Entities
{
    public class StationData
    {
        public int Id { get; private set; }
        public DateTimeOffset Date { get; set; }
        public float Temperature { get; set; }
        public float Density { get; set; }
        public float Depth { get; set; }

        public int StationId { get; set; }

        public virtual Station Station { get; set; }
    }
}