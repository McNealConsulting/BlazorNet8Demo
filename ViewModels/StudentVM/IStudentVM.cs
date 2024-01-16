using SharedModels.StudentModels;

namespace ViewModels.StudentVM;
public interface IStudentVM
{
    List<StudentModel> Students { get; set; }
    StudentModel? StudentModel { get; set; }
    Task GetStudentsAsync();
    Task GetStudentByIdAsync(int id);

}
