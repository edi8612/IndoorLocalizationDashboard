namespace IndoorLocalizationSystem.DTOs
{
    public class ProfessorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> CourseNames { get; set; } = new(); // List of courses taught
    }
}
