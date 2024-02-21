using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.Entities
{
    [Table("Employees")]
    public class Employees
    {
        [PrimaryKey, AutoIncrement, Indexed]
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        [Indexed]
        public int JobId { get; set; }
    }
}
