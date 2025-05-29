using System.ComponentModel.DataAnnotations;

namespace IndoorLocalizationSystem.Models
{
    public class Course
    {
        [Key]
        public string Id { get; set; } // Unique identifier for the course
        public string Name { get; set; }

        public int ClassroomId { get; set; } // Foreign key to the Classroom table
        public Classroom Classroom { get; set; } // Navigation property to the Classroom entity

        public int ProfessorId { get; set; } // Foreign key to the Professor table
        public Professor Professor { get; set; } // Navigation property to the Professor entity

        public List<Student> Students { get; set; } = new();




    }
}
