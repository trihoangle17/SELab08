using Microsoft.EntityFrameworkCore;
using SchoolManagement.Razor.Models;

namespace SchoolManagement.Razor.Data;

public class SchoolContext(DbContextOptions<SchoolContext> options) : DbContext(options)
{
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().HasIndex(s => s.Email).IsUnique();
        modelBuilder.Entity<Course>().HasIndex(c => c.Code).IsUnique();
        modelBuilder.Entity<Enrollment>().HasIndex(e => new { e.StudentId, e.CourseId }).IsUnique();
        modelBuilder.Entity<Enrollment>().Property(e => e.Grade).HasPrecision(4, 2);
        modelBuilder.Entity<Department>().HasMany(d => d.Courses).WithOne(c => c.Department)
            .HasForeignKey(c => c.DepartmentId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Student>().HasMany(s => s.Enrollments).WithOne(e => e.Student)
            .HasForeignKey(e => e.StudentId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Course>().HasMany(c => c.Enrollments).WithOne(e => e.Course)
            .HasForeignKey(e => e.CourseId).OnDelete(DeleteBehavior.Restrict);
    }
}
