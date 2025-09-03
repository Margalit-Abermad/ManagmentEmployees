using AutoMapper;
using Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Service;

namespace TEST_CLAUDE_BACKAND.Controllers
{
    public class EmployeesController : BaseController
    {
        private readonly IEmployeeService employeeService;
        private readonly IMapper mapper;

        public EmployeesController(IEmployeeService employeeService, IMapper mapper)
        {
            this.employeeService = employeeService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAllEmployees()
        {
            var employees = await employeeService.GetAllAsync();
            var employeeDtos = mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return Ok(employeeDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(int id)
        {
            var employee = await employeeService.GetByIdAsync(id);
            if (employee == null)
                return NotFound();

            var employeeDto = mapper.Map<EmployeeDto>(employee);
            return Ok(employeeDto);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> CreateEmployee(EmployeeDto employeeDto)
        {
            var employee = mapper.Map<Employee>(employeeDto);
            var createdEmployee = await employeeService.CreateAsync(employee);
            var resultDto = mapper.Map<EmployeeDto>(createdEmployee);
            
            return CreatedAtAction(nameof(GetEmployee), new { id = resultDto.Employeeid }, resultDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeDto>> UpdateEmployee(int id, EmployeeDto employeeDto)
        {
            if (id != employeeDto.Employeeid)
                return BadRequest();

            if (!await employeeService.ExistsAsync(id))
                return NotFound();

            var employee = mapper.Map<Employee>(employeeDto);
            var updatedEmployee = await employeeService.UpdateAsync(employee);
            var resultDto = mapper.Map<EmployeeDto>(updatedEmployee);

            return Ok(resultDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            if (!await employeeService.ExistsAsync(id))
                return NotFound();

            await employeeService.DeleteAsync(id);
            return NoContent();
        }
    }
}