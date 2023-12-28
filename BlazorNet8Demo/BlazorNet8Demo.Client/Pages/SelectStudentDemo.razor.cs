using Microsoft.AspNetCore.Components;
using ViewModels.StudentVM;

namespace BlazorNet8Demo.Client.Pages;

public partial class SelectStudentDemo
{
    [Inject]
    IStudentVM StudentVM { get; set; } = null!;
    
    public int newStudentId = 0;

    private async Task GetStudent()
    {
        if(newStudentId > 0 && newStudentId <= 5)
        {
            await StudentVM.GetStudentByIdAsync(newStudentId);
        }
        else
        {
            // Would normally display an error here for the user, but not doing so for this demo
            StudentVM.StudentModel = null;
        }
    }
}
