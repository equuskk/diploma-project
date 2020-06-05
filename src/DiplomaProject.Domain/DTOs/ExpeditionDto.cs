using System;
using DiplomaProject.Domain.Entities;

namespace DiplomaProject.Domain.DTOs
{
    public class ExpeditionDto
    {
        public DateTimeOffset FromDate { get; set; }
        public DateTimeOffset ToDate { get; set; }

        public Sector[] Sectors { get; set; }
        public EmployeeDto[] Employees { get; set; }

        public Thicket[] Thickets { get; set; }
    }
}