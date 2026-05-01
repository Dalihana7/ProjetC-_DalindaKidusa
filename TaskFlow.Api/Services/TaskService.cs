public class TaskService : ITaskService
{
    public async Task<IEnumerable<object>> GetAllTasks()
    {
        return new List<object>();
    }

    public async Task<object> GetTaskById(int id)
    {
        return null;
    }

    public async Task<object> CreateTask(TaskDto taskDto, int projectId)
    {
        return new { message = "Task created" };
    }

    public async Task<object> UpdateTask(int id, TaskDto taskDto)
    {
        return null;
    }

    public async Task<bool> DeleteTask(int id)
    {
        return true;
    }
}