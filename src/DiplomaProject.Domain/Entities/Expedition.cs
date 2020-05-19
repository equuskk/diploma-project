using System;
using System.Collections.Generic;

namespace DiplomaProject.Domain.Entities
{
    public class Expedition
    {
        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public virtual ICollection<EmployeeExpedition> Employees { get; set; }
        public virtual ICollection<ExpeditionSector> Sectors { get; set; }
    }
}