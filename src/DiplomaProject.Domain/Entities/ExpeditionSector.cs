namespace DiplomaProject.Domain.Entities
{
    public class ExpeditionSector
    {
        public int ExpeditionId { get; set; }
        public virtual Expedition Expedition { get; set; }

        public int SectorId { get; set; }
        public virtual Sector Sector { get; set; }
    }
}