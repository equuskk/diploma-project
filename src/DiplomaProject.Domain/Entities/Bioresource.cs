namespace DiplomaProject.Domain.Entities
{
    public class Bioresource
    {
        public int Id { get; set; }
        public string Type { get; set; } // TODO:
        public float Square { get; set; }
        public float Weight { get; set; }

        public int SectorId { get; set; }

        public virtual Sector Sector { get; set; }
    }
}