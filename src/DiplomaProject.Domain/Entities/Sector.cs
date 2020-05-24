using System.Collections.Generic;

namespace DiplomaProject.Domain.Entities
{
    public class Sector
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ExpeditionSector> Expeditions { get; set; }
        public virtual ICollection<Thicket> Thickets { get; set; }
    }
}