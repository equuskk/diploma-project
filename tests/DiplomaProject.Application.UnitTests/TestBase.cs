using System;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain;
using DiplomaProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Application.UnitTests
{
    public class TestBase
    {
        public string UserId { get; set; }
        public readonly ApplicationDbContext ApplicationContext;

        public TestBase()
        {
            ApplicationContext = GetDbContext();
        }

        public ApplicationDbContext GetDbContext()
        {
            if(ApplicationContext != null)
            {
                return ApplicationContext;
            }

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(Guid.NewGuid().ToString())
                          .Options;

            var context = new ApplicationDbContext(options);

            context.Database.EnsureCreated();

            InitDbContext(context);

            return context;
        }

        private void InitDbContext(ApplicationDbContext context)
        {
            InitEmployees(context);
            InitLitorals(context);
            InitSectors(context);
            InitExpeditions(context);
            InitSeaweedTypes(context);
            InitSeaweedCategories(context);

            context.SaveChanges();
        }

        private void InitEmployees(ApplicationDbContext context)
        {
            var user = new Employee
            {
                FirstName = "Иван",
                LastName = "Иванов",
                MidName = "Иванович",
                BirthDay = new DateTime(1980, 01, 01),
                Email = "ivan@company.com",
                Sex = Sex.Male,
                EmploymentDate = new DateTime(2019, 01, 01)
            };
            context.Users.Add(user);
            context.SaveChanges();

            UserId = user.Id;
        }

        private void InitLitorals(ApplicationDbContext context)
        {
            context.Litorals.AddRange(new Litoral("Скальная литораль"), new Litoral("Каменистая литораль"),
                                      new Litoral("Песчаная литораль"), new Litoral("Илистая литораль"));
            context.SaveChanges();
        }

        private void InitSectors(ApplicationDbContext context)
        {
            context.Sectors.Add(new Sector
            {
                Title = "Title",
                Description = "Description"
            });
            context.SaveChanges();
        }

        private void InitExpeditions(ApplicationDbContext context)
        {
            var date = new DateTimeOffset(2019, 01, 01, 0, 0, 0, TimeSpan.Zero);
            context.Expeditions.Add(new Domain.Entities.Expedition
            {
                FromDate = date,
                ToDate = date.AddMonths(1)
            });
            context.SaveChanges();
        }

        private void InitSeaweedTypes(ApplicationDbContext context)
        {
            context.SeaweedTypes.AddRange(new SeaweedType("Тип1"),
                                          new SeaweedType("Тип2"));
            context.SaveChanges();
        }

        private void InitSeaweedCategories(ApplicationDbContext context)
        {
            context.SeaweedCategories.AddRange(new SeaweedCategory("I"),
                                               new SeaweedCategory("II"));
            context.SaveChanges();
        }
    }
}