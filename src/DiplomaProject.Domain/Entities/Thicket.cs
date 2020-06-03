using System;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace DiplomaProject.Domain.Entities
{
    public class Thicket
    {
        public int Id { get; set; }

        public Point Location { get; set; }
        public DateTimeOffset Date { get; set; }
        public float WeightPerMeter { get; set; } // кг * м^2
        public float Length { get; set; }
        public float Width { get; set; }
        public float Stock { get; set; } // итоговый параметр (кг) = Length * Width * WeightPerMeter (сумма в секторе?)

        public int LitoralId { get; set; }
        public int GroundTypeId { get; set; }
        public int SeaweedId { get; set; }

        [ForeignKey("SectorId")]
        public int SectorId { get; set; }

        public virtual Litoral Litoral { get; set; }
        public virtual GroundType GroundType { get; set; }
        public virtual Seaweed Seaweed { get; set; }
        public virtual Sector Sector { get; set; }
    }
}