using lab1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.Services
{
    public interface IDbService
    {
        IEnumerable<JobResponsibilities> GetAllResponsibilities();
        IEnumerable<Employees> GetEmployeesOfJob(int id);
        void Init();
    }
}
