using Microsoft.EntityFrameworkCore;
using TaskFlow.Api.Data;
using TaskFlow.Api.DTOs;
using TaskFlow.Api.Models;

public class TaskService : ITaskService
{
    private readonly AppDbContext _context;

    public TaskService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<object>> GetAllTasks()
    {
        return await _context.Tasks
            .Include(t => t.Project)
            .Select(t => (object)new
            {
                t.Id,
                t.Title,
                t.Status,
                t.DueDate,
                t.ProjectId
            })
            .ToListAsync();
    }

    public async Task<object> GetTaskById(int id)
    {
        var task = await _context.Tasks
            .Include(t => t.Project)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (task == null)
            throw new KeyNotFoundException($"Tâche {id} introuvable.");

        return task;
    }

    public async Task<object> CreateTask(TaskDto dto, int projectId)
    {
        var projectExists = await _context.Projects.AnyAsync(p => p.Id == dto.ProjectId);

        if (!projectExists)
            throw new KeyNotFoundException($"Projet {dto.ProjectId} introuvable.");

        var task = new TaskItem
        {
            Title = dto.Title,
            Status = dto.Status,
            DueDate = dto.DueDate,
            ProjectId = dto.ProjectId
        };

        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<object> UpdateTask(int id, TaskDto dto)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task == null)
            throw new KeyNotFoundException($"Tâche {id} introuvable.");

        task.Title = dto.Title;
        task.Status = dto.Status;
        task.DueDate = dto.DueDate;
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<bool> DeleteTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task == null)
            throw new KeyNotFoundException($"Tâche {id} introuvable.");

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return true;
    }
}