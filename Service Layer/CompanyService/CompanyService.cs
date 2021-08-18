using DAL.Models;
using Repository_Layer.Repository_Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.CompanyService
{
    public class CompanyService : ICompanyService
    {
        #region Property  
        private IRepository<Company> _repository;
        #endregion

        #region Constructor  
        public CompanyService(IRepository<Company> repository)
        {
            _repository = repository;

        }
        #endregion



        public void DeleteCompany(int id)
        {
            Company company = GetCompany(id);
            _repository.Delete(company);
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return _repository.GetAll();
        }

        public Company GetCompany(int id)
        {
            return _repository.Get(id);
        }

       

        public void InsertCompany(Company company)
        {
            _repository.Insert(company);
        }

        public void UpdateCompany(Company company)
        {
            _repository.Update(company);
        }
    }
}
