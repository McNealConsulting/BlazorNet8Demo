using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels.StudentModels;

namespace RepoLayer.StudentRepo;
public class StudentRepo : IStudentRepo
{
    // For this demo Im just using some static data, but you would normally use EF Core here, and query against the DbContext.

    List<StudentModel> _students = new List<StudentModel>
    { 
        new StudentModel{ Id = 1, FirstName = "Frank", LastName = "Johnson", Email = "fjohnson@aol.com", PhoneNumber = "1114567890", BirthDate = DateOnly.FromDateTime(DateTime.Now).AddYears(-25) },
        new StudentModel{ Id = 2, FirstName = "Sam", LastName = "Thomas", Email = "sthomas@aol.com", PhoneNumber = "2224567890", BirthDate = DateOnly.FromDateTime(DateTime.Now).AddYears(-30) },
        new StudentModel{ Id = 3, FirstName = "Patty", LastName = "Smith", Email = "psmith@aol.com", PhoneNumber = "3334567890", BirthDate = DateOnly.FromDateTime(DateTime.Now).AddYears(-35) },
        new StudentModel{ Id = 4, FirstName = "Susan", LastName = "Russell", Email = "srussell@aol.com", PhoneNumber = "4444567890", BirthDate = DateOnly.FromDateTime(DateTime.Now).AddYears(-40) },
        new StudentModel{ Id = 5, FirstName = "John", LastName = "Overton", Email = "joverton@aol.com", PhoneNumber = "5554567890", BirthDate = DateOnly.FromDateTime(DateTime.Now).AddYears(-45) }
    };

    public async Task<StudentModel?> GetStudentByIdAsync(int id)
    {
        // For demonstration purposes since we aren't querying against a real datasource
        await Task.Delay(10);
        return _students.FirstOrDefault(s => s.Id == id);
    }
}
