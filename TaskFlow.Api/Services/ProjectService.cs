using Microsoft.EntityFrameworkCore;
using TaskFlow.Api.Data;
using TaskFlow.Api.DTOs;
using TaskFlow.Api.Models;

public class ProjectService : IProjectService
{
    private readonly AppDbContext _context;

    public ProjectService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<object>> GetAllProjects()
    {
        return await _context.Projects
            .Include(p => p.Tasks)
            .Select(p => (object)new
            {
                p.Id,
                p.Name,
                p.Description,
                p.CreationDate,
                p.UserId
            })
            .ToListAsync();
    }

    public async Task<object> GetProjectById(int id)
    {
        var project = await _context.Projects
            .Include(p => p.Tasks)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (project == null)
            throw new KeyNotFoundException($"Projet {id} introuvable.");

        return project;
    }

    public async Task<object> CreateProject(ProjectDto dto, int userId)
    {
        var project = new Project
        {
            Name = dto.Name,
            Description = dto.Description,
            CreationDate = DateTime.UtcNow,
            UserId = userId
        };

        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
        return project;
    }

    public async Task<object> UpdateProject(int id, ProjectDto dto)
    {
        var project = await _context.Projects.FindAsync(id);

        if (project == null)
            throw new KeyNotFoundException($"Projet {id} introuvable.");

        project.Name = dto.Name;
        project.Description = dto.Description;
        await _context.SaveChangesAsync();
        return project;
    }

    public async Task<bool> DeleteProject(int id, int userId)
    {
        var project = await _context.Projects.FindAsync(id);

        if (project == null)
            throw new KeyNotFoundException($"Projet {id} introuvable.");

        if (project.UserId != userId)
            throw new UnauthorizedAccessException("Vous n'êtes pas le propriétaire.");

        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();
        return true;
    }
}