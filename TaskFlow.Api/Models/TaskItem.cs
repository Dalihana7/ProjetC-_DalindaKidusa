using System.ComponentModel.DataAnnotations;
using TaskFlow.Api.Enums;

namespace TaskFlow.Api.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public TaskItemStatus Status { get; set; } = TaskItemStatus.ToDo;

        public int ProjectId { get; set; }

        public Project Project { get; set; } = null!;

        public DateTime? DueDate { get; set; }

        public List<string> Comments { get; set; } = new();
    }
}