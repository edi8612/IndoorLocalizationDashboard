using System.ComponentModel.DataAnnotations;

namespace IndoorLocalizationSystem.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Device? Device { get; set; }

        public int UsertId { get; set; }
        public User User { get; set; }

        public int ClassroomId { get; set; } // Foreign key to the Classroom table
        public Classroom? Classroom { get; set; } // Navigation property to the Classroom table
        public bool Attended { get; set; }

        public List<Course> Courses { get; set; } = new();



    }
}
