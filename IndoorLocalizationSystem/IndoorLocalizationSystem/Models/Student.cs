using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndoorLocalizationSystem.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; }

        public int DeviceId { get; set; } // Foreign key to the Device table

        [ForeignKey("DeviceId")]
        public Device? Device { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ClassroomId { get; set; } // Foreign key to the Classroom table

        public Classroom? Classroom { get; set; } // Navigation property to the Classroom table
        public bool Attended { get; set; }

        public List<Course> Courses { get; set; } = new();



    }
}
