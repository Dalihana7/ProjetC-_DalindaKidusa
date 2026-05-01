public class ProjectService : IProjectService
{
    public async Task<IEnumerable<object>> GetAllProjects()
    {
        return new List<object>();
    }

    public async Task<object> GetProjectById(int id)
    {
        return null;
    }

    public async Task<object> CreateProject(ProjectDto projectDto, int userId)
    {
        return new { message = "Project created" };
    }

    public async Task<object> UpdateProject(int id, ProjectDto projectDto)
    {
        return null;
    }

    public async Task<bool> DeleteProject(int id, int userId)
    {
        return true;
    }
}