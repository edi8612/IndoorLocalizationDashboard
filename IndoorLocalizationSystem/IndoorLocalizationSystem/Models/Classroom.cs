using System.ComponentModel.DataAnnotations;

namespace IndoorLocalizationSystem.Models
{
    public class Classroom
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public List<Student> Students { get; set; } = new();
        public List<Course> Courses { get; set; } = new(); // Navigation property to the Course entity
    }
}
