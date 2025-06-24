namespace IndoorLocalizationSystem.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Attended { get; set; }

        public string? ClassroomName { get; set; }
        public string? DeviceMacAddress { get; set; }

        public float? PositionX { get; set; } // Add this
        public float? PositionY { get; set; } // And this
    }
}
