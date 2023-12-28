using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels.StudentModels;

namespace ViewModels.StudentVM;
public interface IStudentVM
{
    StudentModel? StudentModel { get; set; }

    string FullName { get; }

    Task GetStudentByIdAsync(int id);

}
