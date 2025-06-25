using IndoorLocalizationSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IndoorLocalizationSystem.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
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

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Device)
                .WithOne(d => d.Student)
                .HasForeignKey<Device>(d => d.StudentId);

            // Classrooms
            modelBuilder.Entity<Classroom>().HasData(
                new Classroom { Id = 1, Name = "Lab A" },
                new Classroom { Id = 2, Name = "Room 101" },
                new Classroom { Id = 3, Name = "Room 202" },
                new Classroom { Id = 4, Name = "Lab B" }
            );

            // Users
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "wayne", Email = "wayne@university.edu", Password = "hashed1", Role = "Professor" },
                new User { Id = 2, Username = "alice", Email = "alice@university.edu", Password = "hashed2", Role = "Student" },
                new User { Id = 3, Username = "bob", Email = "bob@university.edu", Password = "hashed3", Role = "Student" },
                new User { Id = 4, Username = "elena", Email = "elena@university.edu", Password = "hashed4", Role = "Student" },
                new User { Id = 5, Username = "miller", Email = "miller@university.edu", Password = "hashed5", Role = "Professor" },
                new User { Id = 6, Username = "smith", Email = "smith@university.edu", Password = "hashed6", Role = "Professor" },
                   
                new User { Id = 7, Username = "brown", Email = "brown@university.edu", Password = "hashed6", Role = "Student" },

                new User { Id = 8, Username = "king", Email = "king@university.edu", Password = "hashed6", Role = "Student" },
                new User { Id = 9, Username = "stone", Email = "stone@university.edu", Password = "hashed6", Role = "Student" }
            );

            // Professors
            modelBuilder.Entity<Professor>().HasData(
                new Professor { Id = 1, Name = "Dr. Wayne", UserId = 1 },
                new Professor { Id = 2, Name = "Prof. Miller", UserId = 5 },
                new Professor { Id = 3, Name = "Dr. Smith", UserId = 6 }
            );

            // Students
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Alice Johnson", ClassroomId = 1, UserId = 2, DeviceId = 1, Attended = true },
                new Student { Id = 2, Name = "Bob Smith", ClassroomId = 2, UserId = 3, DeviceId = 2, Attended = false },
                new Student { Id = 3, Name = "Elena White", ClassroomId = 3, UserId = 4, DeviceId = 3, Attended = true },
                new Student { Id = 4, Name = "Liam Brown", ClassroomId = 1, UserId = 7, DeviceId = 4, Attended = true },
                new Student { Id = 5, Name = "Noah King", ClassroomId = 2, UserId = 8, DeviceId = 5, Attended = false },
                new Student { Id = 6, Name = "Emma Stone", ClassroomId = 4, UserId = 9, DeviceId = 6, Attended = true }
            );

            // Devices
            modelBuilder.Entity<Device>().HasData(
                new Device { Id = 1, Name = "Alice's iPhone", MACAddress = "AA:BB:CC:DD:EE:01", StudentId = 1, PositionX = 1.73f, PositionY = 2.5f },
                new Device { Id = 2, Name = "Bob's Galaxy", MACAddress = "AA:BB:CC:DD:EE:02", StudentId = 2, PositionX = 1.8f, PositionY = 2.1f },
                new Device { Id = 3, Name = "Elena's Pixel", MACAddress = "AA:BB:CC:DD:EE:03", StudentId = 3, PositionX = 2.0f, PositionY = 3.0f },
                new Device { Id = 4, Name = "Liam's Tablet", MACAddress = "AA:BB:CC:DD:EE:04", StudentId = 4, PositionX = 2.5f, PositionY = 1.5f },
                new Device { Id = 5, Name = "Noah's Phone", MACAddress = "AA:BB:CC:DD:EE:05", StudentId = 5, PositionX = 3.2f, PositionY = 2.3f },
                new Device { Id = 6, Name = "Emma's Phone", MACAddress = "AA:BB:CC:DD:EE:06", StudentId = 6, PositionX = 3.0f, PositionY = 1.0f }
            );

            // Courses
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = "1", Name = "Computer Networks", ClassroomId = 1, ProfessorId = 1 },
                new Course { Id = "2", Name = "IoT Security", ClassroomId = 2, ProfessorId = 1 },
                new Course { Id = "3", Name = "Embedded Systems", ClassroomId = 3, ProfessorId = 2 },
                new Course { Id = "4", Name = "AI in Edge Devices", ClassroomId = 4, ProfessorId = 3 }
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
