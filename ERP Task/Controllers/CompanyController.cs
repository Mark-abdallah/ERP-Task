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
    public class CompanyController : Controller
    {
        #region property
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
      
        #endregion

        #region Constructor
        public CompanyController(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        #endregion

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _companyRepository.GetCompanies();
            if (result is not null)
            {
                //var data = _mapper.Map<IEnumerable<Company>, IEnumerable<CompanyDTO>>(result);
                return Ok(result);
            }
            return BadRequest("No records found");
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _companyRepository.GetCompany(id);
            if (result is not null)
            {
                var data = _mapper.Map<Company, CompanyDTO>(result);
                return Ok(data);
            }
            return BadRequest("No records found");
        }
        [HttpGet("EmployeeIn/{companyName}")]
        public IActionResult GetEmployees(string companyName)
        {
            var result = _companyRepository.GetEmployeesIn(companyName);
            if (result is not null)
            {
                var data = _mapper.Map < IEnumerable<Employee>, IEnumerable<EmployeeDTO>>(result);
                return Ok(data);
            }
            return BadRequest("No records found");
        }

        [HttpPost]
        public IActionResult InsertCompany(Company company)
        {
            _companyRepository.InsertCompany(company);
            return Ok("Data inserted");

        }
        [HttpPut]
        public IActionResult UpdateCompany(Company company)
        {
            _companyRepository.UpdateCompany(company);
            return Ok("Updation done");

        }
        [HttpDelete]
        public IActionResult DeleteCompany(int Id)
        {
            _companyRepository.DeleteCompany(Id);
            return Ok("Data Deleted");
        }

        //[HttpGet]
        //[Route("/EmployeesIn/{id}")]
        //  public IActionResult GetEmployeesIn(int id)
        //{
        //    var result = _employeeService.GetAllEmployees().Where(c => c.CompanyId == id).ToList().Count();
            
        //    if (result >0)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest("No records found");

        //}

    }
}
