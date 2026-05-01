using System.ComponentModel.DataAnnotations;
using System.Data;
using TaskFlow.Api.Enums;

namespace TaskFlow.Api.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public Role Role { get; set; } = Role.User;

        public ICollection<Project> Projects { get; set; }
    }
}
