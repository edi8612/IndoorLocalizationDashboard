namespace IndoorLocalizationSystem.DTOs
{
    public class DeviceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MACAddress { get; set; }
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public string StudentName { get; set; } // Include associated student name
    }
}
