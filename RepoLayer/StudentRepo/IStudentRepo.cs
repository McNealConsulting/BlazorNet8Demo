using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels;
using SharedModels.StudentModels;

namespace RepoLayer.StudentRepo;
public interface IStudentRepo
{
    Task<StudentModel?> GetStudentByIdAsync(int id);
}
