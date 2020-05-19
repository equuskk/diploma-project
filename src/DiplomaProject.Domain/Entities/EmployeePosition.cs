﻿using System.Collections.Generic;

namespace DiplomaProject.Domain.Entities
{
    public class EmployeePosition
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}