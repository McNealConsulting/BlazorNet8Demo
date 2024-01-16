using SharedModels.StudentCourse;
using System.ComponentModel.DataAnnotations;

namespace SharedModels.CourseModels;
public class CourseModel
{
    public int Id { get; set; } = 0;

    [Display(Name = "Course Name")]
    [Required(ErrorMessage = "Course name is required.")]
    [StringLength(50, ErrorMessage = "Course Name has a maximum length of 50 characters.")]
    public string CourseName { get; set; } = string.Empty;

    [Display(Name = "Course Description")]
    [Required(ErrorMessage = "Course description is required.")]
    [StringLength(500, ErrorMessage = "Course Description has a maximum length of 200 characters.")]
    public string CourseDescription { get; set; } = string.Empty;

    [Display(Name = "Start Date")]
    [Required(ErrorMessage = "Start Date is required.")]
    [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{dddd, dd MMMM yyyy}", ApplyFormatInEditMode = true)]
    public DateTime CourseStartDate {  get; set; }

    // Relationships
    public List<StudentCourseModel> StudentsCourses { get; set; }
}
