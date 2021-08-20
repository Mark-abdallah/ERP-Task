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
    public class CompanyRepository : ICompanyRepository
    {
        private readonly  ApplicationDbContext appDbContext;
        public CompanyRepository(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public void DeleteCompany(int id)
        {
           var company= appDbContext.Companies.FirstOrDefault(c => c.Id == id);
            appDbContext.Companies.Remove(company);
            appDbContext.SaveChanges();
        }

        public List<string> GetCompanies()
        {
            return appDbContext.Companies.Select(c => c.CompanyName).ToList();
        }

        public  Company GetCompany(int companyId)
        {
            return  appDbContext.Companies.FirstOrDefault(e => e.Id == companyId);
        }

        public IEnumerable<Employee> GetEmployeesIn(string companyName)
        {
          var companyId=  appDbContext.Companies.FirstOrDefault(c => c.CompanyName.ToLower() == companyName.ToLower());
            if (companyId != null)
            {
                var employees = appDbContext.Employees.Where(d => d.CompanyId == companyId.Id).ToList();
                return employees;
            }
            else
            {
                return null;
            }
           

            
        }

        public void InsertCompany(Company company)
        {
            appDbContext.Companies.Add(company);
            appDbContext.SaveChanges();
        }

        public void UpdateCompany(Company company)
        {
            appDbContext.Update(company);
            appDbContext.SaveChanges();
        }
    }
}
