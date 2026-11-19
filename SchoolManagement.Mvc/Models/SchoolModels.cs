using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Mvc.Models;

public class Department
{
    public int DepartmentId { get; set; }
    [Required, StringLength(100)] public string Name { get; set; } = string.Empty;
    [StringLength(200)] public string? Office { get; set; }
    public ICollection<Course> Courses { get; set; } = new List<Course>();
}

public class Course
{
    public int CourseId { get; set; }
    [Required, StringLength(20)] public string Code { get; set; } = string.Empty;
    [Required, StringLength(150)] public string Title { get; set; } = string.Empty;
    [Range(1, 10)] public int Credits { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; } = null!;
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}

public class Student
{
    public int StudentId { get; set; }
    [Required, StringLength(100)] public string FullName { get; set; } = string.Empty;
    [Required, EmailAddress, StringLength(150)] public string Email { get; set; } = string.Empty;
    [DataType(DataType.Date)] public DateTime EnrollmentDate { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}

public class Enrollment
{
    public int EnrollmentId { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;
    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;
    [Range(0, 10)] public decimal? Grade { get; set; }
}
