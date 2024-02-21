using lab1.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.Services
{
    public class SQLiteService : IDbService
    {
        private SQLiteConnection? database;


        public SQLiteService(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.DropTable<Employees>();
            database.DropTable<JobResponsibilities>();
            database.CreateTable<Employees>();
            database.CreateTable<JobResponsibilities>();
            Init();
        }
        public IEnumerable<JobResponsibilities> GetAllResponsibilities()
        {
            return database.Table<JobResponsibilities>().ToList();
        }

        public IEnumerable<Employees> GetEmployeesOfJob(int id)
        {
            return database.Table<Employees>().Where(j => j.JobId == id).ToList();
        }

        public void Init()
        {
            if (database != null)
            {
                database.Insert(new JobResponsibilities()
                {
                    Name = "DB Developer",
                    Responsibilities = "Database Design"
                });
                database.Insert(new JobResponsibilities()
                {
                    Name = "FrontEnd Developer",
                    Responsibilities = "Interface Design"
                });
                database.Insert(new JobResponsibilities()
                {
                    Name = "BackEnd Developer",
                    Responsibilities = "Logic of Program"
                });


                database.Insert(new Employees()
                {
                    JobId = 1,
                    Name = "Robert Polson",
                    Country = "USA"
                });
                database.Insert(new Employees()
                {
                    JobId = 2,
                    Name = "John Smith",
                    Country = "Great Britain"
                });
                database.Insert(new Employees()
                {
                    JobId = 3,
                    Name = "Anton Bogdanov",
                    Country = "Belarus"
                });
                database.Insert(new Employees()
                {
                    JobId = 1,
                    Name = "Joe Alex",
                    Country = "USA"
                });
                database.Insert(new Employees()
                {
                    JobId = 2,
                    Name = "Dmitry Aleksandrov",
                    Country = "Russia"
                });
                database.Insert(new Employees()
                {
                    JobId = 3,
                    Name = "Adam Adamson",
                    Country = "Canada"
                });
                database.Insert(new Employees()
                {
                    JobId = 1,
                    Name = "Ann Davies",
                    Country = "Poland"
                });
                database.Insert(new Employees()
                {
                    JobId = 2,
                    Name = "Tomas Wilson",
                    Country = "Canada"
                });
                database.Insert(new Employees()
                {
                    JobId = 3,
                    Name = "Svetlana Kolich",
                    Country = "Belarus"
                });
                database.Insert(new Employees()
                {
                    JobId = 1,
                    Name = "Edgar Taylor",
                    Country = "USA"
                });
                database.Insert(new Employees()
                {
                    JobId = 2,
                    Name = "Tom Parson",
                    Country = "Great Britain"
                });
                database.Insert(new Employees()
                {
                    JobId = 3,
                    Name = "Steve Lewis",
                    Country = "USA"
                });
                database.Insert(new Employees()
                {
                    JobId = 1,
                    Name = "Stepan Leonovich",
                    Country = "Russia"
                });
                database.Insert(new Employees()
                {
                    JobId = 2,
                    Name = "Raymond King",
                    Country = "Great Britain"
                });
                database.Insert(new Employees()
                {
                    JobId = 3,
                    Name = "Martin Gilbert",
                    Country = "Bulgaria"
                });
            }
        }
    }
}
