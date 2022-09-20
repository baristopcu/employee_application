using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeService.Data.Entities;
using EmployeeService.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EmployeeService.API.Extensions;

namespace EmployeeService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IGenericRepository<Employee> _employeeRepository;
        public EmployeeController(IGenericRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return employees.ToList();
        }
    }
}
