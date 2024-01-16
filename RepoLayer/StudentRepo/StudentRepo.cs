using Microsoft.EntityFrameworkCore;
using RepoLayer.Data;
using SharedModels.StudentModels;

namespace RepoLayer.StudentRepo;
public class StudentRepo : IStudentRepo
{
    private readonly ApplicationDbContext _context;

    public StudentRepo(ApplicationDbContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();
    }

    public async Task<StudentModel?> GetStudentByIdAsync(int id)
    {
        var student = await _context.Students.Include(s => s.StudentsCourses).ThenInclude(s => s.Course).FirstOrDefaultAsync(s => s.Id == id);
        return student;
    }

    public async Task<List<StudentModel>> GetStudentsAsync()
    {
        return await _context.Students.AsNoTracking().OrderBy(s => s.LastName).ToListAsync();
    }
}
