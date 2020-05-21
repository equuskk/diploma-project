namespace DiplomaProject.Domain.Entities
{
    public class EmployeeExpedition
    {
        public string EmployeeId { get; private set; }
        public virtual Employee Employee { get; set; }

        public int ExpeditionId { get; set; }
        public virtual Expedition Expedition { get; set; }
    }
}