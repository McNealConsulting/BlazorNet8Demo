using RepoLayer.StudentRepo;
using SharedModels.StudentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        // Perform Validations, and any other tasks before calling the Repository
        // ...
        return await _studentRepo.GetStudentByIdAsync(id);
    }
}
