using ServerServices.StudentServices;
using SharedModels.StudentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.StudentVM;
public class StudentVM : IStudentVM
{
    private readonly IStudentService _studentService;
    private StudentModel? _studentModel;

    public StudentVM(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public StudentModel? StudentModel { get => _studentModel; set => _studentModel = value; }
    public string FullName => $"{StudentModel?.FirstName} {StudentModel?.MiddleName?.Trim() ?? ""} {StudentModel?.LastName}";

    public async Task GetStudentByIdAsync(int id)
    {
        StudentModel = await _studentService.GetStudentByIdAsync(id);
    }
    
}
