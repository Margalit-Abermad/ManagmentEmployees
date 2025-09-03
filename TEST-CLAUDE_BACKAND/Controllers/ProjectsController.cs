using AutoMapper;
using Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Service;

namespace TEST_CLAUDE_BACKAND.Controllers
{
    public class ProjectsController : BaseController
    {
        private readonly IProjectService projectService;
        private readonly IMapper mapper;

        public ProjectsController(IProjectService projectService, IMapper mapper)
        {
            this.projectService = projectService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetAllProjects()
        {
            var projects = await projectService.GetAllAsync();
            var projectDtos = mapper.Map<IEnumerable<ProjectDto>>(projects);
            return Ok(projectDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDto>> GetProject(int id)
        {
            var project = await projectService.GetByIdAsync(id);
            if (project == null)
                return NotFound();

            var projectDto = mapper.Map<ProjectDto>(project);
            return Ok(projectDto);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDto>> CreateProject(ProjectDto projectDto)
        {
            var project = mapper.Map<Project>(projectDto);
            var createdProject = await projectService.CreateAsync(project);
            var resultDto = mapper.Map<ProjectDto>(createdProject);
            
            return CreatedAtAction(nameof(GetProject), new { id = resultDto.Projectid }, resultDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProjectDto>> UpdateProject(int id, ProjectDto projectDto)
        {
            if (id != projectDto.Projectid)
                return BadRequest();

            if (!await projectService.ExistsAsync(id))
                return NotFound();

            var project = mapper.Map<Project>(projectDto);
            var updatedProject = await projectService.UpdateAsync(project);
            var resultDto = mapper.Map<ProjectDto>(updatedProject);

            return Ok(resultDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProject(int id)
        {
            if (!await projectService.ExistsAsync(id))
                return NotFound();

            await projectService.DeleteAsync(id);
            return NoContent();
        }
    }
}