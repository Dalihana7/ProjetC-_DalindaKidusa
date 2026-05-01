using System.ComponentModel.DataAnnotations;
using TaskFlow.Api.Enums;

namespace TaskFlow.Api.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public Role Role { get; set; } = Role.User;

        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}