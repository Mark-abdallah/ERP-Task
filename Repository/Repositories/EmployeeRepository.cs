using BL.Interfaces;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext appDbContext;

        public EmployeeRepository(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Employee GetEmployee(int employeeId)
        {
            return appDbContext.Employees.FirstOrDefault(e => e.Id == employeeId);
        }

        public object GetEmployeesWithCompany()
        {
            return appDbContext.Employees.Include(c => c.Company).Select(t => new  { t.Name, t.Company.CompanyName }).ToList();
        }
        public Company WhereIs(string empName)
        {
           var companyid= appDbContext.Employees.FirstOrDefault(c => c.Name.ToLower() == empName.ToLower()).CompanyId;
            if (companyid != 0)
            {
                var company = appDbContext.Companies.FirstOrDefault(c => c.Id == companyid);
                return company;
            }
            else
            {
                return null;
            }
        }

       

        public Employee AddEmployee(Employee employee)
        {
            var result = appDbContext.Employees.Add(employee);
             appDbContext.SaveChanges();
            return result.Entity;
        }


        public Employee UpdateEmployee(Employee employee)
        {
            var result =  appDbContext.Employees
                .FirstOrDefault(e => e.Id == employee.Id);

            if (result != null)
            {
                result.Name = employee.Name;
                result.HireDate = employee.HireDate;
                result.Email = employee.Email;
                result.PhoneNumber = employee.PhoneNumber;
                appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public void DeleteEmployee(int employeeId)
        {
            var result =  appDbContext.Employees.FirstOrDefault(e => e.Id == employeeId);
            if (result != null)
            {
                appDbContext.Employees.Remove(result);
                appDbContext.SaveChangesAsync();
            }
        }

      
    }
}
