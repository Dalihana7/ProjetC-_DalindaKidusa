public interface IProjectService
{
    Task<IEnumerable<object>> GetAllProjects();
    Task<object> GetProjectById(int id);
    Task<object> CreateProject(ProjectDto projectDto, int userId);
    Task<object> UpdateProject(int id, ProjectDto projectDto);
    Task<bool> DeleteProject(int id, int userId);
}