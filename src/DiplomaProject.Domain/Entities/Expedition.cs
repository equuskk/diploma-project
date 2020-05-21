using System;
using System.Collections.Generic;

namespace DiplomaProject.Domain.Entities
{
    public class Expedition
    {
        public int Id { get; private set; }
        public DateTimeOffset FromDate { get; set; }
        public DateTimeOffset ToDate { get; set; }

        public virtual ICollection<EmployeeExpedition> Employees { get; set; }
        public virtual ICollection<ExpeditionSector> Sectors { get; set; }
    }
}