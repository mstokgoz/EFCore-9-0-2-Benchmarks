using Commencis.EfCore.Domain.Aggregates;
using Commencis.EfCore.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Commencis.EfCore.Infrastructure;

public class BenchmarkDbContext : DbContext
{
    public DbSet<School> Schools { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer("Server=localhost,1433;Database=BenchmarkDb;User Id=sa;Password=YourStrong!Passw0rd;Encrypt=True;TrustServerCertificate=True;",
                options => options.CommandTimeout(300));
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>()
            .HasMany(c => c.Students)
            .WithMany(s => s.Courses)
            .UsingEntity<Dictionary<string, object>>(
                "CourseStudent",
                j => j.HasOne<Student>()
                    .WithMany()
                    .HasForeignKey("StudentsId")
                    .OnDelete(DeleteBehavior.NoAction),
                j => j.HasOne<Course>()
                    .WithMany()
                    .HasForeignKey("CoursesId")
                    .OnDelete(DeleteBehavior.Cascade));
        
        modelBuilder.Entity<School>().OwnsOne(s => s.Address);
        modelBuilder.Entity<School>().OwnsOne(s => s.ContactInfo);
    
        modelBuilder.Entity<Teacher>().OwnsOne(t => t.Address);
        modelBuilder.Entity<Teacher>().OwnsOne(t => t.ContactInfo);

        modelBuilder.Entity<Student>().OwnsOne(s => s.Address);
        modelBuilder.Entity<Student>().OwnsOne(s => s.ContactInfo);
        
        modelBuilder.Entity<School>().HasIndex(s => s.Id).IsUnique();
        modelBuilder.Entity<Teacher>().HasIndex(t => t.Id).IsUnique();
        modelBuilder.Entity<Student>().HasIndex(s => s.Id).IsUnique();
        modelBuilder.Entity<Course>().HasIndex(c => c.Id).IsUnique();
    }
    
    public void SeedData()
    {
        if (Schools.Any()) return;
        
        var random = new Random();
        var schools = Enumerable.Range(1, 100)
            .Select(i => new School {
                Name = $"School {i}",
                Id = Guid.NewGuid(),
                Address = new Address { Street = "Street " + i, City = "City " + i, State = "State", PostalCode = "12345", Country = "Country" },
                ContactInfo = new ContactInfo { PhoneNumber = "+123456789", Email = $"school{i}@example.com" }
            })
            .ToList();
        Schools.AddRange(schools);
        SaveChanges();

        var teachers = Enumerable.Range(1, 4000)
            .Select(i => new Teacher {
                Name = $"Teacher {i}",
                SchoolId = schools[random.Next(schools.Count)].Id,
                Id = Guid.NewGuid(),
                Address = new Address { Street = "Street " + i, City = "City " + i, State = "State", PostalCode = "12345", Country = "Country" },
                ContactInfo = new ContactInfo { PhoneNumber = "+123456789", Email = $"teacher{i}@example.com" }
            })
            .ToList();
        Teachers.AddRange(teachers);
        SaveChanges();

        var students = Enumerable.Range(1, 200000)
            .Select(i => new Student {
                Name = $"Student {i}",
                SchoolId = schools[random.Next(schools.Count)].Id,
                Id = Guid.NewGuid(),
                Address = new Address { Street = "Street " + i, City = "City " + i, State = "State", PostalCode = "12345", Country = "Country" },
                ContactInfo = new ContactInfo { PhoneNumber = "+123456789", Email = $"student{i}@example.com" }
            })
            .ToList();
        Students.AddRange(students);
        SaveChanges();
        
        var courses = Enumerable.Range(1, 10000)
            .Select(i => new Course {
                Name = $"Course {i}",
                TeacherId = teachers[random.Next(teachers.Count)].Id
                
            })
            .ToList();
        Courses.AddRange(courses);
        SaveChanges();

        foreach (var course in Courses)
        {
            var schoolStudents = students.Where(s => s.SchoolId == course.Teacher.SchoolId).OrderBy(s => random.Next()).Take(100).ToList();
            course.Students.AddRange(schoolStudents);
        }
        SaveChanges();
    }
}
