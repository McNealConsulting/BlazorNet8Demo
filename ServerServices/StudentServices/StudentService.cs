using RepoLayer.StudentRepo;
using SharedModels.StudentModels;

namespace ServerServices.StudentServices;
public class StudentService : IStudentService
{
    private readonly IStudentRepo _studentRepo;

    public StudentService(IStudentRepo studentRepo)
    {
        _studentRepo = studentRepo;
    }
    public async Task<StudentModel?> GetStudentByIdAsync(int id)
    {
        // Here you would perform Validations, and any other tasks before calling the Repository
        
        return await _studentRepo.GetStudentByIdAsync(id);
    }

    public async Task<List<StudentModel>> GetStudentsAsync()
    {
        return await _studentRepo.GetStudentsAsync();
    }
}
