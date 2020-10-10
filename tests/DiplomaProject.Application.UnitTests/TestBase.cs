using System;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain;
using DiplomaProject.Domain.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace DiplomaProject.Application.UnitTests
{
    public class TestBase
    {
        public string UserId => Employee.Id;
        public Employee Employee { get; set; }
        public readonly ApplicationDbContext ApplicationContext;

        public TestBase()
        {
            ApplicationContext = GetDbContext();
        }

        private ApplicationDbContext GetDbContext()
        {
            if(ApplicationContext != null)
            {
                return ApplicationContext;
            }

            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseSqlite(connection,
                                     x => x.UseNetTopologySuite())
                          .Options;

            var context = new ApplicationDbContext(options);

            context.Database.EnsureCreated();

            InitDbContext(context);

            return context;
        }

        private void InitDbContext(ApplicationDbContext context)
        {
            InitEmployees();
            InitLitorals();
            InitSectors();
            InitExpeditions();
            InitSeaweedTypes();
            InitSeaweedCategories();
            InitSeaweeds();
            InitGroundTypes();
            InitThickets();
            InitStations();
            InitStationsData();

            void InitEmployees()
            {
                Employee = new Employee
                {
                    FirstName = "Иван",
                    LastName = "Иванов",
                    MidName = "Иванович",
                    BirthDay = new DateTime(1980, 01, 01),
                    Email = "ivan@company.com",
                    Sex = Sex.Male,
                    EmploymentDate = new DateTime(2019, 01, 01)
                };
                context.Users.Add(Employee);
                context.SaveChanges();
            }

            void InitLitorals()
            {
                context.Litorals.AddRange(new Litoral("Скальная литораль"), new Litoral("Каменистая литораль"),
                                          new Litoral("Песчаная литораль"), new Litoral("Илистая литораль"));
                context.SaveChanges();
            }

            void InitSectors()
            {
                context.Sectors.AddRange(new Sector
                                         {
                                             Title = "Title #1",
                                             Description = "Description #1"
                                         },
                                         new Sector
                                         {
                                             Title = "Title #2",
                                             Description = "Description #2"
                                         });
                context.SaveChanges();
            }

            void InitExpeditions()
            {
                var date = new DateTimeOffset(2019, 01, 01, 0, 0, 0, TimeSpan.Zero);
                context.Expeditions.Add(new Domain.Entities.Expedition
                {
                    FromDate = date,
                    ToDate = date.AddMonths(1)
                });
                context.SaveChanges();
            }

            void InitSeaweedTypes()
            {
                context.SeaweedTypes.AddRange(new SeaweedType("Тип1"),
                                              new SeaweedType("Тип2"));
                context.SaveChanges();
            }

            void InitSeaweedCategories()
            {
                context.SeaweedCategories.AddRange(new SeaweedCategory("I"),
                                                   new SeaweedCategory("II"));
                context.SaveChanges();
            }

            void InitSeaweeds()
            {
                context.Seaweeds.AddRange(new Seaweed
                                          {
                                              SeaweedCategoryId = 1,
                                              SeaweedTypeId = 1,
                                              Title = "Seaweed #1"
                                          },
                                          new Seaweed
                                          {
                                              SeaweedCategoryId = 2,
                                              SeaweedTypeId = 2,
                                              Title = "Seaweed #2"
                                          });
                context.SaveChanges();
            }

            void InitGroundTypes()
            {
                context.GroundTypes.AddRange(new GroundType("Песок"),
                                             new GroundType("Ил"));
                context.SaveChanges();
            }

            void InitThickets()
            {
                context.Add(new Thicket
                {
                    Date = new DateTimeOffset(2019, 01, 01, 0, 0, 0, TimeSpan.Zero),
                    GroundTypeId = 1,
                    LitoralId = 1,
                    SeaweedId = 1,
                    SectorId = 1,
                    Length = 10,
                    Width = 10,
                    Location = new Point(1.1, 1.1),
                    WeightPerMeter = 1,
                    Stock = 10 * 10 * 1
                });
                context.SaveChanges();
            }

            void InitStations()
            {
                context.Stations.Add(new Station
                {
                    Location = new Point(1.1, 1.1),
                    SectorId = 1,
                    Title = "Title"
                });
                context.SaveChanges();
            }

            void InitStationsData()
            {
                context.StationsData.Add(new StationData
                {
                    Date = new DateTimeOffset(2019, 01, 01, 01, 01, 01, TimeSpan.Zero),
                    Density = 10,
                    Depth = 0.2f,
                    StationId = 1,
                    Temperature = -7.3f
                });
                context.SaveChanges();
            }
        }
    }
}