using System;
using AutoMapper;
using EmployeeService.Data.DTOs;
using EmployeeService.Data.Entities;

namespace EmployeeService.API.AutoMapperProfiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>();
        }
    }
}

