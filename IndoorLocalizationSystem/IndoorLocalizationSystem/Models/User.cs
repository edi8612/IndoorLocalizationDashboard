using System.ComponentModel.DataAnnotations;

namespace IndoorLocalizationSystem.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // e.g., "Student", "Professor", "Admin"

        public Student? Student { get; set; } // Navigation property to the Student entity
        public Professor? Professor { get; set; } // Navigation property to the Professor entity

    }
}
