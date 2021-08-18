using AutoMapper;
using BL.Interfaces;
using DAL.Models;
using ERP_Task.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ERP_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        #region property

        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
           
        }
        #endregion

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _employeeRepository.GetEmployeesWithCompany();
              
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _employeeRepository.GetEmployee(id);
            if (result is not null)
            {
                var data = _mapper.Map<Employee, EmployeeDTO>(result);
                return Ok(data);
            }
            return BadRequest("No records found");
        }
        [HttpGet("whereIs/{empName}")]
        public IActionResult WhereIs(string empName)
        {
            var result = _employeeRepository.WhereIs(empName);
            if (result is not null)
            {
                var data = _mapper.Map<Company, CompanyDTO>(result);
                return Ok(data);
            }
            return BadRequest("No records found");
        }

        [HttpPost]
        public IActionResult InsertEmployee(Employee employee)
        {
            _employeeRepository.AddEmployee(employee);
            return Ok("Data inserted");

        }
        [HttpPut]
        public IActionResult UpdateEmployee(Employee employee)
        {
            _employeeRepository.UpdateEmployee(employee);
            return Ok("Updation done");

        }
        [HttpDelete]
        public IActionResult DeleteEmployee(int Id)
        {
            _employeeRepository.DeleteEmployee(Id);
            return Ok("Data Deleted");
        }



    }
}
