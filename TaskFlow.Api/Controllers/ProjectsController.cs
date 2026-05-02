using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/projects")]
[Authorize]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _service;

    public ProjectsController(IProjectService service)
    {
        _service = service;
    }

    // GET all
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var projects = await _service.GetAllProjects();
        return Ok(projects);
    }

    // GET by id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var project = await _service.GetProjectById(id);

        if (project == null)
            return NotFound();

        return Ok(project);
    }

    // POST
    [HttpPost]
    public async Task<IActionResult> Create(ProjectDto dto)
    {
        var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)
                       ?? User.FindFirst("sub");

        if (userIdClaim == null)
            return Unauthorized();

        var userId = int.Parse(userIdClaim.Value);

        var project = await _service.CreateProject(dto, userId);
        return CreatedAtAction(nameof(GetById), new { id = ((dynamic)project).Id }, project);
    }

    // PUT
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ProjectDto dto)
    {
        var project = await _service.UpdateProject(id, dto);

        if (project == null)
            return NotFound();

        return Ok(project);
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var userId = int.Parse(User.FindFirst("id")?.Value ?? "0");

        var result = await _service.DeleteProject(id, userId);

        if (!result)
            return NotFound();

        return NoContent();
    }
}