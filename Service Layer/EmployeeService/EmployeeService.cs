using DAL.Models;
using Repository_Layer.Repository_Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        #region Property  
        private IRepository<Employee> _repository;
        #endregion

        #region Constructor  
        public EmployeeService(IRepository<Employee> repository)
        {
            _repository = repository;

        }
        #endregion
        public void DeleteEmployee(int id)
        {
            Employee employee = GetEmployee(id);
            _repository.Delete(employee);
            _repository.SaveChanges();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _repository.GetAll();
        }

        public Employee GetEmployee(int id)
        {
            return _repository.Get(id);
        }

        public void InsertEmployee(Employee employee)
        {
            _repository.Insert(employee);
            
        }

        public void UpdateEmployee(Employee employee)
        {
            _repository.Update(employee);
        }
    }
}
