using IndoorLocalizationSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace IndoorLocalizationSystem.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Professor>()
                .HasOne(p => p.User)
                .WithOne(u => u.Professor)
                .HasForeignKey<Professor>(p => p.UserId);

            modelBuilder.Entity<Classroom>().HasData(
                new Classroom { Id = 1, Name = "Lab A" },
                new Classroom { Id = 2, Name = "Room 101" }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = "1", Name = "Computer Networks", ClassroomId = 1,ProfessorId = 1 },
                new Course { Id = "2", Name = "IoT Security", ClassroomId = 2, ProfessorId = 1 }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Alice Johnson", ClassroomId = 1,UserId = 2,DeviceId =1, Attended = true },
                new Student { Id = 2, Name = "Bob Smith", ClassroomId = 2,UserId=3, DeviceId = 2, Attended = false }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Email = "wayne@university.edu",Username="wayne", Password = "hashedPassword123", Role = "Professor" },
                new User { Id = 2, Email = "alice@university.edu", Username = "alice", Password = "hashedPassword1234", Role = "Student" },
                new User { Id = 3, Email = "bob@university.edu", Username = "bob", Password = "hashedPassword12345", Role = "Student" }
            );

            modelBuilder.Entity<Professor>().HasData(
                new Professor { Id = 1, Name = "Dr. Wayne", UserId = 1 }
            );

            modelBuilder.Entity<Device>().HasData(
                new Device { Id = 1,Name="Alice's iphone", MACAddress = "AA:BB:CC:DD:EE:01", StudentId = 1 },
                new Device { Id = 2, Name = "Bob's iphone", MACAddress = "AA:BF:CC:DD:EC:02", StudentId = 2 }
            );
        }






        public DbSet<User> Users { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Device> Devices  { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
    }
}
