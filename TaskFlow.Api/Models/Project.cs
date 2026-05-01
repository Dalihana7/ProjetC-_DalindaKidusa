using System.ComponentModel.DataAnnotations;

namespace TaskFlow.Api.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<TaskItem> Tasks { get; set; }
    }
}