using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Models
{
     public class Company :BaseEntity
    {
        public string CompanyName { get; set; }
        public string Specialization { get; set; }
        public int EmployeesNumber { get; set; }
        [JsonIgnore]
        public ICollection<Employee> Employees { get; set; }


    }
}
