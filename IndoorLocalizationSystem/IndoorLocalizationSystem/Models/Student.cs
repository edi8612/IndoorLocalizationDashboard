using System.ComponentModel.DataAnnotations;

namespace IndoorLocalizationSystem.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }

        // MAC address of the device used by the student
        public string DeviceID { get; set; }
        public bool Attended { get; set; }



    }
}
