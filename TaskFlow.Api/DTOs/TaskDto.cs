using TaskFlow.Api.Enums;

public class TaskDto
{
    public string Title { get; set; } = string.Empty;
    public TaskItemStatus Status { get; set; } = TaskItemStatus.ToDo;
    public DateTime? DueDate { get; set; }
    public int ProjectId { get; set; }
}