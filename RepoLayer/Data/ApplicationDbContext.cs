using Microsoft.EntityFrameworkCore;
using SharedModels.CourseModels;
using SharedModels.StudentCourse;
using SharedModels.StudentModels;

namespace RepoLayer.Data;
public class ApplicationDbContext : DbContext
{
    public DbSet<StudentModel> Students { get; set; }
    public DbSet<CourseModel> Courses { get; set; }
    public DbSet<StudentCourseModel> StudentsCourses { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        //optionsBuilder.UseInMemoryDatabase(databaseName: "SIS_Demo");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Define composite key
        modelBuilder.Entity<StudentCourseModel>().HasKey(u => new { u.StudentId, u.CourseId });
        
        var studentsCourseList = new[]
        {
            new StudentCourseModel { StudentId=1,CourseId=1 },
            new StudentCourseModel { StudentId=1,CourseId=3 },
            new StudentCourseModel { StudentId=1,CourseId=5 },
            new StudentCourseModel { StudentId=2,CourseId=1 },
            new StudentCourseModel { StudentId=2,CourseId=4 },
            new StudentCourseModel { StudentId=2,CourseId=5 },
            new StudentCourseModel { StudentId=3,CourseId=2 },
            new StudentCourseModel { StudentId=3,CourseId=4 },
            new StudentCourseModel { StudentId=3,CourseId=6 },
            new StudentCourseModel { StudentId=4,CourseId=1 },
            new StudentCourseModel { StudentId=4,CourseId=5 },
            new StudentCourseModel { StudentId=4,CourseId=7 },
            new StudentCourseModel { StudentId=5,CourseId=1 },
            new StudentCourseModel { StudentId=5,CourseId=6 },
            new StudentCourseModel { StudentId=5,CourseId=7 },
        };
        modelBuilder.Entity<StudentCourseModel>().HasData(studentsCourseList);


        // Seed Data
        var studentList = new[]
        {
            new StudentModel { Id = 1, FirstName="John", LastName="Smith", Email="jsmith@sisdemo.edu", PhoneNumber="111-111-1111", BirthDate = new DateOnly(1991,01,21), StudentImage="guy1.png" },
            new StudentModel { Id = 2, FirstName="Sue", MiddleName="L.", LastName="Russell", Email="srussell@sisdemo.edu", PhoneNumber="222-222-2222", BirthDate = new DateOnly(1992,02,22), StudentImage="girl1.png" },
            new StudentModel { Id = 3, FirstName="Frank", LastName="Thomas", Email="fthomas@sisdemo.edu", PhoneNumber="333-333-3333", BirthDate = new DateOnly(1993,03,23), StudentImage="guy2.png" },
            new StudentModel { Id = 4, FirstName="Patty", LastName="Anderson", Email="panderson@sisdemo.edu", PhoneNumber="444-444-4444", BirthDate = new DateOnly(1994,04,24), StudentImage="girl2.png" },
            new StudentModel { Id = 5, FirstName="Sam", MiddleName="David", LastName="Jones", Email="sjones@sisdemo.edu", PhoneNumber="555-555-5555", BirthDate = new DateOnly(1995,05,25), StudentImage="guy3.png" }
        };
        modelBuilder.Entity<StudentModel>().HasData(studentList);

        var courseList = new[]
        {
            new CourseModel { Id = 1, CourseName="MAC 1105 Basic College Algebra", CourseDescription="MAC 1105 (College Algebra) is a review of Algebra designed to prepare students for MAC 1140 or MAC 1147.",
                                CourseStartDate = new DateTime(2024,1,15,12,0,0)},
            new CourseModel { Id = 2, CourseName="MAC1140 - Precalculus Algebra", CourseDescription="This course will cover all standard aspects of precalculus except for trigonometry.",
                                CourseStartDate = new DateTime(2024,1,15,13,0,0)},
            new CourseModel { Id = 3, CourseName="ENC 1136 Multimodal Writing and Digital Literacy", CourseDescription="Compose and convey creative, well-researched, carefully crafted information through digital platforms.",
                                CourseStartDate = new DateTime(2024,1,15,14,0,0)},
            new CourseModel { Id = 4, CourseName="ENC 1145 Topics for Composition", CourseDescription="Instruction in expository-argumentative writing related to one special topic selected by the instructor.",
                                CourseStartDate = new DateTime(2024,1,15,3,0,0)},
            new CourseModel { Id = 5, CourseName="ACG 2021 Introduction to Financial Accounting", CourseDescription="Conceptual introduction to financial accounting.",
                                CourseStartDate = new DateTime(2024,1,15,10,0,0)},
            new CourseModel { Id = 6, CourseName="AMH 2020 United States Since 1877", CourseDescription="Surveys the emergence of modern America as an industrial and world power.",
                                CourseStartDate = new DateTime(2024,1,15,9,0,0)},
            new CourseModel { Id = 7, CourseName="ARE 2045 Introduction to Teaching Art", CourseDescription="Study of rationales for teaching art, contemporary art teaching practices, community art experiences and alternative career options.",
                                CourseStartDate = new DateTime(2024,1,15,11,0,0)},
        };
        modelBuilder.Entity<CourseModel>().HasData(courseList);

        


    }
}
