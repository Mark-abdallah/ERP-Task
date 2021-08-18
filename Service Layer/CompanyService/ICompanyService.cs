using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.CompanyService
{
  public  interface ICompanyService
    {

        IEnumerable<Company> GetAllCompanies();
        Company GetCompany(int id);
        void InsertCompany(Company company);
        void UpdateCompany(Company company);
        void DeleteCompany(int id);

    }
}
