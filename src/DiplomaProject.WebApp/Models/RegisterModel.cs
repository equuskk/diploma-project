using System;
using DiplomaProject.Domain;

namespace DiplomaProject.WebApp.Models
{
    public class RegisterModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MidName { get; set; }
        public Sex Sex { get; set; }
        public DateTimeOffset BirthDay { get; set; }
        public DateTimeOffset EmploymentDate { get; set; }
    }
}