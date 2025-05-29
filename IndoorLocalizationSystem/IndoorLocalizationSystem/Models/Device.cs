using System.ComponentModel.DataAnnotations;

namespace IndoorLocalizationSystem.Models
{
    public class Device
    {
        [Key] // Indicates that this property is the primary key of the entity
        public int Id { get; set; }
        public string Name { get; set; }
        public string MACAddress { get; set; } // Unique identifier for the device
        public float PositionX { get; set; } // X coordinate in the indoor map
        public float PositionY { get; set; } // Y coordinate in the indoor map

        public int StudentId { get; set; } // Foreign key to the Student table
        public Student Student { get; set; } // Navigation property to the Student entity
    }
}
