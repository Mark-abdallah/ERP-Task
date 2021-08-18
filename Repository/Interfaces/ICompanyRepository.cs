using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
   public interface ICompanyRepository
    {
        List<string> GetCompanies();
        Company GetCompany(int CompanyId);

        void InsertCompany(Company company);
        void DeleteCompany(int id);
        void UpdateCompany(Company company);

        IEnumerable<Employee> GetEmployeesIn(string companyName);
    }
}
