using AutoMapper;
using DAL.Models;
using ERP_Task.DTOs;

namespace ERP_Task.Configurations
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name));
            CreateMap<Company, CompanyDTO>()
                .ForMember(d => d.CompanyName, o => o.MapFrom(s => s.CompanyName));
        }
    }
}
