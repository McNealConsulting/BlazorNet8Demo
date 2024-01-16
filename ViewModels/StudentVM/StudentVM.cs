using ServerServices.StudentServices;
using SharedModels.StudentModels;

namespace ViewModels.StudentVM;
public class StudentVM : IStudentVM
{
    private readonly IStudentService _studentService;
    private StudentModel? _studentModel;
    public List<StudentModel> Students { get; set; } = new();

    public StudentVM(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public StudentModel? StudentModel { get => _studentModel; set => _studentModel = value; }

    public async Task GetStudentByIdAsync(int id)
    {
        StudentModel = await _studentService.GetStudentByIdAsync(id);
    }

    public async Task GetStudentsAsync()
    {
        Students = await _studentService.GetStudentsAsync();
    }
}
