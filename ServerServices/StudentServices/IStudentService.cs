using RepoLayer.StudentRepo;
using SharedModels.StudentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServerServices.StudentServices;
public interface IStudentService
{
    Task<List<StudentModel>> GetStudentsAsync();
    Task<StudentModel?> GetStudentByIdAsync(int id);
}
