using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/tasks")]
[Authorize]
public class TasksController : ControllerBase
{
    private readonly ITaskService _service;

    public TasksController(ITaskService service)
    {
        _service = service;
    }

    // GET all
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tasks = await _service.GetAllTasks();
        return Ok(tasks);
    }

    // GET by id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var task = await _service.GetTaskById(id);

        if (task == null)
            return NotFound();

        return Ok(task);
    }

    // POST
    [HttpPost]
    public async Task<IActionResult> Create(TaskDto dto)
    {
        var task = await _service.CreateTask(dto, 1); // projectId temporaire

        return Ok(task);
    }

    // PUT
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TaskDto dto)
    {
        var task = await _service.UpdateTask(id, dto);

        if (task == null)
            return NotFound();

        return Ok(task);
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteTask(id);

        if (!result)
            return NotFound();

        return NoContent();
    }
}