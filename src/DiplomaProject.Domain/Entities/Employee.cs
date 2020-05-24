using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DiplomaProject.Domain.Entities
{
    public class Employee : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MidName { get; set; }
        public Sex Sex { get; set; }
        public DateTimeOffset BirthDay { get; set; }
        public DateTimeOffset EmploymentDate { get; set; }

        public virtual ICollection<EmployeeExpedition> Expeditions { get; set; }
    }
}