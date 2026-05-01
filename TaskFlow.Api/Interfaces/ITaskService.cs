public interface ITaskService
{
    Task<IEnumerable<object>> GetAllTasks();
    Task<object> GetTaskById(int id);
    Task<object> CreateTask(TaskDto taskDto, int projectId);
    Task<object> UpdateTask(int id, TaskDto taskDto);
    Task<bool> DeleteTask(int id);
}