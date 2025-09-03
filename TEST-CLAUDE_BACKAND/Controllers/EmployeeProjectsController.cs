using AutoMapper;
using Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Service;

namespace TEST_CLAUDE_BACKAND.Controllers
{
    public class EmployeeProjectsController : BaseController
    {
        private readonly IEmployeeProjectService employeeProjectService;
        private readonly IMapper mapper;

        public EmployeeProjectsController(IEmployeeProjectService employeeProjectService, IMapper mapper)
        {
            this.employeeProjectService = employeeProjectService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeProjectDto>>> GetAllEmployeeProjects()
        {
            var employeeProjects = await employeeProjectService.GetAllAsync();
            var employeeProjectDtos = mapper.Map<IEnumerable<EmployeeProjectDto>>(employeeProjects);
            return Ok(employeeProjectDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeProjectDto>> GetEmployeeProject(int id)
        {
            var employeeProject = await employeeProjectService.GetByIdAsync(id);
            if (employeeProject == null)
                return NotFound();

            var employeeProjectDto = mapper.Map<EmployeeProjectDto>(employeeProject);
            return Ok(employeeProjectDto);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeProjectDto>> CreateEmployeeProject(EmployeeProjectDto employeeProjectDto)
        {
            var employeeProject = mapper.Map<Employeeproject>(employeeProjectDto);
            var createdEmployeeProject = await employeeProjectService.CreateAsync(employeeProject);
            var resultDto = mapper.Map<EmployeeProjectDto>(createdEmployeeProject);
            
            return CreatedAtAction(nameof(GetEmployeeProject), new { id = resultDto.Employeeid }, resultDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeProjectDto>> UpdateEmployeeProject(int id, EmployeeProjectDto employeeProjectDto)
        {
            if (id != employeeProjectDto.Employeeid)
                return BadRequest();

            if (!await employeeProjectService.ExistsAsync(id))
                return NotFound();

            var employeeProject = mapper.Map<Employeeproject>(employeeProjectDto);
            var updatedEmployeeProject = await employeeProjectService.UpdateAsync(employeeProject);
            var resultDto = mapper.Map<EmployeeProjectDto>(updatedEmployeeProject);

            return Ok(resultDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployeeProject(int id)
        {
            if (!await employeeProjectService.ExistsAsync(id))
                return NotFound();

            await employeeProjectService.DeleteAsync(id);
            return NoContent();
        }
    }
}