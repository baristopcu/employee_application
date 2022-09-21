using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeService.Data.Entities;
using EmployeeService.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EmployeeService.API.Extensions;
using System;
using AutoMapper;
using EmployeeService.Data.DTOs;
using EmployeeService.API.Models.ResponseModels;
using EmployeeService.API.Models.RequestModels;

namespace EmployeeService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper _autoMapper;
        private readonly IGenericRepository<Employee> _employeeRepository;
        public EmployeeController(IMapper autoMapper, IGenericRepository<Employee> employeeRepository)
        {
            _autoMapper = autoMapper;
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<GetEmployeeByIdResponseModel>> GetEmployeeById(int employeeId)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId);
            if (employee == null)
                return new GetEmployeeByIdResponseModel() { Success = false, Message = "Employee does not exist by given id." };

            var result = _autoMapper.Map<EmployeeDTO>(employee);
            return new GetEmployeeByIdResponseModel() { Success = true, Employee = result };
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            var result = _autoMapper.Map<IEnumerable<EmployeeDTO>>(employees);
            return result.ToList();
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeDTO>> GetEmployeesByName(string name)
        {
            var employees = await _employeeRepository.FindAsync(x=> x.Name.Contains(name));
            var result = _autoMapper.Map<IEnumerable<EmployeeDTO>>(employees);
            return result.ToList();
        }


        [HttpGet]
        public async Task<IEnumerable<EmployeeDTO>> GetEmployeesBySurname(string surname)
        {
            var employees = await _employeeRepository.FindAsync(x => x.Surname.Contains(surname));
            var result = _autoMapper.Map<IEnumerable<EmployeeDTO>>(employees);
            return result.ToList();
        }

        [HttpPut]
        [AuthorizeAdmin]
        public async Task<ActionResult<UpdateEmployeeResponseModel>> UpdateEmployee(UpdateEmployeeRequestModel updatedEmployee)
        {
            if (!ModelState.IsValid)
                return new BadRequestResult();

            var response = new UpdateEmployeeResponseModel();
            var employee = await _employeeRepository.GetByIdAsync(updatedEmployee.EmployeeId);
            if (employee == null)
            {
                response.Success = false;
                response.Message = "Employee does not exists";
                return response;
            }

            //mapping profile can be create
            if (updatedEmployee.Name != employee.Name && updatedEmployee.Name != null)
                employee.Name = updatedEmployee.Name;
            if (updatedEmployee.Surname != employee.Surname && updatedEmployee.Surname != null)
                employee.Surname = updatedEmployee.Surname;
            if (updatedEmployee.Gender != employee.Gender && updatedEmployee.Gender != default)
                employee.Gender = updatedEmployee.Gender;
            if (updatedEmployee.BirthDate != employee.BirthDate && updatedEmployee.BirthDate != default)
                employee.BirthDate = updatedEmployee.BirthDate;

            _employeeRepository.Update(employee);
            await _employeeRepository.SaveChangesAsync();
            response.Success = true;
            return response;
        }

        [HttpPost]
        [AuthorizeAdmin]
        public async Task<ActionResult<InsertEmployeeResponseModel>> InsertEmployee(InsertEmployeeRequestModel newEmployee)
        {
            if (!ModelState.IsValid)
                return new BadRequestResult();

            var response = new InsertEmployeeResponseModel();
            var employee = new Employee()
            {
                Name = newEmployee.Name,
                Surname = newEmployee.Surname,
                Gender = newEmployee.Gender.Value,
                BirthDate = newEmployee.BirthDate.Value,
                CreatedOnUtc = DateTime.UtcNow
            };

            await _employeeRepository.AddAsync(employee);
            await _employeeRepository.SaveChangesAsync();
            response.Success = true;
            return response;
        }


        [HttpDelete]
        [AuthorizeAdmin]
        public async Task<ActionResult<DeleteEmployeeResponseModel>> DeleteEmployeeById(int employeeId)
        {
            if (employeeId == default)
                return new BadRequestResult();

            var employee = await _employeeRepository.GetByIdAsync(employeeId);
            var response = new DeleteEmployeeResponseModel();
            if (employee == null)
            {
                response.Success = false;
                response.Message = "Employee does not exists.";
            }

             _employeeRepository.Remove(employee);
            await _employeeRepository.SaveChangesAsync();
            response.Success = true;
            return response;
        }
    }
}
