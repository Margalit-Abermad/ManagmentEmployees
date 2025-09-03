using AutoMapper;
using Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Service;

namespace TEST_CLAUDE_BACKAND.Controllers
{
    public class DepartmentsController : BaseController
    {
        private readonly IDepartmentService departmentService;
        private readonly IMapper mapper;

        public DepartmentsController(IDepartmentService departmentService, IMapper mapper)
        {
            this.departmentService = departmentService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetAllDepartments()
        {
            var departments = await departmentService.GetAllAsync();
            var departmentDtos = mapper.Map<IEnumerable<DepartmentDto>>(departments);
            return Ok(departmentDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDto>> GetDepartment(int id)
        {
            var department = await departmentService.GetByIdAsync(id);
            if (department == null)
                return NotFound();

            var departmentDto = mapper.Map<DepartmentDto>(department);
            return Ok(departmentDto);
        }

        [HttpPost]
        public async Task<ActionResult<DepartmentDto>> CreateDepartment(DepartmentDto departmentDto)
        {
            var department = mapper.Map<Department>(departmentDto);
            var createdDepartment = await departmentService.CreateAsync(department);
            var resultDto = mapper.Map<DepartmentDto>(createdDepartment);
            
            return CreatedAtAction(nameof(GetDepartment), new { id = resultDto.Departmentid }, resultDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DepartmentDto>> UpdateDepartment(int id, DepartmentDto departmentDto)
        {
            if (id != departmentDto.Departmentid)
                return BadRequest();

            if (!await departmentService.ExistsAsync(id))
                return NotFound();

            var department = mapper.Map<Department>(departmentDto);
            var updatedDepartment = await departmentService.UpdateAsync(department);
            var resultDto = mapper.Map<DepartmentDto>(updatedDepartment);

            return Ok(resultDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            if (!await departmentService.ExistsAsync(id))
                return NotFound();

            await departmentService.DeleteAsync(id);
            return NoContent();
        }
    }
}