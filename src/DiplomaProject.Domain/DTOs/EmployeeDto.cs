using System;

namespace DiplomaProject.Domain.DTOs
{
    public class EmployeeDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MidName { get; set; }
        public Sex Sex { get; set; }
        public DateTimeOffset BirthDay { get; set; }
        public DateTimeOffset EmploymentDate { get; set; }
        public string Role { get; set; }

        public string Fio => $"{LastName} {FirstName} {MidName}";
    }
}