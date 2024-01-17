using SharedModels.StudentModels;

namespace RepoLayer.StudentRepo;
public interface IStudentRepo
{
    Task<List<StudentModel>> GetStudentsAsync();
    Task<StudentModel?> GetStudentByIdAsync(int id);
    Task<StudentModel> UpdateStudentAsync(StudentModel student);
}
