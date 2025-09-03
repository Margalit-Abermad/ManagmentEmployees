using AutoMapper;
using Common.DTOs;
using Repository.Models;

namespace Common.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department!.Name))
                .ReverseMap()
                .ForMember(dest => dest.Department, opt => opt.Ignore())
                .ForMember(dest => dest.Employeeprojects, opt => opt.Ignore());

            CreateMap<Department, DepartmentDto>()
                .ForMember(dest => dest.EmployeeCount, opt => opt.MapFrom(src => src.Employees.Count))
                .ReverseMap()
                .ForMember(dest => dest.Employees, opt => opt.Ignore());

            CreateMap<Project, ProjectDto>()
                .ForMember(dest => dest.EmployeeCount, opt => opt.MapFrom(src => src.Employeeprojects.Count))
                .ReverseMap()
                .ForMember(dest => dest.Employeeprojects, opt => opt.Ignore());

            CreateMap<Employeeproject, EmployeeProjectDto>()
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => $"{src.Employee.Firstname} {src.Employee.Lastname}"))
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.Name))
                .ReverseMap()
                .ForMember(dest => dest.Employee, opt => opt.Ignore())
                .ForMember(dest => dest.Project, opt => opt.Ignore());
        }
    }
}