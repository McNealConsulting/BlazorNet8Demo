using SharedModels.CourseModels;
using SharedModels.StudentModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.StudentCourse;
public class StudentCourseModel
{
    //public int Id { get; set; }

    [ForeignKey("StudentModel")]
    public int StudentId { get; set; }

    [ForeignKey("CourseModel")]
    public int CourseId { get; set; }

    // Navigation Properties
    
    public StudentModel Student { get; set; }
    
    public CourseModel Course { get; set; }
}
